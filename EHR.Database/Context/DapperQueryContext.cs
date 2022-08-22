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
        private readonly string _connectionString;
        public DapperQueryContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = "Host=aurora-auroradatabase5475d328-1fhhlc5ey771i.cluster-csgv9gisrp7z.us-east-2.rds.amazonaws.com:48040;Database=development;Username=cluster_root;Password=)Z~pS?|%I7=#_?oX|JdFAWUJI=[pFYF!";
        }
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    }
}
