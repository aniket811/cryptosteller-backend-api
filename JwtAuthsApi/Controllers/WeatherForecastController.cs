using JwtAuthsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthsApi.Controllers
{
    [ApiController]
    
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        /*<summary>Method to get the weather forecast 
          for a particular city name and save it to database.</summary>
         */
        [HttpPost]
        public IActionResult Post( WeatherForecastModel weatherForecast)
        {
            Guid gid = Guid.NewGuid();
            var weathers = new WeatherForecastModel()
            {
                Id=gid,
                CityName=weatherForecast.CityName
            };
            _context.WeatherForecasts.Add(weathers);
            _context.SaveChanges();
            return Ok(weatherForecast);
        }
    }
}