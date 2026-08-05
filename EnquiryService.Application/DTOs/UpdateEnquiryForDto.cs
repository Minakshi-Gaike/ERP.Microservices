using System;
using System.Collections.Generic;
using System.Text;


    namespace EnquiryService.Application.DTOs.EnquiryFor
    {
        public class UpdateEnquiryForDto
        {
            public int EnquiryForId { get; set; }

            public string? EnquiryFor { get; set; }

            public int? Flag { get; set; }
        }
    }

