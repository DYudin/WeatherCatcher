using System.Collections.Generic;
using WeatherCatcher.Models.Services;

namespace WeatherCatcher.Models.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private List<WeatherServiceBase> servicesCollection;

        public List<WeatherServiceBase> ServicesCollection
        {
            get { return servicesCollection; }
            set { servicesCollection = value; }
        }

        public ServiceRepository()
        {
            servicesCollection = new List<WeatherServiceBase>();
        }
    }
}