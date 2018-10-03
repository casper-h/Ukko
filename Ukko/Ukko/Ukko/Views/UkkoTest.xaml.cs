using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ukko.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ukko.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UkkoTest : ContentPage
	{
        private readonly UkkoService us;

		public UkkoTest ()
		{
			InitializeComponent ();

            this.us = new UkkoService();

            var test = this.us.GetCurrentWeatherByZipCodeAsync(34698).Result;
		}
	}
}