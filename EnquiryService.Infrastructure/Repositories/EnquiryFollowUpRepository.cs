using Dapper;
using EnquiryService.Domain.Entities;
using EnquiryService.Domain.Interfaces;
using EnquiryService.Infrastructure.Data;
using System.Data;

namespace EnquiryService.Infrastructure.Repositories
{
    public class EnquiryFollowUpRepository : IEnquiryFollowUpRepository
    {
        private readonly DapperContext _context;

        public EnquiryFollowUpRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EnquiryFollowUp>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<EnquiryFollowUp>(
                "sp_tblenquiry_followups",
                new
                {
                    type = "getall"
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<EnquiryFollowUp?> GetByIdAsync(int followUpId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<EnquiryFollowUp>(
                "sp_tblenquiry_followups",
                new
                {
                    type = "getbyid",
                    followup_id = followUpId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> CreateAsync(EnquiryFollowUp followUp)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstAsync<string>(
                "sp_tblenquiry_followups",
                new
                {
                    type = "insert",
                    enquiry_id = followUp.EnquiryId,
                    follow_up_date = followUp.FollowUpDate,
                    follow_up_by = followUp.FollowUpBy,
                    description = followUp.Description
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> UpdateAsync(EnquiryFollowUp followUp)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstAsync<string>(
                "sp_tblenquiry_followups",
                new
                {
                    type = "update",
                    followup_id = followUp.FollowUpId,
                    enquiry_id = followUp.EnquiryId,
                    follow_up_date = followUp.FollowUpDate,
                    follow_up_by = followUp.FollowUpBy,
                    description = followUp.Description
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> DeleteAsync(int followUpId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstAsync<string>(
                "sp_tblenquiry_followups",
                new
                {
                    type = "delete",
                    followup_id = followUpId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> RestoreAsync(int followUpId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstAsync<string>(
                "sp_tblenquiry_followups",
                new
                {
                    type = "restore",
                    followup_id = followUpId
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}