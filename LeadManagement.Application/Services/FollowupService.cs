using LeadManagement.Application.DTOs;
using LeadManagement.Application.Interfaces;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace LeadManagement.Application.Services
{
    public class FollowupService : IFollowupService
    {
        private readonly IFollowupRepository _followupRepository;
        private readonly ILogger<FollowupService> _logger;

        public FollowupService(
            IFollowupRepository followupRepository,
            ILogger<FollowupService> logger)
        {
            _followupRepository = followupRepository;
            _logger = logger;
        }

        // GET ALL
        public async Task<IEnumerable<FollowupDto>> GetAllAsync()
        {
            _logger.LogInformation("Getting all followups.");

            var followups = await _followupRepository.GetAllAsync();

            return followups.Select(followup => new FollowupDto
            {
                FollowupId = followup.FollowupId,
                LeadId = followup.LeadId,
                StaffId = followup.StaffId,
                Remarks = followup.Remarks,
                NextFollowupDate = followup.NextFollowupDate
            });
        }

        // GET BY ID
        public async Task<FollowupDto?> GetByIdAsync(int followupId)
        {
            _logger.LogInformation(
                "Getting followup with ID {FollowupId}.",
                followupId);

            var followup = await _followupRepository.GetByIdAsync(followupId);

            if (followup == null)
            {
                _logger.LogWarning(
                    "Followup with ID {FollowupId} was not found.",
                    followupId);

                return null;
            }

            return new FollowupDto
            {
                FollowupId = followup.FollowupId,
                LeadId = followup.LeadId,
                StaffId = followup.StaffId,
                Remarks = followup.Remarks,
                NextFollowupDate = followup.NextFollowupDate
            };
        }

        // INSERT
        public async Task<string> InsertAsync(FollowupDto followupDto)
        {
            _logger.LogInformation(
                "Creating followup for Lead ID {LeadId}.",
                followupDto.LeadId);

            // Next follow-up date cannot be in the past.
            // Today and future dates are allowed.
            if (followupDto.NextFollowupDate.Date < DateTime.Today)
            {
                _logger.LogWarning(
                    "Invalid followup date {NextFollowupDate} for Lead ID {LeadId}.",
                    followupDto.NextFollowupDate,
                    followupDto.LeadId);

                throw new ArgumentException(
                    "Next follow-up date cannot be in the past.");
            }

            var followup = new Followup
            {
                LeadId = followupDto.LeadId,
                StaffId = followupDto.StaffId,
                Remarks = followupDto.Remarks,
                NextFollowupDate = followupDto.NextFollowupDate
            };

            var result = await _followupRepository.InsertAsync(followup);

            _logger.LogInformation(
                "Followup for Lead ID {LeadId} created successfully.",
                followupDto.LeadId);

            return result;
        }

        // UPDATE
        public async Task<string> UpdateAsync(FollowupDto followupDto)
        {
            _logger.LogInformation(
                "Updating followup with ID {FollowupId}.",
                followupDto.FollowupId);

            // Next follow-up date cannot be in the past.
            // Today and future dates are allowed.
            if (followupDto.NextFollowupDate.Date < DateTime.Today)
            {
                _logger.LogWarning(
                    "Invalid followup date {NextFollowupDate} for Followup ID {FollowupId}.",
                    followupDto.NextFollowupDate,
                    followupDto.FollowupId);

                throw new ArgumentException(
                    "Next follow-up date cannot be in the past.");
            }

            var followup = new Followup
            {
                FollowupId = followupDto.FollowupId,
                LeadId = followupDto.LeadId,
                StaffId = followupDto.StaffId,
                Remarks = followupDto.Remarks,
                NextFollowupDate = followupDto.NextFollowupDate
            };

            var result = await _followupRepository.UpdateAsync(followup);

            _logger.LogInformation(
                "Followup with ID {FollowupId} updated successfully.",
                followupDto.FollowupId);

            return result;
        }

        // DELETE - SOFT DELETE
        public async Task<string> DeleteAsync(int followupId)
        {
            _logger.LogInformation(
                "Deleting followup with ID {FollowupId}.",
                followupId);

            var result = await _followupRepository.DeleteAsync(followupId);

            _logger.LogInformation(
                "Followup with ID {FollowupId} deleted successfully.",
                followupId);

            return result;
        }

        // RESTORE
        public async Task<string> RestoreAsync(int followupId)
        {
            _logger.LogInformation(
                "Restoring followup with ID {FollowupId}.",
                followupId);

            var result = await _followupRepository.RestoreAsync(followupId);

            _logger.LogInformation(
                "Followup with ID {FollowupId} restored successfully.",
                followupId);

            return result;
        }
    }
}