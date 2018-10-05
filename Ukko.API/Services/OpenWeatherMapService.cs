using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Services.AppAuthentication;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Ukko.API.Models;

namespace Ukko.API.Services
{
    public class OpenWeatherMapService
    {
        private readonly IOpenWeatherMapService owms;

        private string ApiKey { get; set; }

        public OpenWeatherMapService() => this.owms = RestService.For<IOpenWeatherMapService>(
                new HttpClient()
                {
                    BaseAddress = new Uri(@"https://api.openweathermap.org/data/2.5")
                },
                new RefitSettings
                {
                    JsonSerializerSettings = Utilities.JsonSettingsUtility.GetSnakeCaseJsonSerializerSettings()
                }
            );

        /// <summary>
        /// Retrieves the app key from azure key vault, and sets for use in the API service.
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetApiKeyAsync()
        {
            if (ApiKey is null)
            {
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                var secret = await new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback))
                    .GetSecretAsync(@"https://ukkokeyvault.vault.azure.net/secrets/OwmApiKey")
                    .ConfigureAwait(false);

                this.ApiKey = secret.Value;
            }

            return this.ApiKey;
        }

        /// <summary>
        /// Gets the current weather for a zip code.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public async Task<CurrentWeather> GetCurrentWeatherByZipCodeAsync(uint apiKey)
            => await this.owms.GetCurrentWeatherByZipCodeAsync(apiKey, await GetApiKeyAsync().ConfigureAwait(false)).ConfigureAwait(false);
    }
}
