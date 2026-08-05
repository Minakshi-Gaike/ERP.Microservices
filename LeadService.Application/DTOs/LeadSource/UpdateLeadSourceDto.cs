using System;
using System.Collections.Generic;
using System.Text;

namespace LeadService.Application.DTOs.LeadSource
{
    public class UpdateLeadSourceDto
    {
        public int SourceId { get; set; }

        public string? SourceName { get; set; }

        public int? Flag { get; set; }
    }

}

