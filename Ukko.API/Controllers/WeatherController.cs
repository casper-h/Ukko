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

        /// <summary>
        /// Gets the current weather for a given zipcode.
        /// </summary>
        /// <param name="zipCode">The zipcode for a users area</param>
        /// <returns>
        /// {
        ///    "coord": {
        ///        "lon": -82.79,
        ///        "lat": 28.03
        ///    },
        ///    "sys": {
        ///        "type": 1,
        ///        "id": 726,
        ///        "message": 0.005,
        ///        "country": "US",
        ///        "sunrise": 1539084521,
        ///        "sunset": 1539126431
        ///    },
        ///    "weather": [
        ///        {
        ///            "id": 803,
        ///            "main": "Clouds",
        ///            "description": "broken clouds",
        ///            "icon": "04d"
        ///        }
        ///    ],
        ///    "base": "stations",
        ///    "main": {
        ///        "temp": 304.87,
        ///        "humidity": 59,
        ///        "pressure": 1008,
        ///        "temp_min": 304.25,
        ///        "temp_max": 305.35
        ///    },
        ///    "wind": {
        ///        "speed": 5.1,
        ///        "deg": 100
        ///    },
        ///    "clouds": {
        ///        "all": 75
        ///    },
        ///    "dt": 1539117300,
        ///    "id": 420009842,
        ///    "name": "Clearwater",
        ///    "cod": 200
        /// }
        /// </returns>
        /// <example>
        /// /api/Weather/12345
        /// </example>
        [HttpGet("{zipCode}")]
        [ProducesResponseType(typeof(CurrentWeather), 200)]
        public async Task<IActionResult> GetCurrentWeatherByZipCodeAsync(uint zipCode)
            => Ok(await this.owms.GetCurrentWeatherByZipCodeAsync(zipCode));
    }
}
