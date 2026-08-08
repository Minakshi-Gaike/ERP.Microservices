using System;
using System.Collections.Generic;
using System.Text;

namespace LeadManagement.Domain.Entities
{
   
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; } = string.Empty;

        public string CourseDuration { get; set; } = string.Empty;

        public int CourseFees { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? RestoredAt { get; set; }
    }
}
