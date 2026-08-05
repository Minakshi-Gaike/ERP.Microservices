using CollegeLeadService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;



namespace CollegeLeadService.Domain.Interfaces
    {
        public interface ICollegeLeadRepository
        {
            Task<IEnumerable<CollegeLead>> GetAllAsync();

            Task<CollegeLead?> GetByIdAsync(int leadId);

            Task<string> CreateAsync(CollegeLead collegeLead);

            Task<string> UpdateAsync(CollegeLead collegeLead);

            Task<string> DeleteAsync(int leadId);

            Task<string> RestoreAsync(int leadId);
        }
    }

