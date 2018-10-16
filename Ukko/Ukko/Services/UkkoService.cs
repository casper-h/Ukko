using Microsoft.AppCenter.Crashes;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ukko.Models;
using Ukko.Utilities;
using Xamarin.Essentials;

namespace Ukko.Services
{
    public class UkkoService
    {
        private readonly IUkkoService us;

        public UkkoService()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                throw new NotImplementedException("Allow internet permission / no internetm and restart app");
            }

            try
            {
                this.us = RestService.For<IUkkoService>(ApplicationSettings.AzureBackendUrl,
                    new RefitSettings
                    {
                        JsonSerializerSettings = Utilities.JsonSettingsUtility.GetSnakeCaseJsonSerializerSettings()
                    }
                );
            }
            catch (Exception exception)
            {
                var properties = new Dictionary<string, string> {
                    { "MethodName", $"{System.Reflection.MethodBase.GetCurrentMethod().Name}" },
                    { "Message", "There was an error while trying to connect to the API. Please try again later." }
                };

                Crashes.TrackError(exception, properties);

                throw;
            }
        }

        /// <summary>
        /// Gets the current weather for a zip code.
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public async Task<CurrentWeather> GetCurrentWeatherByZipCodeAsync(uint zipCode)
        {
            CurrentWeather currentWeatherResult = new CurrentWeather();
            try
            {
                currentWeatherResult = await this.us.GetCurrentWeatherByZipCodeAsync(zipCode).ConfigureAwait(false);
            }
            catch (HttpRequestException hre)
            {
                var properties = new Dictionary<string, string> {
                    { "MethodName", $"{System.Reflection.MethodBase.GetCurrentMethod().Name}" },
                    { "Message", "There was an error while trying to connect to the API. Please try again later." }
                };

                Crashes.TrackError(hre, properties);
                throw new NotImplementedException("Allow internet permission / no internet.");
            }
            catch (Exception exception)
            {
                var properties = new Dictionary<string, string> {
                    { "MethodName", $"{System.Reflection.MethodBase.GetCurrentMethod().Name}" },
                    { "Message", "There was an error while connecting to the API. There may be an issue with your internet connection or the API might currently be down." }
                };

                Crashes.TrackError(exception, properties);

                throw;
            }

            currentWeatherResult.Main.Temp = WeatherUtility.ConvertKelvinToFahrenheit(currentWeatherResult.Main.Temp);

            return currentWeatherResult;
        }
    }
}
