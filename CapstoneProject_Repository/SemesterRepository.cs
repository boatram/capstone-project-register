using CapstoneProject.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Repository
{
    public class SemesterRepository
    {
        private static SemesterRepository instance = null;
        public static readonly object instanceLock = new object();
        public static SemesterRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SemesterRepository();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Semester> GetSemesters()
        {
            var semesters = new List<Semester>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                semesters = context.Semesters.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return semesters;
        }

        public Semester GetSemesterByID(int? semesterID)
        {
            Semester semester = null;
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                semester = context.Semesters.SingleOrDefault(m => m.Id == semesterID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return semester;
        }

        public int GetSemesterIdByCode(string? code)
        {
            int id;
            Semester semester = null;
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                semester = context.Semesters.SingleOrDefault(m => m.Code.Equals(code));
                id = semester.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return id;
        }

        public void Create(Semester semester)
        {
            try
            {
                Semester _semester = new Semester();
                _semester.Id = GetSemesterIdByCode(semester.Code);
                if (_semester.Id == 0)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    context.Semesters.Add(semester);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The semester is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Semester semester)
        {
            try
            {
                Semester _semester = GetSemesterByID(semester.Id);
                if (_semester != null)
                {
                    using var context = new CapstoneProjectRegisterContext();
                    context.Semesters.Update(semester);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The semester does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
