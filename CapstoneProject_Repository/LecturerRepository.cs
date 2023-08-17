using CapstoneProject.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Repository
{
    public class LecturerRepository
    {
        private static LecturerRepository instance = null;
        public static readonly object instanceLock = new object();
        public static LecturerRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new LecturerRepository();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Lecturer> GetLecturers()
        {
            var lecturers = new List<Lecturer>();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                lecturers = context.Lecturers.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lecturers;
        }

        public Lecturer GetLecturerByID(int? ID)
        {
            Lecturer lecturer = null;
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                lecturer = context.Lecturers.SingleOrDefault(m => m.Id == ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lecturer;
        }

        public Lecturer GetLecturerByName(string? name)
        {
            var lecturers = new Lecturer();
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                lecturers = context.Lecturers.SingleOrDefault(m => m.Name.Equals(name));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lecturers;
        }

        public int GetLecturerIdByEmail(string email)
        {
            int id = 0;
            try
            {
                using var context = new CapstoneProjectRegisterContext();
                var l = context.Lecturers.SingleOrDefault(m => m.Email.Equals(email));
                id = l.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return id;
        }

        public Lecturer GetLecturer(string email, string password)
        {
            Lecturer lecturer = null;
            try
            {
                using (var context = new CapstoneProjectRegisterContext())
                {
                    var lec = context.Lecturers.SingleOrDefault(c => c.Email.Equals(email.Trim()));
                    if (lec.Password.Equals(password))
                    {
                        return lec;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
