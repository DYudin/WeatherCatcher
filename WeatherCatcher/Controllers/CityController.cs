using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using WeatherCatcher.Models;
using WeatherCatcher.Models.Exceptions;
using WeatherCatcher.Models.Repository;

namespace WeatherCatcher.Controllers
{
    public class CityController : ApiController
    {
        private readonly IServiceRepository _serviceRepository;

        public CityController()
        {
        }

        public CityController(IServiceRepository serviceRepository)
        {
            if (serviceRepository == null)
                throw new ArgumentNullException("serviceRepository is null");

            _serviceRepository = serviceRepository;
        }

        public IEnumerable<CityViewModel> GetAllCities()
        {
            var cityViewModels = new List<CityViewModel>();

            CookieHeaderValue cookie = Request.Headers.GetCookies("cities").FirstOrDefault();
            if (cookie != null)
            {
                foreach (var key in cookie.Cookies[0].Values.AllKeys)
                {
                    CityViewModel cityVM = new CityViewModel();
                    cityVM.Name = key;
                    getWeatherForCity(cityVM, cityViewModels);
                }
            }

            return cityViewModels;
        }

        public HttpResponseMessage PostCity(CityViewModel cityVM)
        {
            var cityViewModels = new List<CityViewModel>();
            
            getWeatherForCity(cityVM, cityViewModels);

            var reqCookis = Request.Headers.GetCookies("cities").FirstOrDefault();

            var respCookie = createCookie(cityVM.Name, reqCookis);
            var response = Request.CreateResponse<IEnumerable<CityViewModel>>(HttpStatusCode.OK, cityViewModels);

            if (respCookie != null)
            {
                response.Headers.Clear();
                response.Headers.AddCookies(new CookieHeaderValue[] { respCookie });
            }

            return response;
        }

        private void getWeatherForCity(CityViewModel cityVM, List<CityViewModel> cityViewModels)
        {
            Weather weather;
            foreach (var weatherService in _serviceRepository.ServicesCollection)
            {
                try
                {
                    string responseCity = weatherService.SendRequestByCity(cityVM.Name);
                    weather = weatherService.GetWeatherFromResponse(responseCity);

                    string encodedName = HttpUtility.UrlDecode(cityVM.Name);

                    //Create view model
                    var vmToReturn = new CityViewModel();
                    vmToReturn.Name = encodedName;
                    vmToReturn.Weather = weather;
                    vmToReturn.WeatherService = weatherService.ServiceName;
                    cityViewModels.Add(vmToReturn);
                }
                catch (CityNotFoundException ex)
                {
                    // TODO logger.Log(ex.Message)
                }
                catch (BadRequestException ex)
                {
                    // TODO logger.Log(ex.Message)
                }
                catch (Exception ex)
                {
                    // TODO logger.Log(ex.Message)
                }
            }
        }

        public HttpResponseMessage DeleteCity(string name)
        {
            var reqCookis = Request.Headers.GetCookies("cities").FirstOrDefault();

            var respCookie = deleteFromCookie(name, reqCookis);
            var response = Request.CreateResponse(HttpStatusCode.OK);

            if (respCookie != null)
            {
                response.Headers.Clear();
                response.Headers.AddCookies(new CookieHeaderValue[] { respCookie });
            }
          
            return response;
        }

        private CookieHeaderValue createCookie(string cityName, CookieHeaderValue reqCookies)
        {
            CookieHeaderValue cookie = null;

            if (reqCookies != null)
            {
                var series = reqCookies.Cookies[0].Values;

                if (string.IsNullOrWhiteSpace(series.Get(cityName)))
                {
                    series.Add(cityName, cityName);

                    cookie = new CookieHeaderValue("cities", series);
                }
            }
            else
            {
                var vals = new NameValueCollection();
                vals[cityName] = cityName;
                cookie = new CookieHeaderValue("cities", vals);
            }

            return cookie;
        }

        private CookieHeaderValue deleteFromCookie(string cityName, CookieHeaderValue reqCookies)
        {
            CookieHeaderValue cookie = null;

            if (reqCookies != null)
            {
                var series = reqCookies.Cookies[0].Values;

                if (!string.IsNullOrWhiteSpace(series.Get(cityName)))
                {
                    series.Remove(cityName);

                    cookie = new CookieHeaderValue("cities", series);
                }
            }

            return cookie;
        }
    }
}