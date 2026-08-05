using CollegeLeadService.Application.DTOs.CollegeLead;
using CollegeLeadService.Application.Interfaces;
using CollegeLeadService.Domain.Entities;
using CollegeLeadService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace CollegeLeadService.Application.Services
    {
        public class CollegeLeadService : ICollegeLeadService
        {
            private readonly ICollegeLeadRepository _repository;

            public CollegeLeadService(ICollegeLeadRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<CollegeLeadDto>> GetAllAsync()
            {
                var collegeLeads = await _repository.GetAllAsync();

                return collegeLeads.Select(c => new CollegeLeadDto
                {
                    LeadId = c.LeadId,
                    Qualification = c.Qualification,
                    CollegeName = c.CollegeName,
                    StudentName = c.StudentName,
                    MotherName = c.MotherName,
                    EmailAddress = c.EmailAddress,
                    MobileNumber = c.MobileNumber,
                    Gender = c.Gender,
                    Address = c.Address,
                    State = c.State,
                    City = c.City,
                    PinCode = c.PinCode
                });
            }

            public async Task<CollegeLeadDto?> GetByIdAsync(int leadId)
            {
                var collegeLead = await _repository.GetByIdAsync(leadId);

                if (collegeLead == null)
                    return null;

                return new CollegeLeadDto
                {
                    LeadId = collegeLead.LeadId,
                    Qualification = collegeLead.Qualification,
                    CollegeName = collegeLead.CollegeName,
                    StudentName = collegeLead.StudentName,
                    MotherName = collegeLead.MotherName,
                    EmailAddress = collegeLead.EmailAddress,
                    MobileNumber = collegeLead.MobileNumber,
                    Gender = collegeLead.Gender,
                    Address = collegeLead.Address,
                    State = collegeLead.State,
                    City = collegeLead.City,
                    PinCode = collegeLead.PinCode
                };
            }

            public async Task<string> CreateAsync(CreateCollegeLeadDto dto)
            {
                var collegeLead = new CollegeLead
                {
                    Qualification = dto.Qualification,
                    CollegeName = dto.CollegeName,
                    StudentName = dto.StudentName,
                    MotherName = dto.MotherName,
                    EmailAddress = dto.EmailAddress,
                    MobileNumber = dto.MobileNumber,
                    Gender = dto.Gender,
                    Address = dto.Address,
                    State = dto.State,
                    City = dto.City,
                    PinCode = dto.PinCode
                };

                return await _repository.CreateAsync(collegeLead);
            }

            public async Task<string> UpdateAsync(UpdateCollegeLeadDto dto)
            {
                var collegeLead = new CollegeLead
                {
                    LeadId = dto.LeadId,
                    Qualification = dto.Qualification,
                    CollegeName = dto.CollegeName,
                    StudentName = dto.StudentName,
                    MotherName = dto.MotherName,
                    EmailAddress = dto.EmailAddress,
                    MobileNumber = dto.MobileNumber,
                    Gender = dto.Gender,
                    Address = dto.Address,
                    State = dto.State,
                    City = dto.City,
                    PinCode = dto.PinCode
                };

                return await _repository.UpdateAsync(collegeLead);
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
    }

