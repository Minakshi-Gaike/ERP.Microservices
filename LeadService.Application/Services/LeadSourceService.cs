using LeadService.Application.DTOs.LeadSource;
using LeadService.Application.Interfaces;
using LeadService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using LeadService.Domain.Interfaces;



namespace LeadService.Application.Services
    {
        public class LeadSourceService : ILeadSourceService
        {
            private readonly ILeadSourceRepository _repository;

            public LeadSourceService(ILeadSourceRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<LeadSourceDto>> GetAllAsync()
            {
                var leadSources = await _repository.GetAllAsync();

                return leadSources.Select(ls => new LeadSourceDto
                {
                    SourceId = ls.SourceId,
                    SourceName = ls.SourceName,
                    Flag = ls.Flag
                });
            }

            public async Task<LeadSourceDto?> GetByIdAsync(int sourceId)
            {
                var leadSource = await _repository.GetByIdAsync(sourceId);

                if (leadSource == null)
                    return null;

                return new LeadSourceDto
                {
                    SourceId = leadSource.SourceId,
                    SourceName = leadSource.SourceName,
                    Flag = leadSource.Flag
                };
            }

            public async Task<string> CreateAsync(CreateLeadSourceDto dto)
            {
                var leadSource = new LeadSource
                {
                    SourceName = dto.SourceName,
                    Flag = dto.Flag
                };

                return await _repository.CreateAsync(leadSource);
            }

            public async Task<string> UpdateAsync(UpdateLeadSourceDto dto)
            {
                var leadSource = new LeadSource
                {
                    SourceId = dto.SourceId,
                    SourceName = dto.SourceName,
                    Flag = dto.Flag
                };

                return await _repository.UpdateAsync(leadSource);
            }

            public async Task<string> DeleteAsync(int sourceId)
            {
                return await _repository.DeleteAsync(sourceId);
            }

            public async Task<string> RestoreAsync(int sourceId)
            {
                return await _repository.RestoreAsync(sourceId);
            }
        }
    }

