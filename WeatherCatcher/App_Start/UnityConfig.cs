using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WeatherCatcher.Models;
using WeatherCatcher.Models.Repository;
using WeatherCatcher.Models.Services;

namespace WeatherCatcher
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<WeatherServiceBase, OpenWeatherMapService>();
            container.RegisterType<WeatherServiceBase, WorldWeatherOnlineService>();

            var serviceRepository = new ServiceRepository();
            serviceRepository.ServicesCollection.Add(container.Resolve<OpenWeatherMapService>());
            serviceRepository.ServicesCollection.Add(container.Resolve<WorldWeatherOnlineService>());

            container.RegisterInstance(typeof(IServiceRepository), serviceRepository);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}