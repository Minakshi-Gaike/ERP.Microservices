using EnquiryService.Application.DTOs;
using EnquiryService.Application.DTOs.EnquiryFor;
using EnquiryService.Application.Interfaces;
using EnquiryService.Domain.Entities;
using EnquiryService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;





namespace EnquiryService.Application.Services
    {
        public class EnquiryForService : IEnquiryForService
        {
            private readonly IEnquiryForRepository _repository;

            public EnquiryForService(IEnquiryForRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<EnquiryForDto>> GetAllAsync()
            {
                var enquiryForList = await _repository.GetAllAsync();

                return enquiryForList.Select(e => new EnquiryForDto
                {
                    EnquiryForId = e.EnquiryForId,
                    EnquiryFor = e.EnquiryForName,
                    Flag = e.Flag
                });
            }

            public async Task<EnquiryForDto?> GetByIdAsync(int enquiryForId)
            {
                var enquiryFor = await _repository.GetByIdAsync(enquiryForId);

                if (enquiryFor == null)
                    return null;

                return new EnquiryForDto
                {
                    EnquiryForId = enquiryFor.EnquiryForId,
                    EnquiryFor = enquiryFor.EnquiryForName,
                    Flag = enquiryFor.Flag
                };
            }

            public async Task<string> CreateAsync(CreateEnquiryForDto dto)
            {
                var enquiryFor = new EnquiryFor
                {
                    EnquiryForName = dto.EnquiryFor,
                    Flag = dto.Flag
                };

                return await _repository.CreateAsync(enquiryFor);
            }

            public async Task<string> UpdateAsync(UpdateEnquiryForDto dto)
            {
                var enquiryFor = new EnquiryFor
                {
                    EnquiryForId = dto.EnquiryForId,
                    EnquiryForName = dto.EnquiryFor,
                    Flag = dto.Flag
                };

                return await _repository.UpdateAsync(enquiryFor);
            }

            public async Task<string> DeleteAsync(int enquiryForId)
            {
                return await _repository.DeleteAsync(enquiryForId);
            }

            public async Task<string> RestoreAsync(int enquiryForId)
            {
                return await _repository.RestoreAsync(enquiryForId);
            }
        }
    }

