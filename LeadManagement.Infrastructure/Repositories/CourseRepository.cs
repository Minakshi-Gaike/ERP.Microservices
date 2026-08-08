using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;



namespace LeadManagement.Infrastructure.Repositories
    {
        public class CourseRepository : ICourseRepository
        {
            private readonly DapperContext _context;

            public CourseRepository(DapperContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Course>> GetAllAsync()
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryAsync<Course>(
                    "erpsystem.sp_TblCourses",
                    new
                    {
                        @type = "getall"
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<Course?> GetByIdAsync(int courseId)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstOrDefaultAsync<Course>(
                    "erpsystem.sp_TblCourses",
                    new
                    {
                        @type = "getbyid",
                        @CourseId = courseId
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<string> InsertAsync(Course course)
            {
                using var connection = _context.CreateConnection();

                return await connection.ExecuteScalarAsync<string>(
                    "erpsystem.sp_TblCourses",
                    new
                    {
                        @type = "insert",
                        @CourseName = course.CourseName,
                        @CourseDuration = course.CourseDuration,
                        @CourseFees = course.CourseFees,
                        @IsActive = course.IsActive
                    },
                    commandType: CommandType.StoredProcedure) ?? string.Empty; ;
            }

            public async Task<string> UpdateAsync(Course course)
            {
                using var connection = _context.CreateConnection();

                return await connection.ExecuteScalarAsync<string>(
                    "erpsystem.sp_TblCourses",
                    new
                    {
                        @type = "update",
                        @CourseId = course.CourseId,
                        @CourseName = course.CourseName,
                        @CourseDuration = course.CourseDuration,
                        @CourseFees = course.CourseFees,
                        @IsActive = course.IsActive
                    },
                    commandType: CommandType.StoredProcedure) ?? string.Empty; ;
            }

            public async Task<string> DeleteAsync(int courseId)
            {
                using var connection = _context.CreateConnection();

                return await connection.ExecuteScalarAsync<string>(
                    "erpsystem.sp_TblCourses",
                    new
                    {
                        @type = "delete",
                        @CourseId = courseId
                    },
                    commandType: CommandType.StoredProcedure) ?? string.Empty; ;
            }

            public async Task<string> RestoreAsync(int courseId)
            {
                using var connection = _context.CreateConnection();

                return await connection.ExecuteScalarAsync<string>(
                    "erpsystem.sp_TblCourses",
                    new
                    {
                        @type = "restore",
                        @CourseId = courseId
                    },
                    commandType: CommandType.StoredProcedure) ?? string.Empty; ;
            }
        }
    }

