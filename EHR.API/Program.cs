using EHR.Application;
using EHR.Database.Context;
using EHR.Database.Entities;
using EHR.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Module Service
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DapperQueryContext>();
builder.Services.AddDbContext<DatabaseContext>(options =>
  options.UseNpgsql("Host=aurora-auroradatabase5475d328-1fhhlc5ey771i.cluster-csgv9gisrp7z.us-east-2.rds.amazonaws.com:48040;Database=development;Username=cluster_root;Password=)Z~pS?|%I7=#_?oX|JdFAWUJI=[pFYF!")
);
// Allow Browser Call APIS
var corsPolicy = "APICors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
                      builder =>
                      {
                          builder
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .SetIsOriginAllowed(orign => true)
                            .AllowCredentials();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
