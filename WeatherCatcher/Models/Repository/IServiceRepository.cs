using System.Collections.Generic;
using WeatherCatcher.Models.Services;

namespace WeatherCatcher.Models.Repository
{public interface IServiceRepository
    {
        List<WeatherServiceBase> ServicesCollection { get; }
    }
}
