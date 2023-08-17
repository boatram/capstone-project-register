using CapstoneProject.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Repository
{
    public class StudentInSemesterRepository
    {
        private static StudentInSemesterRepository instance = null;
        public static readonly object instanceLock = new object();
        public static StudentInSemesterRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StudentInSemesterRepository();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<StudentInSemester> GetStudentInSemesters()
        {
            var groups = new List<StudentInSemester>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                groups = context.StudentInSemesters.Include(t => t.Semester).Include(t => t.Student).Where(t => t.Status.Equals(true)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return groups;
        }

        public StudentInSemester GetStudentInSemesterByID(int? studentID)
        {
            StudentInSemester topic = null;
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                topic = context.StudentInSemesters.Where(m => m.StudentId == studentID).SingleOrDefault(m => m.Status.Equals(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return topic;
        }
    }
}
