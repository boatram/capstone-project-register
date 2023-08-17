﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CapstoneProject.Repository.Model
{
    public partial class StudentInGroup
    {
        public int Id { get; set; }
        public DateTime? JoinDate { get; set; }
        public bool? Status { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public int? GroupId { get; set; }
        public int? StudentId { get; set; }

        public virtual GroupProject Group { get; set; }
        public virtual Student Student { get; set; }
    }
}
