using CapstoneProject.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Repository.DTO
{
    public class TopicView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SemesterCode { get; set; }
        public string SuperLecturerEmail { get; set; }
        public string LecturerName { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual Lecturer Lecturer { get; set; }
    }
}
