using System;
using System.Collections.Generic;
using System.Text;

 
namespace EnquiryService.Domain.Entities
    {
        public class EnquiryFor
        {
            public int EnquiryForId { get; set; }

            public string? EnquiryForName { get; set; }

            public int? Flag { get; set; }

            public DateTime CreatedAt { get; set; }

            public DateTime? UpdatedAt { get; set; }

            public DateTime? DeletedAt { get; set; }

            public DateTime? RestoredAt { get; set; }
        }
    }

