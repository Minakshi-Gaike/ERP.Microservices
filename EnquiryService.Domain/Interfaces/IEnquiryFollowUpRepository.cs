using EnquiryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;



namespace EnquiryService.Domain.Interfaces
    {
        public interface IEnquiryFollowUpRepository
        {
            Task<IEnumerable<EnquiryFollowUp>> GetAllAsync();

            Task<EnquiryFollowUp?> GetByIdAsync(int followUpId);

            Task<string> CreateAsync(EnquiryFollowUp followUp);

            Task<string> UpdateAsync(EnquiryFollowUp followUp);

            Task<string> DeleteAsync(int followUpId);

            Task<string> RestoreAsync(int followUpId);
        }
    }

