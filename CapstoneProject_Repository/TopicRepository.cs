using CapstoneProject.Repository.DTO;
using CapstoneProject.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Repository
{
    public class TopicRepository
    {
        private static TopicRepository instance = null;
        private static TopicOfLecturerRepository topicOfLecturerRepository;
        private static LecturerRepository lecturerRepository;
        private static SemesterRepository semesterRepository;
        
        public static readonly object instanceLock = new object();
        public static TopicRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TopicRepository();
                        topicOfLecturerRepository = new TopicOfLecturerRepository();
                        lecturerRepository = new LecturerRepository();
                        semesterRepository = new SemesterRepository();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Topic> GetTopics()
        {
            var topics = new List<Topic>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topics = context.Topics.Include(t => t.Semester).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topics;
        }

        public Topic GetTopicByID(int? topicID)
        {
            Topic topic = null;
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topic = context.Topics.SingleOrDefault(m => m.Id == topicID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topic;
        }

        public IEnumerable<Topic> GetTopicByName(string? name)
        {
            var topics = new List<Topic>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topics = context.Topics.Where(m => m.Name.Equals(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topics;
        }

        public void Create(TopicView topic)
        {
            try
            {
                Topic topic2 = new Topic();
                topic2 = instance.GetTopicByName(topic.Name).First();
                //using var context = new CapstoneProjectRegisterContext();              
                if (topic2 == null)
                {
                    var topic1 = new Topic();
                    topic1.Name = topic.Name;
                    topic1.Description = topic.Description;
                    topic1.SemesterId = semesterRepository.GetSemesterIdByCode(topic.SemesterCode);
                    topic1.Status = false;

                    var lecture = new TopicOfLecturer();
                    lecture.LecturerId = lecturerRepository.GetLecturerIdByEmail(topic.SuperLecturerEmail);
                    lecture.IsSuperLecturer = true;
                    topic1.TopicOfLecturers.Add(lecture);
                    instance.CreateTopic(topic1);
                }
                else
                {
                    TopicOfLecturer t = new TopicOfLecturer();
                    t.TopicId = topic2.Id;
                    t.IsSuperLecturer= false;
                    t.LecturerId = lecturerRepository.GetLecturerByName(topic.LecturerName).Id;
                    topic2.TopicOfLecturers.Add(t);
                    topicOfLecturerRepository.CreateTopic(t);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateTopic(Topic topic)
        {
            try
            {
                Topic _topic = GetTopicByName(topic.Name).First();
                if (_topic== null)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    context.Topics.Add(topic);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The topic is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Topic topic)
        {
            try
            {
                Topic _topic = GetTopicByID(topic.Id);
                if (_topic != null)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    context.Topics.Update(topic);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The topic does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int topicID)
        {
            try
            {
                Topic _topic = GetTopicByID(topicID);
                if (_topic!= null)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    context.Topics.Remove(_topic);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("The topic does not already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
