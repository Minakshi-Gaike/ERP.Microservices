using System;
using System.Collections.Generic;
using System.Text;

namespace LeadService.Application.DTOs.Lead
{


    public class CreateLeadDto
    {
        public string? CandidateName { get; set; }

        public string? EmailAddress { get; set; }

        public string? MobileNumber { get; set; }

        public string? TrainingType { get; set; }

        public string? Description { get; set; }

        public DateTime? LeadDate { get; set; }
    }
}
