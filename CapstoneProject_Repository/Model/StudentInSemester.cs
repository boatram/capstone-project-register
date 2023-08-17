using System;
using System.Collections.Generic;

#nullable disable

namespace CapstoneProject.Repository.Model
{
    public partial class StudentInSemester
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public int? StudentId { get; set; }
        public int? SemesterId { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual Student Student { get; set; }
    }
}
