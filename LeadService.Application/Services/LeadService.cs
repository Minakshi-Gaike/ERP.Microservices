using LeadService.Application.DTOs.Lead;
using LeadService.Application.Interfaces;
using LeadService.Domain.Entities;
using LeadService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;



namespace LeadService.Application.Services;

    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _repository;

        public LeadService(ILeadRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LeadDto>> GetAllAsync()
        {
            var leads = await _repository.GetAllAsync();

            return leads.Select(l => new LeadDto
            {
                LeadId = l.LeadId,
                CandidateName = l.CandidateName,
                EmailAddress = l.EmailAddress,
                MobileNumber = l.MobileNumber,
                TrainingType = l.TrainingType,
                Description = l.Description,
                LeadDate = l.LeadDate
            });
        }

        public async Task<LeadDto?> GetByIdAsync(int leadId)
        {
            var lead = await _repository.GetByIdAsync(leadId);

            if (lead == null)
                return null;

            return new LeadDto
            {
                LeadId = lead.LeadId,
                CandidateName = lead.CandidateName,
                EmailAddress = lead.EmailAddress,
                MobileNumber = lead.MobileNumber,
                TrainingType = lead.TrainingType,
                Description = lead.Description,
                LeadDate = lead.LeadDate
            };
        }

        public async Task<string> CreateAsync(CreateLeadDto dto)
        {
            var lead = new Lead
            {
                CandidateName = dto.CandidateName,
                EmailAddress = dto.EmailAddress,
                MobileNumber = dto.MobileNumber,
                TrainingType = dto.TrainingType,
                Description = dto.Description,
                LeadDate = dto.LeadDate
            };

            return await _repository.CreateAsync(lead);
        }

        public async Task<string> UpdateAsync(UpdateLeadDto dto)
        {
            var lead = new Lead
            {
                LeadId = dto.LeadId,
                CandidateName = dto.CandidateName,
                EmailAddress = dto.EmailAddress,
                MobileNumber = dto.MobileNumber,
                TrainingType = dto.TrainingType,
                Description = dto.Description,
                LeadDate = dto.LeadDate
            };

            return await _repository.UpdateAsync(lead);
        }

        public async Task<string> DeleteAsync(int leadId)
        {
            return await _repository.DeleteAsync(leadId);
        }

        public async Task<string> RestoreAsync(int leadId)
        {
            return await _repository.RestoreAsync(leadId);
        }
    }

