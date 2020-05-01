using Bmt.Microservices.SnowForecastCenter.Models;

namespace Bmt.Microservices.SnowForecastCenter.Infrastructure
{
   public interface IForecastProvider
   {
      ForecastDetails GetCurrentWeatherByLocationName(string locationName);
      ForecastDetails GetCurrentWeatherByLocationId(int locationId);
   }
}