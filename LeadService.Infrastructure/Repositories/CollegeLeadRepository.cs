using CollegeLeadService.Domain.Entities;
using CollegeLeadService.Domain.Interfaces;
using LeadService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;



namespace CollegeLeadService.Infrastructure.Repositories
    {
        public class CollegeLeadRepository : ICollegeLeadRepository
        {
            private readonly DapperContext _context;

            public CollegeLeadRepository(DapperContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<CollegeLead>> GetAllAsync()
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryAsync<CollegeLead>(
                    "sp_tblcollege_leads",
                    new
                    {
                        type = "getall"
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<CollegeLead?> GetByIdAsync(int leadId)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstOrDefaultAsync<CollegeLead>(
                    "sp_tblcollege_leads",
                    new
                    {
                        type = "getbyid",
                        lead_id = leadId
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<string> CreateAsync(CollegeLead collegeLead)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstAsync<string>(
                    "sp_tblcollege_leads",
                    new
                    {
                        type = "insert",
                        qualification = collegeLead.Qualification,
                        collegename = collegeLead.CollegeName,
                        studentname = collegeLead.StudentName,
                        mothername = collegeLead.MotherName,
                        email_address = collegeLead.EmailAddress,
                        mobile_number = collegeLead.MobileNumber,
                        gender = collegeLead.Gender,
                        address = collegeLead.Address,
                        state = collegeLead.State,
                        city = collegeLead.City,
                        pincode = collegeLead.PinCode
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<string> UpdateAsync(CollegeLead collegeLead)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstAsync<string>(
                    "sp_tblcollege_leads",
                    new
                    {
                        type = "update",
                        lead_id = collegeLead.LeadId,
                        qualification = collegeLead.Qualification,
                        collegename = collegeLead.CollegeName,
                        studentname = collegeLead.StudentName,
                        mothername = collegeLead.MotherName,
                        email_address = collegeLead.EmailAddress,
                        mobile_number = collegeLead.MobileNumber,
                        gender = collegeLead.Gender,
                        address = collegeLead.Address,
                        state = collegeLead.State,
                        city = collegeLead.City,
                        pincode = collegeLead.PinCode
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<string> DeleteAsync(int leadId)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstAsync<string>(
                    "sp_tblcollege_leads",
                    new
                    {
                        type = "delete",
                        lead_id = leadId
                    },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<string> RestoreAsync(int leadId)
            {
                using var connection = _context.CreateConnection();

                return await connection.QueryFirstAsync<string>(
                    "sp_tblcollege_leads",
                    new
                    {
                        type = "restore",
                        lead_id = leadId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }

