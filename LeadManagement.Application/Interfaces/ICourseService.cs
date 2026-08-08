using LeadManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace LeadManagement.Application.Interfaces;

    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllAsync();

        Task<CourseDto?> GetByIdAsync(int courseId);

        Task<string> InsertAsync(CourseDto courseDto);

        Task<string> UpdateAsync(CourseDto courseDto);

        Task<string> DeleteAsync(int courseId);

        Task<string> RestoreAsync(int courseId);
    }

