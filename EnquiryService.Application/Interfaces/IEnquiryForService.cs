using EnquiryService.Application.DTOs;
using EnquiryService.Application.DTOs.EnquiryFor;
using System;
using System.Collections.Generic;
using System.Text;



namespace EnquiryService.Application.Interfaces
    {
        public interface IEnquiryForService
        {
            Task<IEnumerable<EnquiryForDto>> GetAllAsync();

            Task<EnquiryForDto?> GetByIdAsync(int enquiryForId);

            Task<string> CreateAsync(CreateEnquiryForDto dto);

            Task<string> UpdateAsync(UpdateEnquiryForDto dto);

            Task<string> DeleteAsync(int enquiryForId);

            Task<string> RestoreAsync(int enquiryForId);
        }
    }

