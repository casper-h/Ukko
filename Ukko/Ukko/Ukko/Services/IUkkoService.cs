using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;
using Ukko.Models;

namespace Ukko.Services
{
    interface IUkkoService
    {
        [Get("/{zipCode}")]
        Task<CurrentWeather> GetCurrentWeatherByZipCodeAsync(uint zipCode);
    }
}
