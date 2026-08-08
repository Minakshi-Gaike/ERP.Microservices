using LeadManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;



namespace LeadManagement.Domain.Interfaces;

    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAllAsync();

        Task<Staff?> GetByIdAsync(int staffId);

        Task<string> InsertAsync(Staff staff);

        Task<string> UpdateAsync(Staff staff);

        Task<string> DeleteAsync(int staffId);

        Task<string> RestoreAsync(int staffId);
    }

