using LeadManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;



namespace LeadManagement.Domain.Interfaces;

    public interface IFollowupRepository
    {
        Task<IEnumerable<Followup>> GetAllAsync();

        Task<Followup?> GetByIdAsync(int followupId);

        Task<string> InsertAsync(Followup followup);

        Task<string> UpdateAsync(Followup followup);

        Task<string> DeleteAsync(int followupId);

        Task<string> RestoreAsync(int followupId);
    }

