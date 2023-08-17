using CapstoneProject.Repository.Model;
using CapstoneProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneProject.Repository.DTO;

namespace CapstoneProject.Service
{
    public class TopicService
    {
        public IEnumerable<Topic> GetTopics() => TopicRepository.Instance.GetTopics();
        public Topic GetTopicByID(int? topicID) => TopicRepository.Instance.GetTopicByID(topicID);
        public IEnumerable<Topic> GetTopicByName(string? name) => TopicRepository.Instance.GetTopicByName(name);
        public void Create (TopicView topic) => TopicRepository.Instance.Create(topic);
        public void Update(Topic topic) => TopicRepository.Instance.Update(topic);
        public bool Delete(int topicID) => TopicRepository.Instance.Delete(topicID);
    }
}
