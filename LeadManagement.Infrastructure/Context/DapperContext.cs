using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;



namespace LeadManagement.Infrastructure.Context
    {
        public class DapperContext
        {
            private readonly IConfiguration _configuration;

            public DapperContext(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public IDbConnection CreateConnection()
            {
                return new SqlConnection(
                    _configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }

