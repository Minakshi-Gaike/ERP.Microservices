using System;
using System.Collections.Generic;
using System.Text;



namespace LeadService.Domain.Entities
    {
        public class LeadSource
        {
            public int SourceId { get; set; }

            public string? SourceName { get; set; }

            public int? Flag { get; set; }

            public DateTime CreatedAt { get; set; }

            public DateTime? UpdatedAt { get; set; }

            public DateTime? DeletedAt { get; set; }

            public DateTime? RestoredAt { get; set; }
        }
    }

