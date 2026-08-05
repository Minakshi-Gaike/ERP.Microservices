using LeadService.Application.DTOs.LeadSource;
using System;
using System.Collections.Generic;
using System.Text;



namespace LeadService.Application.Interfaces
    {
        public interface ILeadSourceService
        {
            Task<IEnumerable<LeadSourceDto>> GetAllAsync();

            Task<LeadSourceDto?> GetByIdAsync(int sourceId);

            Task<string> CreateAsync(CreateLeadSourceDto dto);

            Task<string> UpdateAsync(UpdateLeadSourceDto dto);

            Task<string> DeleteAsync(int sourceId);

            Task<string> RestoreAsync(int sourceId);
        }
    }

