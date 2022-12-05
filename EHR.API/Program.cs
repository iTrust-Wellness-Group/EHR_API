using EHR.Application;
using EHR.Infrastructure;
using EHR.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using Microsoft.IdentityModel.Logging;
using EHR.API.MiddleWare;
using EHR.Context;
using EHR.Shared;

var builder = WebApplication.CreateBuilder(args);

// Customized Module Service
#region Customized Module Service
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddShareServices(builder.Configuration);
builder.Services.AddContextServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

#endregion
builder.Services.AddControllers();

#region API Cors
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
#endregion

#region swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "EHR.API", Version = "v1" });
        var securityScheme = new OpenApiSecurityScheme
        {
            Name = "JWT Authentication",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer", // must be lower case
            BearerFormat = "JWT",
            Reference = new OpenApiReference
            {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };
        c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
        c.AddSecurityRequirement(new OpenApiSecurityRequirement { { securityScheme, Array.Empty<string> () }
                });
        c.CustomSchemaIds(x => x.FullName);
    });
#endregion

ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
IdentityModelEventSource.ShowPII = true;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.DisplayRequestDuration();
    });
}

#region Middleware
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<RequestMiddleware>();
app.MapControllers();
#endregion

app.Run();
