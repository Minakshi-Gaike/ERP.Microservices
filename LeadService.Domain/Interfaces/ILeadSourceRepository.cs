using LeadService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeadService.Domain.Interfaces
{
    public interface ILeadSourceRepository
    {
        Task<IEnumerable<LeadSource>> GetAllAsync();

        Task<LeadSource?> GetByIdAsync(int sourceId);

        Task<string> CreateAsync(LeadSource leadSource);

        Task<string> UpdateAsync(LeadSource leadSource);

        Task<string> DeleteAsync(int sourceId);

        Task<string> RestoreAsync(int sourceId);
    }
}
