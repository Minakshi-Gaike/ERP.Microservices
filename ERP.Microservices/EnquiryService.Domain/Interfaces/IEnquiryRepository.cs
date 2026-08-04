using System;
using System.Collections.Generic;
using System.Text;

namespace EnquiryService.Domain.Interfaces
{
    using EnquiryService.Domain.Entities;

    public interface IEnquiryRepository
    {
        Task<IEnumerable<Enquiry>> GetAllAsync();

        Task<Enquiry?> GetByIdAsync(int enquiryId);

        Task<string> CreateAsync(Enquiry enquiry);

        Task<string> UpdateAsync(Enquiry enquiry);

        Task<string> DeleteAsync(int enquiryId);

        Task<string> RestoreAsync(int enquiryId);
    }
}
