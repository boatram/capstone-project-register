using CapstoneProject.Repository.Model;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapstoneProject.Repository
{
    public class GroupRepository
    {
        private static GroupRepository instance = null;
        public static readonly object instanceLock = new object();
        public static GroupRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new GroupRepository();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<GroupProject> GetGroupProjects()
        {
            var groups = new List<GroupProject>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                groups = context.GroupProjects.Include(t => t.Semester).Include(t => t.Topic).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return groups;
        }

        public GroupProject GetGroupProjectByID(int? ID)
        {
            GroupProject topic = null;
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topic = context.GroupProjects.SingleOrDefault(m => m.Id == ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topic;
        }

        public IEnumerable<GroupProject> GetGroupProjectByTopicId(int? ID)
        {
            var topics = new List<GroupProject>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topics = context.GroupProjects.Where(m => m.TopicId == ID).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topics;
        }

        public IEnumerable<GroupProject> GetGroupProjectBySemesterId(int? ID)
        {
            var topics = new List<GroupProject>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topics = context.GroupProjects.Where(m => m.SemesterId == ID).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topics;
        }

        public int GetGroupProjectByName(string? name)
        {
            int i;
            var topics = new List<GroupProject>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topics = context.GroupProjects.Where(m => m.Name.Equals(name)).ToList();
                i = topics.Count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }

        public void Create(GroupProject gr)
        {
            try
            {
                int _topic = GetGroupProjectByName(gr.Name);
                if (_topic == 0)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    context.GroupProjects.Add(gr);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The group project is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //viet lai ham chi update status
        public void Update(GroupProject topic)
        {
            try
            {
                GroupProject _topic = GetGroupProjectByID(topic.Id);
                if (_topic != null)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    context.GroupProjects.Update(topic);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The group project does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int ID)
        {
            try
            {
                GroupProject _topic = GetGroupProjectByID(ID);
                if (_topic!= null)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    context.GroupProjects.Remove(_topic);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("The group project does not already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
