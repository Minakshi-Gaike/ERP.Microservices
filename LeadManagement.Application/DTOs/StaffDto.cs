using System;
using System.Collections.Generic;
using System.Text;

namespace LeadManagement.Application.DTOs
{
  

    public class StaffDto
    {
        public int StaffId { get; set; }

        public string StaffName { get; set; } = string.Empty;

        public string EmailId { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}

