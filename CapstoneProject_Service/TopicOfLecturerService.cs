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
    public class TopicOfLecturerService
    {
        public void CreateTopic(TopicOfLecturer topic) => TopicOfLecturerRepository.Instance.CreateTopic(topic);
        public IEnumerable<TopicView> GetTopic() => TopicOfLecturerRepository.Instance.GetTopic();
        public IEnumerable<TopicOfLecturer> GetTopicOfLecturers() => TopicOfLecturerRepository.Instance.GetTopicOfLecturers();
        public TopicOfLecturer GetTopicOfLecturerByID(int? ID) => TopicOfLecturerRepository.Instance.GetTopicOfLecturerByID(ID);
        public IEnumerable<TopicOfLecturer> GetTopicOfLecturerByTopicId(int? ID) => TopicOfLecturerRepository.Instance.GetTopicOfLecturerByTopicId((int)ID);
        public IEnumerable<TopicOfLecturer> GetTopicOfLecturerByLecturerId(int? ID) => TopicOfLecturerRepository.Instance.GetTopicOfLecturerByLecturerId((int)ID);
    }
}
