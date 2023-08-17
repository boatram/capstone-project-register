using CapstoneProject.Repository;
using CapstoneProject.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Service
{
    public class GroupService
    {
        public IEnumerable<GroupProject> GetGroupProjects() => GroupRepository.Instance.GetGroupProjects();
        public GroupProject GetGroupProjectByID(int? ID) => GroupRepository.Instance.GetGroupProjectByID(ID);
        public IEnumerable<GroupProject> GetGroupProjectByTopicId(int? ID) => GroupRepository.Instance.GetGroupProjectByTopicId((int)ID);
        public IEnumerable<GroupProject> GetGroupProjectBySemesterId(int? ID) => GroupRepository.Instance.GetGroupProjectBySemesterId((int)ID);
        public int GetGroupProjectByName(string? name) => GroupRepository.Instance.GetGroupProjectByName(name);
        public void Create(GroupProject topic) => GroupRepository.Instance.Create(topic);
        public void Update(GroupProject topic) => GroupRepository.Instance.Update(topic);
        public bool Delete(int topicID) => GroupRepository.Instance.Delete(topicID);
    }
}
