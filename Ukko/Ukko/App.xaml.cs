using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ukko.Services;
using Ukko.Views;
using System.Diagnostics;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Ukko
{
    public partial class App : Application
    {
        public static readonly bool IS_DEBUG = Debugger.IsAttached;

        public App()
        {
            InitializeComponent();

            MainPage = new CurrentWeatherView();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=8f224560-7adf-459d-8a1a-b460af92f55f;", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
