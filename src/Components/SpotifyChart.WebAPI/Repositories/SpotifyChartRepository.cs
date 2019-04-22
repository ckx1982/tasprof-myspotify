using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasprof.Components.SpotifyChart.ViewModels;

namespace SpotifyChart.WebAPI.Repositories
{
    public class SpotifyChartRepository : ISpotifyChartRepository
    {
        private readonly SpotifyChartDbContext context;

        public SpotifyChartRepository(SpotifyChartDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SpotifyChartViewModel>> GetAll()
        {
            return await this.context.SpotifyCharts.Select(
               x => new SpotifyChartViewModel
               {
                   Items = x.Items.Select(
                       c => new SpotifyChartItemViewModel
                       {
                           Artist = c.Artist,
                           Title = c.Title
                           
                       })
               }).ToListAsync();
        }
    }
}
