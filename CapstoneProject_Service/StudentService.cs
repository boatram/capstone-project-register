using CapstoneProject.Repository;
using CapstoneProject.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Service
{
    public class StudentService
    {
        public IEnumerable<Student> GetStudents() => StudentRepository.Instance.GetStudents();
        public Student GetStudentByID(int? ID) => StudentRepository.Instance.GetStudentByID(ID);
        public void Create(Student topic) => StudentRepository.Instance.Create(topic);
        public void Update(Student topic) => StudentRepository.Instance.Update(topic);
        public bool Delete(int ID) => StudentRepository.Instance.Delete(ID);
    }
}
