using EnquiryService.Application.DTOs;
using EnquiryService.Application.Interfaces;
using EnquiryService.Domain.Entities;
using EnquiryService.Domain.Interfaces;


namespace EnquiryService.Application.Services;


public class EnquiryService : IEnquiryService
{
    private readonly IEnquiryRepository _repository;

    public EnquiryService(IEnquiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EnquiryDto>> GetAllAsync()
    {
        var enquiries = await _repository.GetAllAsync();

        return enquiries.Select(e => new EnquiryDto
        {
            EnquiryId = e.EnquiryId,
            EnquiryDate = e.EnquiryDate,
            CandidateName = e.CandidateName,
            Gender = e.Gender,
            LocalAddress = e.LocalAddress,
            EmailAddress = e.EmailAddress,
            MobileNumber = e.MobileNumber,
            BirthDate = e.BirthDate,
            Qualification = e.Qualification,
            LeadSources = e.LeadSources,
            EnquiryFors = e.EnquiryFors,
            InterestedTopics = e.InterestedTopics,
            Status = e.Status,
            BranchId = e.BranchId
        });
    }

    public async Task<EnquiryDto?> GetByIdAsync(int enquiryId)
    {
        var e = await _repository.GetByIdAsync(enquiryId);

        if (e == null)
            return null;

        return new EnquiryDto
        {
            EnquiryId = e.EnquiryId,
            EnquiryDate = e.EnquiryDate,
            CandidateName = e.CandidateName,
            Gender = e.Gender,
            LocalAddress = e.LocalAddress,
            EmailAddress = e.EmailAddress,
            MobileNumber = e.MobileNumber,
            BirthDate = e.BirthDate,
            Qualification = e.Qualification,
            LeadSources = e.LeadSources,
            EnquiryFors = e.EnquiryFors,
            InterestedTopics = e.InterestedTopics,
            Status = e.Status,
            BranchId = e.BranchId
        };
    }

    public async Task<string> CreateAsync(CreateEnquiryDto dto)
    {
        var enquiry = new Enquiry
        {
            EnquiryDate = dto.EnquiryDate,
            CandidateName = dto.CandidateName,
            Gender = dto.Gender,
            LocalAddress = dto.LocalAddress,
            EmailAddress = dto.EmailAddress,
            MobileNumber = dto.MobileNumber,
            BirthDate = dto.BirthDate,
            Qualification = dto.Qualification,
            LeadSources = dto.LeadSources,
            EnquiryFors = dto.EnquiryFors,
            InterestedTopics = dto.InterestedTopics,
            Status = dto.Status,
            BranchId = dto.BranchId
        };

        return await _repository.CreateAsync(enquiry);
    }

    public async Task<string> UpdateAsync(UpdateEnquiryDto dto)
    {
        var enquiry = new Enquiry
        {
            EnquiryId = dto.EnquiryId,
            EnquiryDate = dto.EnquiryDate,
            CandidateName = dto.CandidateName,
            Gender = dto.Gender,
            LocalAddress = dto.LocalAddress,
            EmailAddress = dto.EmailAddress,
            MobileNumber = dto.MobileNumber,
            BirthDate = dto.BirthDate,
            Qualification = dto.Qualification,
            LeadSources = dto.LeadSources,
            EnquiryFors = dto.EnquiryFors,
            InterestedTopics = dto.InterestedTopics,
            Status = dto.Status,
            BranchId = dto.BranchId
        };

        return await _repository.UpdateAsync(enquiry);
    }

    public async Task<string> DeleteAsync(int enquiryId)
    {
        return await _repository.DeleteAsync(enquiryId);
    }

    public async Task<string> RestoreAsync(int enquiryId)
    {
        return await _repository.RestoreAsync(enquiryId);
    }
}