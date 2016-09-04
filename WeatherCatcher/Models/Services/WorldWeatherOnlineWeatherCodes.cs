﻿
using System.Collections.Generic;

namespace WeatherCatcher.Models.Services
{
    public static class WorldWeatherOnlineWeatherCodes
    {
        public static readonly Dictionary<int, string> WeatherCodes = new Dictionary<int, string>()
        {
            {395, "Moderate or heavy snow in area with thunder"},
            {392, "Patchy light snow in area with thunder"},
            {389, "Moderate or heavy rain in area with thunder"},
            {386, "Patchy light rain in area with thunder"},
            {377, "Moderate or heavy showers of ice pellets"},
            {374, "Light showers of ice pellets"},
            {371, "Moderate or heavy snow showers"},
            {368, "Light snow showers"},
            {365, "Moderate or heavy sleet showers"},
            {362, "Light sleet showers"},
            {359, "Torrential rain shower"},
            {356, "Moderate or heavy rain shower"},
            {353, "Light rain shower"},
            {350, "Ice pellets"},
            {338, "Heavy snow"},
            {335, "Patchy heavy snow"},
            {332, "Moderate snow"},
            {329, "Patchy moderate snow"},
            {326, "Light snow"},
            {323, "Patchy light snow"},
            {320, "Moderate or heavy sleet"},
            {317, "Light sleet wsymbol_0021_cloudy_with_sleet"},
            {314, "Moderate or Heavy freezing rain"},
            {311, "Light freezing rain"},
            {308, "Heavy rain"},
            {305, "Heavy rain at times"},
            {302, "Moderate rain"},
            {299, "Moderate rain at times"},
            {296, "Light rain"},
            {293, "Patchy light rain"},
            {284, "Heavy freezing drizzle"},
            {281, "Freezing drizzle"},
            {266, "Light drizzle"},
            {263, "Patchy light drizzle"},
            {260, "Freezing fog"},
            {248, "Fog wsymbol_0007_fog"},
            {230, "Blizzard"},
            {227, "Blowing snow"},
            {200, "Thundery outbreaks in nearby"},
            {185, "Patchy freezing drizzle nearby"},
            {182, "Patchy sleet nearby"},
            {179, "Patchy snow nearby"},
            {176, "Patchy rain nearby"},
            {143, "Mist"},
            {122, "Overcast"},
            {119, "Cloudy"},
            {116, "Partly Cloudy"}
        };
    }
}