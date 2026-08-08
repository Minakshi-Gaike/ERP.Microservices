using Dapper;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Infrastructure.Context;
using System.Data;

namespace LeadManagement.Infrastructure.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DapperContext _context;

        public StaffRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<Staff>(
                "erpsystem.sp_TblStaff",
                new
                {
                    @type = "getall"
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Staff?> GetByIdAsync(int staffId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Staff>(
                "erpsystem.sp_TblStaff",
                new
                {
                    @type = "getbyid",
                    @StaffId = staffId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> InsertAsync(Staff staff)
        {
            using var connection = _context.CreateConnection();

            return await connection.ExecuteScalarAsync<string>(
                "erpsystem.sp_TblStaff",
                new
                {
                    @type = "insert",
                    @StaffName = staff.StaffName,
                    @EmailId = staff.EmailId,
                    @MobileNo = staff.MobileNo,
                    @Designation = staff.Designation,
                    @IsActive = staff.IsActive
                },
                commandType: CommandType.StoredProcedure) ?? string.Empty; ;
        }

        public async Task<string> UpdateAsync(Staff staff)
        {
            using var connection = _context.CreateConnection();

            return await connection.ExecuteScalarAsync<string>(
                "erpsystem.sp_TblStaff",
                new
                {
                    @type = "update",
                    @StaffId = staff.StaffId,
                    @StaffName = staff.StaffName,
                    @EmailId = staff.EmailId,
                    @MobileNo = staff.MobileNo,
                    @Designation = staff.Designation,
                    @IsActive = staff.IsActive
                },
                commandType: CommandType.StoredProcedure) ?? string.Empty; ;
        }

        public async Task<string> DeleteAsync(int staffId)
        {
            using var connection = _context.CreateConnection();

            return await connection.ExecuteScalarAsync<string>(
                "erpsystem.sp_TblStaff",
                new
                {
                    @type = "delete",
                    @StaffId = staffId
                },
                commandType: CommandType.StoredProcedure) ?? string.Empty; ;
        }

        public async Task<string> RestoreAsync(int staffId)
        {
            using var connection = _context.CreateConnection();

            return await connection.ExecuteScalarAsync<string>(
                "erpsystem.sp_TblStaff",
                new
                {
                    @type = "restore",
                    @StaffId = staffId
                },
                commandType: CommandType.StoredProcedure) ?? string.Empty; ;
        }
    }
}