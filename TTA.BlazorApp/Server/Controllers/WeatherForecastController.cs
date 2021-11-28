using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTA.BlazorApp.Server.Data;
using TTA.BlazorApp.Shared;

namespace TTA.BlazorApp.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] SampleSummaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;

            if (!context.WeatherForecasts.Any())
            {
                context.WeatherForecasts.AddRange(GetForecastSampleData());
                context.SaveChanges();
            }
        }

        private static IEnumerable<WeatherForecast> GetForecastSampleData()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = SampleSummaries[rng.Next(SampleSummaries.Length)]
                })
                .ToArray();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return context.WeatherForecasts;
        }

        [HttpPost]
        public async Task<WeatherForecast> Add(WeatherForecast weatherForecast)
        {
            await context.WeatherForecasts.AddAsync(weatherForecast);
            await context.SaveChangesAsync();
            return weatherForecast;
        }
    }
}
