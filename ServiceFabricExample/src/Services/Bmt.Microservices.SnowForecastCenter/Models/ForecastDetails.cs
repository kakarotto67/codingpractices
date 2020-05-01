using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Bmt.Microservices.SnowForecastCenter.Models
{
    public class ForecastDetails
    {
        public string LocationName { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public float TemperatureKelvin { get; set; }
        public float Temperature => (float)Math.Round(TemperatureKelvin - 273.15, 2);
        public float WindSpeed { get; set; }
        public float CloudsLevel { get; set; }

        public static ForecastDetails ToForecastDetails(dynamic jsonDynamic)
        {
            if (jsonDynamic == null)
            {
                return null;
            }

            try
            {
                var jsonDictionary = jsonDynamic as IDictionary<String, Object>;
                var weatherSubDictionary = (jsonDictionary["weather"] as List<Object>)[0] as IDictionary<String, Object>;
                var mainSubDictionary = jsonDictionary["main"] as IDictionary<String, Object>;
                var windSubDictionary = jsonDictionary["wind"] as IDictionary<String, Object>;
                var cloudsSubDictionary = jsonDictionary["clouds"] as IDictionary<String, Object>;

                return new ForecastDetails
                {
                    LocationName = jsonDictionary["name"].ToString(),
                    ShortDesc = weatherSubDictionary["main"].ToString(),
                    LongDesc = weatherSubDictionary["description"].ToString(),
                    TemperatureKelvin = float.TryParse(mainSubDictionary["temp"].ToString(), out var temperature) ? temperature : 0,
                    WindSpeed = float.TryParse(windSubDictionary["speed"].ToString(), out var windSpeed) ? windSpeed : 0,
                    CloudsLevel = float.TryParse(cloudsSubDictionary["all"].ToString(), out var cloudsLevel) ? cloudsLevel : 0
                };
            }
            catch
            {
                throw;
            }
        }
    }
}