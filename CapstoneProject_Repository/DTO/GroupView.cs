using CapstoneProject.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Repository.DTO
{
    public class GroupView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SemesterCode { get; set; }
        public string TopicName { get; set; }
        public string StudentName { get; set; }
        public string Role { get; set; }
        public DateTime? JoinDate { get; set; }
        public bool? Status { get; set; }
        public string Description { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual Student Student { get; set; }
    }
}
