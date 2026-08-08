using LeadManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;



namespace LeadManagement.Application.Interfaces;

    public interface IStaffService
    {
        Task<IEnumerable<StaffDto>> GetAllAsync();

        Task<StaffDto?> GetByIdAsync(int staffId);

        Task<string> InsertAsync(StaffDto staffDto);

        Task<string> UpdateAsync(StaffDto staffDto);

        Task<string> DeleteAsync(int staffId);

        Task<string> RestoreAsync(int staffId);
    }

