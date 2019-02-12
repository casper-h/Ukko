using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ukko.API.Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        { }

        public DbSet<Api> OpenWeatherMapsApiConfig { get; set; }
    }
}