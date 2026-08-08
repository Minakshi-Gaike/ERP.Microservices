using System;
using System.Collections.Generic;
using System.Text;

namespace LeadManagement.Domain.Entities
{
 

    public class Lead
    {
        public int LeadId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string EmailId { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public int CourseId { get; set; }

        public string CourseStatus { get; set; } = string.Empty;

        public string LeadSource { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? RestoredAt { get; set; }
    }
}

