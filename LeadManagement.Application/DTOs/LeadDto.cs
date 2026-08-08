using System;
using System.Collections.Generic;
using System.Text;

namespace LeadManagement.Application.DTOs
{

    public class LeadDto
    {
        public int LeadId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string EmailId { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public int CourseId { get; set; }

        public string CourseStatus { get; set; } = string.Empty;

        public string LeadSource { get; set; } = string.Empty;
    }
}

