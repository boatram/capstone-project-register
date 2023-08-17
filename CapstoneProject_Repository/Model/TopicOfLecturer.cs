using System;
using System.Collections.Generic;

#nullable disable

namespace CapstoneProject.Repository.Model
{
    public partial class TopicOfLecturer
    {
        public int Id { get; set; }
        public bool IsSuperLecturer { get; set; }
        public int? LecturerId { get; set; }
        public int? TopicId { get; set; }

        public virtual Lecturer Lecturer { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
