using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WeatherCatcher.Models
{

    public class City
    {
        //private Weather weather;
        
        public string Name { get; private set; }
        public string WeatherService { get; private set; }

        public Weather Weather { get; private set; } 

        public City(string name, Weather weather, string weatherService)
        {
            if (string.IsNullOrWhiteSpace(name) )
                throw new ArgumentException("Invalid name of the city");
            if (weather == null)
                throw new ArgumentNullException("weather is null");
            if (weatherService == null)
                throw new ArgumentNullException("weatherService is null");

            Name = name;
            Weather = weather;
            WeatherService = weatherService;
        }

        public City(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid name of the city");

            Name = name;
        }

        public void RefreshWeather(Weather weather)
        {
            if (weather == null)
                throw new ArgumentException("Weather is null");
            Weather = weather;
        }

    }
}