using System;
using Microsoft.EntityFrameworkCore;

namespace SpotifyChart.WebAPI
{
    public class SpotifyChartDbContext : DbContext
    {
        public SpotifyChartDbContext(DbContextOptions<SpotifyChartDbContext> options) : base(options)
        {
        }

        public DbSet<Tasprof.Components.SpotifyChart.Models.SpotifyChart> SpotifyCharts {get; set; }
        public DbSet<Tasprof.Components.SpotifyChart.Models.SpotifyChartItem> SpotifyChartItems { get; set; }
    }
}
