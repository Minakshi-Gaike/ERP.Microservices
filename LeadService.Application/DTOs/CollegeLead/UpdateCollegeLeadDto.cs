using System;
using System.Collections.Generic;
using System.Text;


        namespace CollegeLeadService.Application.DTOs.CollegeLead
    {
        public class UpdateCollegeLeadDto
        {
            public int LeadId { get; set; }

            public string? Qualification { get; set; }

            public string? CollegeName { get; set; }

            public string? StudentName { get; set; }

            public string? MotherName { get; set; }

            public string? EmailAddress { get; set; }

            public string? MobileNumber { get; set; }

            public string? Gender { get; set; }

            public string? Address { get; set; }

            public string? State { get; set; }

            public string? City { get; set; }

            public string? PinCode { get; set; }
        }
    }


