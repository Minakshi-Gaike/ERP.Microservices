using System;
using System.Collections.Generic;
using System.Text;

namespace EnquiryService.Application.Interfaces
{
    using EnquiryService.Application.DTOs;


    public interface IEnquiryService
    {
        Task<IEnumerable<EnquiryDto>> GetAllAsync();

        Task<EnquiryDto?> GetByIdAsync(int enquiryId);

        Task<string> CreateAsync(CreateEnquiryDto dto);

        Task<string> UpdateAsync(UpdateEnquiryDto dto);

        Task<string> DeleteAsync(int enquiryId);

        Task<string> RestoreAsync(int enquiryId);
    }
}
