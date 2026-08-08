using LeadManagement.Application.DTOs;
using LeadManagement.Application.Interfaces;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace LeadManagement.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly ILogger<StaffService> _logger;

        public StaffService(
            IStaffRepository staffRepository,
            ILogger<StaffService> logger)
        {
            _staffRepository = staffRepository;
            _logger = logger;
        }

        // GET ALL
        public async Task<IEnumerable<StaffDto>> GetAllAsync()
        {
            _logger.LogInformation("Getting all staff members.");

            var staffList = await _staffRepository.GetAllAsync();

            return staffList.Select(staff => new StaffDto
            {
                StaffId = staff.StaffId,
                StaffName = staff.StaffName,
                EmailId = staff.EmailId,
                MobileNo = staff.MobileNo,
                Designation = staff.Designation,
                IsActive = staff.IsActive
            });
        }

        // GET BY ID
        public async Task<StaffDto?> GetByIdAsync(int staffId)
        {
            _logger.LogInformation(
                "Getting staff member with ID {StaffId}.",
                staffId);

            var staff = await _staffRepository.GetByIdAsync(staffId);

            if (staff == null)
            {
                _logger.LogWarning(
                    "Staff member with ID {StaffId} was not found.",
                    staffId);

                return null;
            }

            return new StaffDto
            {
                StaffId = staff.StaffId,
                StaffName = staff.StaffName,
                EmailId = staff.EmailId,
                MobileNo = staff.MobileNo,
                Designation = staff.Designation,
                IsActive = staff.IsActive
            };
        }

        // INSERT
        public async Task<string> InsertAsync(StaffDto staffDto)
        {
            _logger.LogInformation(
                "Creating new staff member {StaffName}.",
                staffDto.StaffName);

            var staff = new Staff
            {
                StaffName = staffDto.StaffName,
                EmailId = staffDto.EmailId,
                MobileNo = staffDto.MobileNo,
                Designation = staffDto.Designation,
                IsActive = staffDto.IsActive
            };

            var result = await _staffRepository.InsertAsync(staff);

            _logger.LogInformation(
                "Staff member {StaffName} created successfully.",
                staffDto.StaffName);

            return result;
        }

        // UPDATE
        public async Task<string> UpdateAsync(StaffDto staffDto)
        {
            _logger.LogInformation(
                "Updating staff member with ID {StaffId}.",
                staffDto.StaffId);

            var staff = new Staff
            {
                StaffId = staffDto.StaffId,
                StaffName = staffDto.StaffName,
                EmailId = staffDto.EmailId,
                MobileNo = staffDto.MobileNo,
                Designation = staffDto.Designation,
                IsActive = staffDto.IsActive
            };

            var result = await _staffRepository.UpdateAsync(staff);

            _logger.LogInformation(
                "Staff member with ID {StaffId} updated successfully.",
                staffDto.StaffId);

            return result;
        }

        // DELETE - SOFT DELETE
        public async Task<string> DeleteAsync(int staffId)
        {
            _logger.LogInformation(
                "Deleting staff member with ID {StaffId}.",
                staffId);

            var result = await _staffRepository.DeleteAsync(staffId);

            _logger.LogInformation(
                "Staff member with ID {StaffId} deleted successfully.",
                staffId);

            return result;
        }

        // RESTORE
        public async Task<string> RestoreAsync(int staffId)
        {
            _logger.LogInformation(
                "Restoring staff member with ID {StaffId}.",
                staffId);

            var result = await _staffRepository.RestoreAsync(staffId);

            _logger.LogInformation(
                "Staff member with ID {StaffId} restored successfully.",
                staffId);

            return result;
        }
    }
}