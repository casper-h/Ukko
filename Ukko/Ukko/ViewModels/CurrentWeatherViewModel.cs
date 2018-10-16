using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Ukko.Models;
using Ukko.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ukko.ViewModels
{
    class CurrentWeatherViewModel : INotifyPropertyChanged
    {
        private UkkoService ukkoService;
        private CurrentWeather currentWeather;

        public CurrentWeather CurrentWeather
        {
            set
            {
                if (this.currentWeather != value)
                {
                    this.currentWeather = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentWeather"));
                }
            }
            get
            {
                return this.currentWeather;
            }
        }

        public CurrentWeatherViewModel()
        {
            this.ukkoService = new UkkoService();

            Task.Run(() => GetCurrentWeatherAsync());

            GetCurrentWeatherCommand =
                new Command(async () => await GetCurrentWeatherAsync(),
                    () => Connectivity.NetworkAccess != NetworkAccess.Internet);
        }

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands
        public ICommand GetCurrentWeatherCommand { get; private set; }

        private async Task GetCurrentWeatherAsync()
        {
            this.CurrentWeather = await this.ukkoService.GetCurrentWeatherByZipCodeAsync(34698).ConfigureAwait(false);
        }
        #endregion
    }
}