using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasprof.Components.SpotifyChart.Repositories
{
    public interface ISpotifyChartTracksRepository
    {
        IQueryable<Models.SpotifyChartTrack> Get();
    }
}