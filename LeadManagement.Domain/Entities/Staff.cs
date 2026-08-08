using System;
using System.Collections.Generic;
using System.Text;

namespace LeadManagement.Domain.Entities
{
   

    public class Staff
    {
        public int StaffId { get; set; }

        public string StaffName { get; set; } = string.Empty;

        public string EmailId { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? RestoredAt { get; set; }
    }
}

