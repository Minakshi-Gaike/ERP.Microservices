using LeadService.Domain.Entities;
using LeadService.Domain.Interfaces;
using LeadService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;


namespace LeadService.Infrastructure.Repositories
    {
        public class LeadSourceRepository : ILeadSourceRepository
        {
            private readonly DapperContext _context;

            public LeadSourceRepository(DapperContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<LeadSource>> GetAllAsync()
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryAsync<LeadSource>(
                    "sp_tbllead_sources",
                    new
                    {
                        type = "getall"
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<LeadSource?> GetByIdAsync(int sourceId)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstOrDefaultAsync<LeadSource>(
                    "sp_tbllead_sources",
                    new
                    {
                        type = "getbyid",
                        source_id = sourceId
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<string> CreateAsync(LeadSource leadSource)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstAsync<string>(
                    "sp_tbllead_sources",
                    new
                    {
                        type = "insert",
                        source_name = leadSource.SourceName,
                        flag = leadSource.Flag
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<string> UpdateAsync(LeadSource leadSource)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstAsync<string>(
                    "sp_tbllead_sources",
                    new
                    {
                        type = "update",
                        source_id = leadSource.SourceId,
                        source_name = leadSource.SourceName,
                        flag = leadSource.Flag
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<string> DeleteAsync(int sourceId)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstAsync<string>(
                    "sp_tbllead_sources",
                    new
                    {
                        type = "delete",
                        source_id = sourceId
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<string> RestoreAsync(int sourceId)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstAsync<string>(
                    "sp_tbllead_sources",
                    new
                    {
                        type = "restore",
                        source_id = sourceId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }

