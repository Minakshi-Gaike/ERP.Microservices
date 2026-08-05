using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using EnquiryService.Domain.Entities;
using EnquiryService.Domain.Interfaces;
using EnquiryService.Infrastructure.Data;
using global::EnquiryService.Infrastructure.Data;
using System.Data;

namespace EnquiryService.Infrastructure.Repositories
{
   

    public class EnquiryRepository : IEnquiryRepository
    {
        private readonly DapperContext _context;

        public EnquiryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enquiry>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<Enquiry>(
                "sp_tblenquiries",
                new
                {
                    type = "getall"
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Enquiry?> GetByIdAsync(int enquiryId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Enquiry>(
                "sp_tblenquiries",
                new
                {
                    type = "getbyid",
                    enquiry_id = enquiryId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> CreateAsync(Enquiry enquiry)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstAsync<string>(
                "sp_tblenquiries",
                new
                {
                    type = "insert",
                    enquiry_date = enquiry.EnquiryDate,
                    candidate_name = enquiry.CandidateName,
                    gender = enquiry.Gender,
                    local_address = enquiry.LocalAddress,
                    email_address = enquiry.EmailAddress,
                    mobile_number = enquiry.MobileNumber,
                    birth_date = enquiry.BirthDate,
                    qualification = enquiry.Qualification,
                    lead_sources = enquiry.LeadSources,
                    enquiry_fors = enquiry.EnquiryFors,
                    interested_topics = enquiry.InterestedTopics,
                    status = enquiry.Status,
                    branch_id = enquiry.BranchId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> UpdateAsync(Enquiry enquiry)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstAsync<string>(
                "sp_tblenquiries",
                new
                {
                    type = "update",
                    enquiry_id = enquiry.EnquiryId,
                    enquiry_date = enquiry.EnquiryDate,
                    candidate_name = enquiry.CandidateName,
                    gender = enquiry.Gender,
                    local_address = enquiry.LocalAddress,
                    email_address = enquiry.EmailAddress,
                    mobile_number = enquiry.MobileNumber,
                    birth_date = enquiry.BirthDate,
                    qualification = enquiry.Qualification,
                    lead_sources = enquiry.LeadSources,
                    enquiry_fors = enquiry.EnquiryFors,
                    interested_topics = enquiry.InterestedTopics,
                    status = enquiry.Status,
                    branch_id = enquiry.BranchId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> DeleteAsync(int enquiryId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstAsync<string>(
                "sp_tblenquiries",
                new
                {
                    type = "delete",
                    enquiry_id = enquiryId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> RestoreAsync(int enquiryId)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstAsync<string>(
                "sp_tblenquiries",
                new
                {
                    type = "restore",
                    enquiry_id = enquiryId
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
