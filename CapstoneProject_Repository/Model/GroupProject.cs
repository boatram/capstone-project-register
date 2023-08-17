using System;
using System.Collections.Generic;

#nullable disable

namespace CapstoneProject.Repository.Model
{
    public partial class GroupProject
    {
        public GroupProject()
        {
            StudentInGroups = new HashSet<StudentInGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? SemesterId { get; set; }
        public int? TopicId { get; set; }
        public bool? Status { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ICollection<StudentInGroup> StudentInGroups { get; set; }
    }
}
