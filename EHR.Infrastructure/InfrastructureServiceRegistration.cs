using AWS;
using AWS.SecrectManager;
using EHR.Application.Contract.Identity;
using EHR.Application.Contract.CRM.Office;
using EHR.Database.Context;
using EHR.Infrastructure.Repositories;
using EHR.Infrastructure.Repositories.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace EHR.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DB Context
            SecrectModel secretValue = SecretsManager.GetSecret<SecrectModel>("auroradb1AuroraClusterCredentials")!;
            String connectionStrig = $"Host={secretValue.host}:{secretValue.port};Database={secretValue.environment};Username={secretValue.username};Password={secretValue.password}";
          //  services.AddSingleton<DapperQueryContext>(options=>new DapperQueryContext(configuration,connectionStrig));
            services.AddDbContext<DatabaseContext>(options =>
              options.UseNpgsql(connectionStrig)
            );
            services.AddScoped<IDbConnection, NpgsqlConnection>(options =>
            {
                NpgsqlConnection conn = new NpgsqlConnection();
                conn.ConnectionString = connectionStrig;
                return conn;
            });
            #endregion

            #region Repository
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IIdentityRepository, IdentityRepository>();

            #endregion
            return services;
        }
    }
}
