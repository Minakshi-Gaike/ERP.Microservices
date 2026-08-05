using System;
using System.Collections.Generic;
using System.Text;


namespace EnquiryService.Application.DTOs.EnquiryFollowUp
    {
        public class EnquiryFollowUpDto
        {
            public int FollowUpId { get; set; }

            public int? EnquiryId { get; set; }

            public DateTime? FollowUpDate { get; set; }

            public string? FollowUpBy { get; set; }

            public string? Description { get; set; }
        }
    }

