using EnquiryService.Application.DTOs.EnquiryFollowUp;
using System;
using System.Collections.Generic;
using System.Text;



namespace EnquiryService.Application.Interfaces
    {
        public interface IEnquiryFollowUpService
        {
            Task<IEnumerable<EnquiryFollowUpDto>> GetAllAsync();

            Task<EnquiryFollowUpDto?> GetByIdAsync(int followUpId);

            Task<string> CreateAsync(CreateEnquiryFollowUpDto dto);

            Task<string> UpdateAsync(UpdateEnquiryFollowUpDto dto);

            Task<string> DeleteAsync(int followUpId);

            Task<string> RestoreAsync(int followUpId);
        }
    }
