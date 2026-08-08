using System;
using System.Collections.Generic;
using System.Text;

namespace LeadManagement.Application.DTOs
{
    

    public class FollowupDto
    {
        public int FollowupId { get; set; }

        public int LeadId { get; set; }

        public int StaffId { get; set; }

        public string? Remarks { get; set; }

        public DateTime NextFollowupDate { get; set; }
    }
}

