using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCatcher.Models
{
    public interface ICityRepository
    {
        IEnumerable<City> ObservableCities { get; }
        City AddCity(City city);
    }
}
