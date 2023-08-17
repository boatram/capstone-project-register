using CapstoneProject.Repository;
using CapstoneProject.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Service
{
    public class StudentInSemesterService
    {
        public IEnumerable<StudentInSemester> GetStudentInSemesters() => StudentInSemesterRepository.Instance.GetStudentInSemesters();
    }

}
