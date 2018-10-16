using System;
using System.Collections.Generic;
using System.Text;

namespace Ukko.Utilities
{
    public static class WeatherUtility
    {
        public static double ConvertKelvinToFahrenheit(double degreesInKelvin)
            => (degreesInKelvin * ((double)9 / (double)5)) - 459.67;
    }
}
