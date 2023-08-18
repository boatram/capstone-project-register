using CapstoneProject.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Repository
{
    public class StudentRepository
    {
        private static StudentRepository instance = null;
        public static readonly object instanceLock = new object();
        public static StudentRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StudentRepository();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Student> GetStudents()
        {
            var groups = new List<Student>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                groups = context.Students.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return groups;
        }

        public Student GetStudentByID(int? ID)
        {
            Student topic = null;
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topic = context.Students.SingleOrDefault(m => m.Id == ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topic;
        }

        public Student GetStudentByName(string? name)
        {
            Student topic = null;
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topic = context.Students.SingleOrDefault(m => m.Name.Equals(name));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topic;
        }

        public void Create(Student topic)
        {
            try
            {
                Student _topic = GetStudentByName(topic.Name);
                if (_topic== null)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    context.Students.Add(topic);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The student is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Student topic)
        {
            try
            {
                Student _topic = GetStudentByID(topic.Id);
                if (_topic != null)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    topic.Password = _topic.Password;
                    context.Students.Update(topic);
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

        public bool Delete(int ID)
        {
            try
            {
                Student _topic = GetStudentByID(ID);
                if (_topic!= null)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    context.Students.Remove(_topic);
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
