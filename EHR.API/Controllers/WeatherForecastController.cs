using Dapper;
using EHR.Database.Context;
using EHR.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EHR.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private DatabaseContext context;
        private DapperQueryContext _context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,DatabaseContext dbcontext, DapperQueryContext _context)
        {
            _logger = logger;
            this.context = dbcontext;
            this._context = _context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //EF Core
            //Office office = new Office();
            //office.Id = Guid.NewGuid();
            //office.Name = "Test";
            //this.context.Offices.Add(office);
            //this.context.SaveChanges();

            //var list = this.context.Offices.ToList();
            //Dapper
            //using var connection = this._context.CreateConnection();
            //var result = connection.Query<Office>(@"select * from ""Office""").ToList();


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}