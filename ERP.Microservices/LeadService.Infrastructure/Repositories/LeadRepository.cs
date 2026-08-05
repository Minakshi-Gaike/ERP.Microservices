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
   

    public class LeadRepository : ILeadRepository
    {
        private readonly DapperContext _context;

        public LeadRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lead>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<Lead>(
                "sp_tblleads",
                new
                {
                    type = "getall"
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Lead?> GetByIdAsync(int leadId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Lead>(
                "sp_tblleads",
                new
                {
                    type = "getbyid",
                    lead_id = leadId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> CreateAsync(Lead lead)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstAsync<string>(
                "sp_tblleads",
                new
                {
                    type = "insert",
                    candidate_name = lead.CandidateName,
                    email_address = lead.EmailAddress,
                    mobile_number = lead.MobileNumber,
                    training_type = lead.TrainingType,
                    description = lead.Description,
                    lead_date = lead.LeadDate
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> UpdateAsync(Lead lead)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstAsync<string>(
                "sp_tblleads",
                new
                {
                    type = "update",
                    lead_id = lead.LeadId,
                    candidate_name = lead.CandidateName,
                    email_address = lead.EmailAddress,
                    mobile_number = lead.MobileNumber,
                    training_type = lead.TrainingType,
                    description = lead.Description,
                    lead_date = lead.LeadDate
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> DeleteAsync(int leadId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstAsync<string>(
                "sp_tblleads",
                new
                {
                    type = "delete",
                    lead_id = leadId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> RestoreAsync(int leadId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstAsync<string>(
                "sp_tblleads",
                new
                {
                    type = "restore",
                    lead_id = leadId
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}

