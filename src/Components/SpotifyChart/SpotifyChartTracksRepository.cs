using NHibernate;
using System.Linq;
using Tasprof.Components.SpotifyChart.Models;
using Tasprof.Components.SpotifyChart.Repositories;

namespace Tasprof.Components.SpotifyChart
{
    public class SpotifyChartTracksRepository : ISpotifyChartTracksRepository
    {
        private ISession session;

        public SpotifyChartTracksRepository(ISession session)
        {
            this.session = session;
        }

        public IQueryable<SpotifyChartTrack> Get()
        {
            return session.Query<SpotifyChartTrack>();
        }
    }
}
