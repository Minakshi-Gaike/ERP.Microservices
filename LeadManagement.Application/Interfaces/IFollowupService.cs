using LeadManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;



namespace LeadManagement.Application.Interfaces;

    public interface IFollowupService
    {
        Task<IEnumerable<FollowupDto>> GetAllAsync();

        Task<FollowupDto?> GetByIdAsync(int followupId);

        Task<string> InsertAsync(FollowupDto followupDto);

        Task<string> UpdateAsync(FollowupDto followupDto);

        Task<string> DeleteAsync(int followupId);

        Task<string> RestoreAsync(int followupId);
    }

