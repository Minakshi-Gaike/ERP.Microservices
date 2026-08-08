using Dapper;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Infrastructure.Context;
using System.Data;

namespace LeadManagement.Infrastructure.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly DapperContext _context;

        public LeadRepository(DapperContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<IEnumerable<Lead>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<Lead>(
                "erpsystem.sp_TblLeads",
                new
                {
                    type = "getall"
                },
                commandType: CommandType.StoredProcedure);
        }


        // GET BY ID
        public async Task<Lead?> GetByIdAsync(int leadId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Lead>(
                "erpsystem.sp_TblLeads",
                new
                {
                    type = "getbyid",
                    LeadId = leadId
                },
                commandType: CommandType.StoredProcedure);
        }


        // INSERT
        public async Task<string> InsertAsync(Lead lead)
        {
            using var connection = _context.CreateConnection();

            var result = await connection.ExecuteScalarAsync<string>(
                "erpsystem.sp_TblLeads",
                new
                {
                    type = "insert",
                    FullName = lead.FullName,
                    EmailId = lead.EmailId,
                    MobileNo = lead.MobileNo,
                    CourseId = lead.CourseId,
                    CourseStatus = lead.CourseStatus,
                    LeadSource = lead.LeadSource
                },
                commandType: CommandType.StoredProcedure);

            return result ?? string.Empty;
        }


        // UPDATE
        public async Task<string> UpdateAsync(Lead lead)
        {
            using var connection = _context.CreateConnection();

            var result = await connection.ExecuteScalarAsync<string>(
                "erpsystem.sp_TblLeads",
                new
                {
                    type = "update",
                    LeadId = lead.LeadId,
                    FullName = lead.FullName,
                    EmailId = lead.EmailId,
                    MobileNo = lead.MobileNo,
                    CourseId = lead.CourseId,
                    CourseStatus = lead.CourseStatus,
                    LeadSource = lead.LeadSource
                },
                commandType: CommandType.StoredProcedure);

            return result ?? string.Empty;
        }


        // DELETE
        public async Task<string> DeleteAsync(int leadId)
        {
            using var connection = _context.CreateConnection();

            var result = await connection.ExecuteScalarAsync<string>(
                "erpsystem.sp_TblLeads",
                new
                {
                    type = "delete",
                    LeadId = leadId
                },
                commandType: CommandType.StoredProcedure);

            return result ?? string.Empty;
        }


        // RESTORE
        public async Task<string> RestoreAsync(int leadId)
        {
            using var connection = _context.CreateConnection();

            var result = await connection.ExecuteScalarAsync<string>(
                "erpsystem.sp_TblLeads",
                new
                {
                    type = "restore",
                    LeadId = leadId
                },
                commandType: CommandType.StoredProcedure);

            return result ?? string.Empty;
        }
    }
}