using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using Ukko.API.Models;

namespace Ukko.API.Services
{
    interface IOpenWeatherMapService
    {
        [Get("/weather?zip={zipCode},us&appid={apiKey}")]
        Task<OpenWeatherMapApiCurrentWeather> GetCurrentWeatherByZipCodeAsync(uint zipCode, string apiKey);
    }
}
