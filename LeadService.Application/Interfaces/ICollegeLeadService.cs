using CollegeLeadService.Application.DTOs.CollegeLead;
using System;
using System.Collections.Generic;
using System.Text;


namespace CollegeLeadService.Application.Interfaces
    {
        public interface ICollegeLeadService
        {
            Task<IEnumerable<CollegeLeadDto>> GetAllAsync();

            Task<CollegeLeadDto?> GetByIdAsync(int leadId);

            Task<string> CreateAsync(CreateCollegeLeadDto dto);

            Task<string> UpdateAsync(UpdateCollegeLeadDto dto);

            Task<string> DeleteAsync(int leadId);

            Task<string> RestoreAsync(int leadId);
        }
    }

