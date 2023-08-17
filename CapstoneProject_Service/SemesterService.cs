using CapstoneProject.Repository.Model;
using CapstoneProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Service
{
    public class SemesterService
    {
        public IEnumerable<Semester> GetSemesters() => SemesterRepository.Instance.GetSemesters();
        public Semester GetSemesterByID(int? semesterID) => SemesterRepository.Instance.GetSemesterByID(semesterID);
        public int GetSemesterIdByCode(string? code) => SemesterRepository.Instance.GetSemesterIdByCode(code);
        public void Create(Semester semester) => SemesterRepository.Instance.Create(semester);
        public void Update(Semester semester) => SemesterRepository.Instance.Update(semester);
    }
}
