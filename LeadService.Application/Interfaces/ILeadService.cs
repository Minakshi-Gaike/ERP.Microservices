using LeadService.Application.DTOs.Lead;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeadService.Application.Interfaces
{

    public interface ILeadService
    {
        Task<IEnumerable<LeadDto>> GetAllAsync();

        Task<LeadDto?> GetByIdAsync(int leadId);

        Task<string> CreateAsync(CreateLeadDto dto);

        Task<string> UpdateAsync(UpdateLeadDto dto);

        Task<string> DeleteAsync(int leadId);

        Task<string> RestoreAsync(int leadId);
    }
}

