using EnquiryService.Domain.Entities;
using EnquiryService.Domain.Interfaces;
using EnquiryService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;


namespace EnquiryService.Infrastructure.Repositories
    {
        public class EnquiryForRepository : IEnquiryForRepository
        {
            private readonly DapperContext _context;

            public EnquiryForRepository(DapperContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<EnquiryFor>> GetAllAsync()
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryAsync<EnquiryFor>(
                    @"SELECT
                    enquiry_for_id,
                    enquiry_for AS EnquiryForName,
                    flag,
                    CreatedAt,
                    UpdatedAt,
                    DeletedAt,
                    RestoredAt
                  FROM tblenquiry_for
                  WHERE DeletedAt IS NULL
                  ORDER BY enquiry_for_id DESC");
            }

            public async Task<EnquiryFor?> GetByIdAsync(int enquiryForId)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstOrDefaultAsync<EnquiryFor>(
                    @"SELECT
                    enquiry_for_id,
                    enquiry_for AS EnquiryForName,
                    flag,
                    CreatedAt,
                    UpdatedAt,
                    DeletedAt,
                    RestoredAt
                  FROM tblenquiry_for
                  WHERE enquiry_for_id = @enquiry_for_id
                    AND DeletedAt IS NULL",
                    new { enquiry_for_id = enquiryForId });
            }

            public async Task<string> CreateAsync(EnquiryFor enquiryFor)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstAsync<string>(
                    "sp_tblenquiry_for",
                    new
                    {
                        type = "insert",
                        enquiry_for = enquiryFor.EnquiryForName,
                        flag = enquiryFor.Flag
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<string> UpdateAsync(EnquiryFor enquiryFor)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstAsync<string>(
                    "sp_tblenquiry_for",
                    new
                    {
                        type = "update",
                        enquiry_for_id = enquiryFor.EnquiryForId,
                        enquiry_for = enquiryFor.EnquiryForName,
                        flag = enquiryFor.Flag
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<string> DeleteAsync(int enquiryForId)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstAsync<string>(
                    "sp_tblenquiry_for",
                    new
                    {
                        type = "delete",
                        enquiry_for_id = enquiryForId
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<string> RestoreAsync(int enquiryForId)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstAsync<string>(
                    "sp_tblenquiry_for",
                    new
                    {
                        type = "restore",
                        enquiry_for_id = enquiryForId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }

