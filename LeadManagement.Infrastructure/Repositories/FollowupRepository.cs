using Dapper;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Infrastructure.Context;
using System.Data;

namespace LeadManagement.Infrastructure.Repositories
{
    public class FollowupRepository : IFollowupRepository
    {
        private readonly DapperContext _context;

        public FollowupRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Followup>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<Followup>(
                "erpsystem.sp_TblFollowups",
                new
                {
                    @type = "getall"
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Followup?> GetByIdAsync(int followupId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Followup>(
                "erpsystem.sp_TblFollowups",
                new
                {
                    @type = "getbyid",
                    @FollowupId = followupId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> InsertAsync(Followup followup)
        {
            using var connection = _context.CreateConnection();

            return await connection.ExecuteScalarAsync<string>(
                "erpsystem.sp_TblFollowups",
                new
                {
                    @type = "insert",
                    @LeadId = followup.LeadId,
                    @StaffId = followup.StaffId,
                    @Remarks = followup.Remarks,
                    @NextFollowupDate = followup.NextFollowupDate
                },
                commandType: CommandType.StoredProcedure) ?? string.Empty; ;
        }

        public async Task<string> UpdateAsync(Followup followup)
        {
            using var connection = _context.CreateConnection();

            return await connection.ExecuteScalarAsync<string>(
                "erpsystem.sp_TblFollowups",
                new
                {
                    @type = "update",
                    @FollowupId = followup.FollowupId,
                    @LeadId = followup.LeadId,
                    @StaffId = followup.StaffId,
                    @Remarks = followup.Remarks,
                    @NextFollowupDate = followup.NextFollowupDate
                },
                commandType: CommandType.StoredProcedure) ?? string.Empty; ;
        }

        public async Task<string> DeleteAsync(int followupId)
        {
            using var connection = _context.CreateConnection();

            return await connection.ExecuteScalarAsync<string>(
                "erpsystem.sp_TblFollowups",
                new
                {
                    @type = "delete",
                    @FollowupId = followupId
                },
                commandType: CommandType.StoredProcedure) ?? string.Empty; ;
        }

        public async Task<string> RestoreAsync(int followupId)
        {
            using var connection = _context.CreateConnection();

            return await connection.ExecuteScalarAsync<string>(
                "erpsystem.sp_TblFollowups",
                new
                {
                    @type = "restore",
                    @FollowupId = followupId
                },
                commandType: CommandType.StoredProcedure) ?? string.Empty; ;
        }
    }
}