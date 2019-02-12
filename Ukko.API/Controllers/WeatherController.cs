using Ukko.API.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ukko.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Ukko.API.Controllers
{
    [Route("api/Weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly OpenWeatherMapService owms;
        private readonly WeatherContext context;

        public WeatherController(WeatherContext context)
        {
            this.owms = new OpenWeatherMapService();
            this.context = context;
        }

        /// <summary>
        /// Gets the current weather for a given US zipcode.
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
        [HttpGet("Current/{zipCode}")]
        [ProducesResponseType(typeof(OpenWeatherMapApiCurrentWeather), 200)]
        public async Task<IActionResult> GetCurrentWeatherByZipCodeAsync(uint zipCode)
        {
            if (!Regex.Match(zipCode.ToString(), @"^[0-9]{5}(?:-[0-9]{4})?$").Success)
            {
                return BadRequest(new { message = "Provided ZipCode was not a valid United States ZipCode." });
            }

            OpenWeatherMapApiCurrentWeather currentWeatherResult = new OpenWeatherMapApiCurrentWeather();

            try
            {
                currentWeatherResult = await this.owms.GetCurrentWeatherByZipCodeAsync(zipCode);
            }
            catch (Refit.ApiException rex)
            {
                var content = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenWeatherMapApiError>(rex.Content);

                switch (content.Cod)
                {
                    case 401:
                        return Unauthorized();
                    case 404:
                        return NotFound(content.Message);
                    case 429:
                        return new RateLimitedActionResult(content);
                    default:
                        return NotFound();
                }
            }

            return Ok(currentWeatherResult);
        }
    }
}
