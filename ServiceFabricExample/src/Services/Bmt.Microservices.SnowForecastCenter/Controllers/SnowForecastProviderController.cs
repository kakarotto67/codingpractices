using Bmt.Microservices.SnowForecastCenter.Infrastructure;
using Bmt.Microservices.SnowForecastCenter.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Bmt.Microservices.SnowForecastCenter.Controllers
{
    [EnableCors("Bmt.Microservices.SnowForecastCenterType")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SnowForecastProviderController : ControllerBase
    {
        private readonly IForecastProvider forecastProvider;

        public SnowForecastProviderController(IForecastProvider forecastProvider)
        {
            this.forecastProvider = forecastProvider;
        }

        // GET: api/snowforecastprovider/Lviv
        [HttpGet("{locationName:alpha}")]
        public ActionResult<ForecastDetails> GetCurrentWeather(string locationName)
        {
            var forecastResult = forecastProvider.GetCurrentWeatherByLocationName(locationName);

            if (forecastResult != null)
            {
                return Ok(forecastResult);
            }

            return BadRequest();
        }

        // GET: api/snowforecastprovider/5
        [HttpGet("{locationId:int}")]
        public ForecastDetails GetCurrentWeather(int locationId)
        {
            return forecastProvider.GetCurrentWeatherByLocationId(locationId);
        }
    }
}