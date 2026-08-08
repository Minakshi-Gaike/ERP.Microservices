using LeadManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;



namespace LeadManagement.Application.Interfaces;

    public interface ILeadService
    {
        Task<IEnumerable<LeadDto>> GetAllAsync();

        Task<LeadDto?> GetByIdAsync(int leadId);

        Task<string> InsertAsync(LeadDto leadDto);

        Task<string> UpdateAsync(LeadDto leadDto);

        Task<string> DeleteAsync(int leadId);

        Task<string> RestoreAsync(int leadId);
    }

