﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TR.Utilities.HttpClientWrapper;

namespace TR.Controllers
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
        private readonly IHttpClientWrapper _clientWrapper;
        
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IHttpClientWrapper httpClientWrapper,
            IConfiguration configuration)
        {
            _logger = logger;            
            _clientWrapper = httpClientWrapper;
            _clientWrapper.setClientKey("API");            
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            return (await _clientWrapper.GetAsync<List<WeatherForecast>>("weatherforecast"));

        }
    }
}
