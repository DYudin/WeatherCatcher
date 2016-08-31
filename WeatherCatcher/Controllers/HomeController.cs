using WeatherCatcher.Models;
using System.Web.Mvc;

namespace WeatherCatcher.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}