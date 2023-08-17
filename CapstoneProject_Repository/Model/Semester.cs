using System;
using System.Collections.Generic;

#nullable disable

namespace CapstoneProject.Repository.Model
{
    public partial class Semester
    {
        public Semester()
        {
            GroupProjects = new HashSet<GroupProject>();
            StudentInSemesters = new HashSet<StudentInSemester>();
            Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<GroupProject> GroupProjects { get; set; }
        public virtual ICollection<StudentInSemester> StudentInSemesters { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
