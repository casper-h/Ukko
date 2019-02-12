using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Ukko.API.Models;
using Refit;
using Microsoft.EntityFrameworkCore;

namespace Ukko.API.Services
{
    public class OpenWeatherMapService
    {
        private readonly IOpenWeatherMapService owms;

        public OpenWeatherMapService()
        {
            this.owms = RestService.For<IOpenWeatherMapService>(
                new HttpClient()
                {
                    BaseAddress = new Uri(@"https://api.openweathermap.org/data/2.5")
                },
                new RefitSettings
                {
                    JsonSerializerSettings = Utilities.JsonSettingsUtility.GetSnakeCaseJsonSerializerSettings()
                }
            );
        }

        /// <summary>
        /// Retrieves the app key from db, and sets for use in the API service.
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetApiKeyAsync()
        {
            return "103568c27d532a9d90c41c5b14596560";
        }

        /// <summary>
        /// Gets the current weather for a zip code.
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        public async Task<OpenWeatherMapApiCurrentWeather> GetCurrentWeatherByZipCodeAsync(uint zipcode)
            => await this.owms.GetCurrentWeatherByZipCodeAsync(zipcode, await GetApiKeyAsync());
    }
}
