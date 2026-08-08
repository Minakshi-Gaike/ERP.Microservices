using LeadManagement.Application.DTOs;
using LeadManagement.Application.Interfaces;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace LeadManagement.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<CourseService> _logger;

        public CourseService(
            ICourseRepository courseRepository,
            ILogger<CourseService> logger)
        {
            _courseRepository = courseRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            _logger.LogInformation("Getting all courses.");

            var courses = await _courseRepository.GetAllAsync();

            return courses.Select(course => new CourseDto
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CourseDuration = course.CourseDuration,
                CourseFees = course.CourseFees,
                IsActive = course.IsActive
            });
        }

        public async Task<CourseDto?> GetByIdAsync(int courseId)
        {
            _logger.LogInformation(
                "Getting course with ID {CourseId}.",
                courseId);

            var course = await _courseRepository.GetByIdAsync(courseId);

            if (course == null)
            {
                _logger.LogWarning(
                    "Course with ID {CourseId} was not found.",
                    courseId);

                return null;
            }

            return new CourseDto
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CourseDuration = course.CourseDuration,
                CourseFees = course.CourseFees,
                IsActive = course.IsActive
            };
        }

        public async Task<string> InsertAsync(CourseDto courseDto)
        {
            _logger.LogInformation(
                "Creating course {CourseName}.",
                courseDto.CourseName);

            var course = new Course
            {
                CourseName = courseDto.CourseName,
                CourseDuration = courseDto.CourseDuration,
                CourseFees = courseDto.CourseFees,
                IsActive = courseDto.IsActive
            };

            var result = await _courseRepository.InsertAsync(course);

            _logger.LogInformation(
                "Course {CourseName} created successfully.",
                courseDto.CourseName);

            return result;
        }

        public async Task<string> UpdateAsync(CourseDto courseDto)
        {
            _logger.LogInformation(
                "Updating course with ID {CourseId}.",
                courseDto.CourseId);

            var course = new Course
            {
                CourseId = courseDto.CourseId,
                CourseName = courseDto.CourseName,
                CourseDuration = courseDto.CourseDuration,
                CourseFees = courseDto.CourseFees,
                IsActive = courseDto.IsActive
            };

            var result = await _courseRepository.UpdateAsync(course);

            _logger.LogInformation(
                "Course with ID {CourseId} updated successfully.",
                courseDto.CourseId);

            return result;
        }

        public async Task<string> DeleteAsync(int courseId)
        {
            _logger.LogInformation(
                "Deleting course with ID {CourseId}.",
                courseId);

            var result = await _courseRepository.DeleteAsync(courseId);

            _logger.LogInformation(
                "Course with ID {CourseId} deleted successfully.",
                courseId);

            return result;
        }

        public async Task<string> RestoreAsync(int courseId)
        {
            _logger.LogInformation(
                "Restoring course with ID {CourseId}.",
                courseId);

            var result = await _courseRepository.RestoreAsync(courseId);

            _logger.LogInformation(
                "Course with ID {CourseId} restored successfully.",
                courseId);

            return result;
        }
    }
}