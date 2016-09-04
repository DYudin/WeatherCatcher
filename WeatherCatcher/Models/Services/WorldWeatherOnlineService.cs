using System;
using Newtonsoft.Json;
using WeatherCatcher.Models.Exceptions;

namespace WeatherCatcher.Models.Services
{
    public sealed class WorldWeatherOnlineService : WeatherServiceBase
    {
        public override string ServiceName => "WorldWeatherOnline";

        public override string ApiKey => "8136337b41c341e8b91184805160209";

        public override string RequestString => "http://api.worldweatheronline.com/premium/v1/weather.ashx?key={1}&q={0}&date=today&num_of_days=1&format=json";

        public override Weather GetWeatherFromResponse(string response)
        {
            if (string.IsNullOrWhiteSpace(response))
                throw new ArgumentException("Invalid response parameter");

            dynamic responseData = JsonConvert.DeserializeObject(response);
            Weather weather = null;

            if (responseData.data.error != null)
            {
                throw new CityNotFoundException("City not found");
            }
            else
            {
                var temp = (int)responseData.data.current_condition[0].temp_C;
                var pressure = (double)responseData.data.current_condition[0].pressure;
                var humidity = (double)responseData.data.current_condition[0].humidity;

                int weatherConitionCode = responseData.data.current_condition[0].weatherCode;
                string events;
                WorldWeatherOnlineWeatherCodes.WeatherCodes.TryGetValue(weatherConitionCode, out events);

                weather = new Weather(temp, humidity, pressure, events);

            }

            return weather;
        }
    }
}