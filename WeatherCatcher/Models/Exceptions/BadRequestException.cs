using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherCatcher.Models.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string errorMessage) : base(errorMessage)
        {
        }
    }
}