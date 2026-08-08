using LeadManagement.Application.DTOs;
using LeadManagement.Application.Interfaces;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace LeadManagement.Application.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly ILogger<LeadService> _logger;

        public LeadService(
            ILeadRepository leadRepository,
            ILogger<LeadService> logger)
        {
            _leadRepository = leadRepository;
            _logger = logger;
        }

        // GET ALL
        public async Task<IEnumerable<LeadDto>> GetAllAsync()
        {
            _logger.LogInformation("Getting all leads.");

            var leads = await _leadRepository.GetAllAsync();

            return leads.Select(lead => new LeadDto
            {
                LeadId = lead.LeadId,
                FullName = lead.FullName,
                EmailId = lead.EmailId,
                MobileNo = lead.MobileNo,
                CourseId = lead.CourseId,
                CourseStatus = lead.CourseStatus,
                LeadSource = lead.LeadSource
            });
        }

        // GET BY ID
        public async Task<LeadDto?> GetByIdAsync(int leadId)
        {
            _logger.LogInformation(
                "Getting lead with ID {LeadId}.",
                leadId);

            var lead = await _leadRepository.GetByIdAsync(leadId);

            if (lead == null)
            {
                _logger.LogWarning(
                    "Lead with ID {LeadId} was not found.",
                    leadId);

                return null;
            }

            return new LeadDto
            {
                LeadId = lead.LeadId,
                FullName = lead.FullName,
                EmailId = lead.EmailId,
                MobileNo = lead.MobileNo,
                CourseId = lead.CourseId,
                CourseStatus = lead.CourseStatus,
                LeadSource = lead.LeadSource
            };
        }

        // INSERT
        public async Task<string> InsertAsync(LeadDto leadDto)
        {
            _logger.LogInformation(
                "Creating new lead for {FullName}.",
                leadDto.FullName);

            var lead = new Lead
            {
                FullName = leadDto.FullName,
                EmailId = leadDto.EmailId,
                MobileNo = leadDto.MobileNo,
                CourseId = leadDto.CourseId,
                CourseStatus = leadDto.CourseStatus,
                LeadSource = leadDto.LeadSource
            };

            var result = await _leadRepository.InsertAsync(lead);

            _logger.LogInformation(
                "Lead for {FullName} created successfully.",
                leadDto.FullName);

            return result;
        }

        // UPDATE
        public async Task<string> UpdateAsync(LeadDto leadDto)
        {
            _logger.LogInformation(
                "Updating lead with ID {LeadId}.",
                leadDto.LeadId);

            var lead = new Lead
            {
                LeadId = leadDto.LeadId,
                FullName = leadDto.FullName,
                EmailId = leadDto.EmailId,
                MobileNo = leadDto.MobileNo,
                CourseId = leadDto.CourseId,
                CourseStatus = leadDto.CourseStatus,
                LeadSource = leadDto.LeadSource
            };

            var result = await _leadRepository.UpdateAsync(lead);

            _logger.LogInformation(
                "Lead with ID {LeadId} updated successfully.",
                leadDto.LeadId);

            return result;
        }

        // DELETE - SOFT DELETE
        public async Task<string> DeleteAsync(int leadId)
        {
            _logger.LogInformation(
                "Deleting lead with ID {LeadId}.",
                leadId);

            var result = await _leadRepository.DeleteAsync(leadId);

            _logger.LogInformation(
                "Lead with ID {LeadId} deleted successfully.",
                leadId);

            return result;
        }

        // RESTORE
        public async Task<string> RestoreAsync(int leadId)
        {
            _logger.LogInformation(
                "Restoring lead with ID {LeadId}.",
                leadId);

            var result = await _leadRepository.RestoreAsync(leadId);

            _logger.LogInformation(
                "Lead with ID {LeadId} restored successfully.",
                leadId);

            return result;
        }
    }
}