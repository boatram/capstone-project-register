using System;
using System.Collections.Generic;

#nullable disable

namespace CapstoneProject.Repository.Model
{
    public partial class Topic
    {
        public Topic()
        {
            GroupProjects = new HashSet<GroupProject>();
            TopicOfLecturers = new HashSet<TopicOfLecturer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public int? SemesterId { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual ICollection<GroupProject> GroupProjects { get; set; }
        public virtual ICollection<TopicOfLecturer> TopicOfLecturers { get; set; }
    }
}
