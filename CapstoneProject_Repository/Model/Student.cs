using System;
using System.Collections.Generic;

#nullable disable

namespace CapstoneProject.Repository.Model
{
    public partial class Student
    {
        public Student()
        {
            StudentInGroups = new HashSet<StudentInGroup>();
            StudentInSemesters = new HashSet<StudentInSemester>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<StudentInGroup> StudentInGroups { get; set; }
        public virtual ICollection<StudentInSemester> StudentInSemesters { get; set; }
    }
}
