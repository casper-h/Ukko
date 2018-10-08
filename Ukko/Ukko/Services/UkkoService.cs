using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ukko.Models;

namespace Ukko.Services
{
    public class UkkoService
    {
        private readonly IUkkoService us;

        public UkkoService()
        {
            this.us = RestService.For<IUkkoService>(App.AzureBackendUrl,
                new RefitSettings
                {
                    JsonSerializerSettings = Utilities.JsonSettingsUtility.GetSnakeCaseJsonSerializerSettings()
                }
            );
        }

        /// <summary>
        /// Gets the current weather for a zip code.
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public async Task<CurrentWeather> GetCurrentWeatherByZipCodeAsync(uint zipCode)
        {
            var result = await this.us.GetCurrentWeatherByZipCodeAsync(zipCode).ConfigureAwait(false); ;
            return result;
        }
    }
}
