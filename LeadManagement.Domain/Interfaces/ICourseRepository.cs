using LeadManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;



namespace LeadManagement.Domain.Interfaces;

    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();

        Task<Course?> GetByIdAsync(int courseId);

        Task<string> InsertAsync(Course course);

        Task<string> UpdateAsync(Course course);

        Task<string> DeleteAsync(int courseId);

        Task<string> RestoreAsync(int courseId);
    }

