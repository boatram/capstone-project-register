using CapstoneProject.Repository.Model;
using CapstoneProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Service
{
    public class LecturerService
    {
        public IEnumerable<Lecturer> GetLecturers() => LecturerRepository.Instance.GetLecturers();
        public Lecturer GetLecturerByID(int? ID) => LecturerRepository.Instance.GetLecturerByID(ID);
        public Lecturer GetLecturerByName(string? name) => LecturerRepository.Instance.GetLecturerByName(name);
        public Lecturer GetLecturer(string email, string password) => LecturerRepository.Instance.GetLecturer(email, password);
        public int GetLecturerIdByEmail(string email) => LecturerRepository.Instance.GetLecturerIdByEmail(email);
    }
}
