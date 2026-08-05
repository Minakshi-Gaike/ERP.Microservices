using EnquiryService.Application.DTOs.EnquiryFollowUp;
using EnquiryService.Application.Interfaces;
using EnquiryService.Domain.Entities;
using EnquiryService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;



namespace EnquiryService.Application.Services
    {
        public class EnquiryFollowUpService : IEnquiryFollowUpService
        {
            private readonly IEnquiryFollowUpRepository _repository;

            public EnquiryFollowUpService(IEnquiryFollowUpRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<EnquiryFollowUpDto>> GetAllAsync()
            {
                var followUps = await _repository.GetAllAsync();

                return followUps.Select(f => new EnquiryFollowUpDto
                {
                    FollowUpId = f.FollowUpId,
                    EnquiryId = f.EnquiryId,
                    FollowUpDate = f.FollowUpDate,
                    FollowUpBy = f.FollowUpBy,
                    Description = f.Description
                });
            }

            public async Task<EnquiryFollowUpDto?> GetByIdAsync(int followUpId)
            {
                var followUp = await _repository.GetByIdAsync(followUpId);

                if (followUp == null)
                    return null;

                return new EnquiryFollowUpDto
                {
                    FollowUpId = followUp.FollowUpId,
                    EnquiryId = followUp.EnquiryId,
                    FollowUpDate = followUp.FollowUpDate,
                    FollowUpBy = followUp.FollowUpBy,
                    Description = followUp.Description
                };
            }

            public async Task<string> CreateAsync(CreateEnquiryFollowUpDto dto)
            {
                var followUp = new EnquiryFollowUp
                {
                    EnquiryId = dto.EnquiryId,
                    FollowUpDate = dto.FollowUpDate,
                    FollowUpBy = dto.FollowUpBy,
                    Description = dto.Description
                };

                return await _repository.CreateAsync(followUp);
            }

            public async Task<string> UpdateAsync(UpdateEnquiryFollowUpDto dto)
            {
                var followUp = new EnquiryFollowUp
                {
                    FollowUpId = dto.FollowUpId,
                    EnquiryId = dto.EnquiryId,
                    FollowUpDate = dto.FollowUpDate,
                    FollowUpBy = dto.FollowUpBy,
                    Description = dto.Description
                };

                return await _repository.UpdateAsync(followUp);
            }

            public async Task<string> DeleteAsync(int followUpId)
            {
                return await _repository.DeleteAsync(followUpId);
            }

            public async Task<string> RestoreAsync(int followUpId)
            {
                return await _repository.RestoreAsync(followUpId);
            }
        }
    }

