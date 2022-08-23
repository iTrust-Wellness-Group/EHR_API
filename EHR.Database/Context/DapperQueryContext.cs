using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Database.Context
{
    public class DapperQueryContext
    {

        private readonly IConfiguration _configuration;
        public String ConnectionString { get; set; }
        public DapperQueryContext(IConfiguration configuration,String connectionString)
        {
            _configuration = configuration;
            ConnectionString = connectionString;
        }
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(ConnectionString);
    }
}
