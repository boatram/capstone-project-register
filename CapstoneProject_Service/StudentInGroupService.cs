using CapstoneProject.Repository;
using CapstoneProject.Repository.DTO;
using CapstoneProject.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Service
{
    public class StudentInGroupService
    {
        public IEnumerable<GroupView> GetGroupViews() => StudentInGroupRepository.Instance.GetGroupViews();
        public IEnumerable<StudentInGroup> GetStudentInGroups(int? id) => StudentInGroupRepository.Instance.GetStudentInGroups(id);
        public StudentInGroup GetStudentInGroupByID(int? ID) => StudentInGroupRepository.Instance.GetStudentInGroupByID(ID);
        public void Create(StudentInGroup topic) => StudentInGroupRepository.Instance.Create(topic);
        public void Update(StudentInGroup topic) => StudentInGroupRepository.Instance.Update(topic);
        public bool Delete(int? ID) => StudentInGroupRepository.Instance.Delete(ID);
    }
}
