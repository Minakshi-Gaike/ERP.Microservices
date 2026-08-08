using System;
using System.Collections.Generic;
using System.Text;

namespace LeadManagement.Application.DTOs
{


    public class CourseDto
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; } = string.Empty;

        public string CourseDuration { get; set; } = string.Empty;

        public int CourseFees { get; set; }

        public bool IsActive { get; set; }
    }
}

