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
    public class StudentInGroupRepository
    {
        private static StudentInGroupRepository instance = null;
        private static StudentInSemesterRepository repository = null;
        private static GroupRepository groupRepository = null;
        public static readonly object instanceLock = new object();
        public static StudentInGroupRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StudentInGroupRepository();
                        repository = new StudentInSemesterRepository();
                        groupRepository = new GroupRepository();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<GroupView> GetGroupViews()
        {
            var groups = new List<GroupView>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                groups = context.StudentInGroups.Select(a => new GroupView
                {
                    Id = a.Id,
                    Name = a.Group.Name,
                    SemesterCode = a.Group.Semester.Code,
                    TopicName = a.Group.Topic.Name,
                    StudentName = a.Student.Name,
                    Role = a.Role,
                    JoinDate = a.JoinDate,
                    Status = a.Status,
                    Description = a.Description
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return groups;
        }

        public IEnumerable<StudentInGroup> GetStudentInGroups(int? groupId)
        {
            var students = new List<StudentInGroup>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                students = context.StudentInGroups.Include(t => t.Group).Include(t => t.Student).Where(c => c.GroupId == groupId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return students;
        }

        public StudentInGroup GetStudentInGroupByID(int? ID)
        {
            StudentInGroup topic = null;
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topic = context.StudentInGroups.SingleOrDefault(m => m.Id == ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topic;
        }

        public StudentInGroup GetStudentInGroup(int? studentId, int? groupId)
        {
            StudentInGroup topic = null;
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topic = context.StudentInGroups.Where(m => m.GroupId == groupId).SingleOrDefault(m => m.StudentId == studentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topic;
        }

        public void Create(StudentInGroup topic)
        {
            try
            {
                int count = groupRepository.GetGroupProjects().Count();
                if(count <= 4)
                {
                    StudentInSemester sis = repository.GetStudentInSemesterByID(topic.StudentId);
                    if (sis != null)
                    {
                        StudentInGroup gr = GetStudentInGroup(topic.StudentId, topic.GroupId);
                        if (gr == null)
                        {
                            using var context = new CapstoneProjectRegisterContext();
                            context.StudentInGroups.Add(topic);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("The student is already exist.");
                        }
                    }
                    else
                    {
                        throw new Exception("The student is not eligible this semester");
                    }
                }
                else
                {
                    throw new Exception("The group is full");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(StudentInGroup topic)
        {
            try
            {
                StudentInGroup _topic = GetStudentInGroupByID(topic.Id);
                if (_topic != null)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    context.StudentInGroups.Update(topic);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The student does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int? ID)
        {
            try
            {
                StudentInGroup _topic = GetStudentInGroupByID(ID);
                if (_topic!= null)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    context.StudentInGroups.Remove(_topic);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("The student does not already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
