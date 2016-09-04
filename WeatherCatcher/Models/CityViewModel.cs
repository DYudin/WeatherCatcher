using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherCatcher.Models;

namespace WeatherCatcher.Models
{
    public class CityViewModel
    {
        public string Name { get; set; }
        public string WeatherService { get; set; }
        public Weather Weather { get; set; }
    }
}