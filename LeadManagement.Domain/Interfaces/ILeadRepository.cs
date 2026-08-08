using LeadManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;



namespace LeadManagement.Domain.Interfaces;

    public interface ILeadRepository
    {
        Task<IEnumerable<Lead>> GetAllAsync();

        Task<Lead?> GetByIdAsync(int leadId);

        Task<string> InsertAsync(Lead lead);

        Task<string> UpdateAsync(Lead lead);

        Task<string> DeleteAsync(int leadId);

        Task<string> RestoreAsync(int leadId);
    }

