using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ukko.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ukko.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CurrentWeatherView : ContentPage
	{
		public CurrentWeatherView ()
		{
			InitializeComponent ();
            BindingContext = new CurrentWeatherViewModel();
        }
	}
}