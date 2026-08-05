using EnquiryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;



namespace EnquiryService.Domain.Interfaces
    {
        public interface IEnquiryForRepository
        {
            Task<IEnumerable<EnquiryFor>> GetAllAsync();

            Task<EnquiryFor?> GetByIdAsync(int enquiryForId);

            Task<string> CreateAsync(EnquiryFor enquiryFor);

            Task<string> UpdateAsync(EnquiryFor enquiryFor);

            Task<string> DeleteAsync(int enquiryForId);

            Task<string> RestoreAsync(int enquiryForId);
        }
    }

