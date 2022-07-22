using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using React.NetCore6SwaggerOdataEntityFramework;

namespace React.NetCore6SwaggerOdataEntityFramework.Data
{
    public class ReactNetCore6SwaggerOdataEntityFrameworkContext : DbContext
    {
        public ReactNetCore6SwaggerOdataEntityFrameworkContext (DbContextOptions<ReactNetCore6SwaggerOdataEntityFrameworkContext> options)
            : base(options)
        {
        }

        public DbSet<React.NetCore6SwaggerOdataEntityFramework.WeatherForecast> WeatherForecast { get; set; } = default!;
    }
}
