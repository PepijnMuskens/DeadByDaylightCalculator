using Logic;
using Microsoft.AspNetCore.Mvc;

namespace DeadByDaylightItemApi.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetWeatherForecast")]
        public string Get()
        {
            return "works";
        }

        [HttpGet]
        [Route("Get")]
        public string Geter()
        {
            string hello = "";
            Calculator.GetLongestDuration(1).ToString();
            return hello;
        }
    }
}