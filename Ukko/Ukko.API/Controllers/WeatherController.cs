using Ukko.API.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ukko.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ukko.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly OpenWeatherMapService owms;

        public WeatherController()
        {
            this.owms = new OpenWeatherMapService();
        }

        [HttpGet("{zipCode}")]
        [ProducesResponseType(typeof(CurrentWeather), 200)]
        public async Task<IActionResult> GetCurrentWeatherByZipCodeAsync(uint zipCode)
            => Ok(await this.owms.GetCurrentWeatherByZipCodeAsync(zipCode));
    }
}
