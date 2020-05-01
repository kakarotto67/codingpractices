using Bmt.Microservices.SnowForecastCenter.Models;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;

namespace Bmt.Microservices.SnowForecastCenter.Infrastructure
{
   public class OpenWeatherMapForecast : IForecastProvider
   {
      private readonly ILogger logger;
      private readonly string ApiKey = "ed82ba5941831dc5881da4d9a4b5c394";
      private readonly string WeatherApiBaseUrl = "http://api.openweathermap.org/data/2.5/weather";

      public OpenWeatherMapForecast(ILogger logger)
      {
         this.logger = logger;
      }

      public ForecastDetails GetCurrentWeatherByLocationName(string locationName)
      {
         if (String.IsNullOrEmpty(locationName))
         {
            return null;
         }

         var externalApiUrl = GetBaseApiUrl()
            .SetQueryParams(new
            {
               q = locationName
            });

         try
         {
            var jsonDynamic = externalApiUrl.GetJsonAsync().Result;
            logger.LogInformation($"External weather API returned this result: {jsonDynamic}");
            return ForecastDetails.ToForecastDetails(jsonDynamic);
         }
         catch(Exception ex)
         {
            logger.LogError($"Exception in GetCurrentWeatherByLocationName: {ex} \nMessage: {ex.Message}");
            return null;
         }
      }

      public ForecastDetails GetCurrentWeatherByLocationId(int locationId)
      {
         if (locationId < 0)
         {
            return null;
         }

         var externalApiUrl = GetBaseApiUrl()
            .SetQueryParams(new
            {
               id = locationId
            });

         try
         {
            var jsonDynamic = externalApiUrl.GetJsonAsync().Result;
            return ForecastDetails.ToForecastDetails(jsonDynamic);
         }
         catch (Exception ex)
         {
            logger.LogError($"Exception in GetCurrentWeatherByLocationId: {ex} \nMessage: {ex.Message}");
            return null;
         }
      }

      private Url GetBaseApiUrl()
      {
         return new Url(WeatherApiBaseUrl)
            .SetQueryParams(new
            {
               appid = ApiKey
            });
      }
   }
}