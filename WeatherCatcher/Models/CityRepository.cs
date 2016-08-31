using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherCatcher.Models
{
    public class CityRepository : ICityRepository
    {
        private static CityRepository repo = new CityRepository();

        public static CityRepository Current
        {
            get
            {
                return repo;
            }
        }

        private List<City> _observableCities;
        public CityRepository()
        {
            _observableCities = new List<City>();
            _observableCities.Add(
                new City("Москва", new Weather(25, 75, 145, "Дождь"), "Test"));
            _observableCities.Add(
                new City("Челябинск", new Weather(20, 60, 120, "Солнце"), "Test"));
        }

        public IEnumerable<City> ObservableCities
        {
            get
            {
                return _observableCities;
            }
        }

        public City AddCity(City city)
        {
            if (city == null)
                throw new ArgumentException("City is null");
            _observableCities.Add(city);
            return city;
        }
    }
}