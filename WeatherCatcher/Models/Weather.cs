using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WeatherCatcher.Models
{
    [DataContractAttribute]
    public class Weather
    {
        [DataMemberAttribute]
        public double Temperature
        {
            get; set;
        }

        [DataMemberAttribute]
        public double Humidity
        {
            get; set;
        }
        [DataMemberAttribute]
        public double Pressure
        {
            get; set;
        }
        [DataMemberAttribute]
        public string WeatherСonditions
        {
            get; set;
        }

        public Weather(double temperature, double humidity, double pressure, string weatherСonditions)

        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
            WeatherСonditions = weatherСonditions;
        }
    }
}