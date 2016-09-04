using System;
using System.Net;

namespace WeatherCatcher.Models.Services
{
    public abstract class WeatherServiceBase
    {
        public abstract string ServiceName { get; }
        public abstract string ApiKey { get; }

        public abstract string RequestString { get; }

        public string SendRequestByCity(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid name of the city");

            string response;
            // Создаём объект WebClient
            using (var webClient = new WebClient())
            {
                string request = string.Format(RequestString, name, ApiKey);
                response = webClient.DownloadString(request);
            }

            return response;
        }

        public abstract Weather GetWeatherFromResponse(string response);
    }
}