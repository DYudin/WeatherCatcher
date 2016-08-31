using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using WeatherCatcher.Models;

namespace WeatherCatcher.Controllers
{
    public class WebController : ApiController
    {
        private CityRepository repo = CityRepository.Current;
        private WeatherCollectorREST weatherCollector = WeatherCollectorREST.Current;

        public IEnumerable<City> GetAllCities()
        {
            return repo.ObservableCities;
        }

        public City GetReservation(int id)
        {
            return new City("Unknown");
        }

        //[HttpPost]
        //public City PostReservation(HttpRequestMessage request) 
        //{
        //    var name = request.Content.ReadAsStringAsync().Result.Replace("Name=", string.Empty).Trim();
        //    City city;

        //    //try
        //    //{
        //        var weather = weatherCollector.GetWeatherByCity(name);
        //        string encodedName = HttpUtility.UrlDecode(name);
        //        city = new City(encodedName, weather, "OpenWeatherMap");
        //        repo.AddCity(city);
        //    //}
        //    //catch (Exception ex)
        //    //{

        //    //}

        //    return city;
        //}

        [HttpPost]
        public City PostReservation(City item)
        {
            return item;
        }

        [HttpPut]
        public bool UpdateReservation(City item)
        {
            return false; //repo.Update(item);
        }

        public void DeleteReservation(string Name)
        {
            //repo.Remove(id);
        }
    }
}