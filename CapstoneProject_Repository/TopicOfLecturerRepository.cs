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
    public class TopicOfLecturerRepository
    {
        private static TopicOfLecturerRepository instance = null;
        public static readonly object instanceLock = new object();
        
        public static TopicOfLecturerRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TopicOfLecturerRepository();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<TopicOfLecturer> GetTopicOfLecturers()
        {
            var topics = new List<TopicOfLecturer>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topics = context.TopicOfLecturers.Include(t => t.Lecturer).Include(t => t.Topic).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topics;
        }

        public IEnumerable<TopicView> GetTopic()
        {
            var topics = new List<TopicView>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topics = context.TopicOfLecturers.Select(a => new TopicView
                {
                    Id = a.Id,
                    Name = a.Topic.Name,
                    Description = a.Topic.Description,
                    SemesterCode = a.Topic.Semester.Code,
                    SuperLecturerEmail = context.TopicOfLecturers.Where(c => c.TopicId == a.TopicId).SingleOrDefault(c => c.IsSuperLecturer.Equals(true)).Lecturer.Email,
                    LecturerName = a.Lecturer.Name
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topics;
        }

        public void CreateTopic(TopicOfLecturer topic)
        {           
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                context.TopicOfLecturers.Add(topic);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TopicOfLecturer GetTopicOfLecturerByID(int? ID)
        {
            TopicOfLecturer topic = null;
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topic = context.TopicOfLecturers.SingleOrDefault(m => m.Id == ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topic;
        }

        public IEnumerable<TopicOfLecturer> GetTopicOfLecturerByTopicId(int? ID)
        {
            var topics = new List<TopicOfLecturer>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topics = context.TopicOfLecturers.Where(m => m.TopicId == ID).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topics;
        }

        public IEnumerable<TopicOfLecturer> GetTopicOfLecturerByLecturerId(int? ID)
        {
            var topics = new List<TopicOfLecturer>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topics = context.TopicOfLecturers.Where(m => m.LecturerId == ID).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topics;
        }
    }
}
