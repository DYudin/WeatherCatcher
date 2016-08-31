using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WeatherCatcher.Models
{
    public class WeatherCollectorREST : IWeatherCollector 
    {
        private static WeatherCollectorREST repo = new WeatherCollectorREST();

        public static WeatherCollectorREST Current
        {
            get
            {
                return repo;
            }
        }

        public Weather GetWeatherByCity(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid name of the city");

            string apiKey = "562accf41c039a6b995ae95c57730766";

            string request =
            string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}", name, apiKey);
            Weather weather;

            // Создаём объект WebClient
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(request);
                dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
                var temp = (double)data.main.temp;
                var pressure = (double)data.main.pressure;
                var humidity = (double)data.main.humidity;
                var events = (string)data.weather[0].description.ToString();


                weather = new Weather(temp, humidity, pressure, events);
            }

            return weather;
        }
    }
}