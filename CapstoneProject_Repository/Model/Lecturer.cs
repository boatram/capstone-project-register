using System;
using System.Collections.Generic;

#nullable disable

namespace CapstoneProject.Repository.Model
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            TopicOfLecturers = new HashSet<TopicOfLecturer>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<TopicOfLecturer> TopicOfLecturers { get; set; }
    }
}
