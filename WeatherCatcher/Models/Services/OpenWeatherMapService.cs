using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WeatherCatcher.Models.Exceptions;

namespace WeatherCatcher.Models.Services
{
    public sealed class OpenWeatherMapService : WeatherServiceBase
    {
        public override string ServiceName => "OpenWeatherMap";

        public override string ApiKey => "562accf41c039a6b995ae95c57730766";

        public override string RequestString => "http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}";

        public override Weather GetWeatherFromResponse(string response)
        {
            if (string.IsNullOrWhiteSpace(response))
                throw new ArgumentException("Invalid response parameter");

            dynamic data = JsonConvert.DeserializeObject(response);
            Weather weather = null;

            if ((string) data.cod == "200")
            {
                var temp = (int) data.main.temp - 273;
                var pressure = (double) data.main.pressure;
                var humidity = (double) data.main.humidity;
                var events = (string) data.weather[0].description.ToString();
                weather = new Weather(temp, humidity, pressure, events);
            }
            else if ((string) data.cod == "404")
            {
                throw new CityNotFoundException("City not found");
            }
            else
            {
                throw new BadRequestException($"Error during request. Error code {data.cod}");
            }

            return weather;
        }
    }
}