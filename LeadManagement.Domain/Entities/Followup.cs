using System;
using System.Collections.Generic;
using System.Text;

namespace LeadManagement.Domain.Entities
{
   

    public class Followup
    {
        public int FollowupId { get; set; }

        public int LeadId { get; set; }

        public int StaffId { get; set; }

        public string? Remarks { get; set; }

        public DateTime NextFollowupDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? RestoredAt { get; set; }
    }
}

