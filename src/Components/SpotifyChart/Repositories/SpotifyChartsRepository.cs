using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasprof.Components.SpotifyChart.Models;

namespace Tasprof.Components.SpotifyChart.Repositories
{
    public class SpotifyChartsRepository : ISpotifyChartsRepository
    {

        private readonly ISession session;

        public SpotifyChartsRepository(ISession session)
        {
            this.session = session;
        }


        public IQueryable<Models.SpotifyChart> Get()
        {
           return session.Query<Models.SpotifyChart>();
        }

        public Models.SpotifyChart Get(int id)
        {
            return session.Get<Models.SpotifyChart>(id);
        }


        public Models.SpotifyChart Insert(Models.SpotifyChart chart)
        {
            session.Save(chart);
            return chart;
        }

        public void Update(Models.SpotifyChart chart)
        {
            session.Update(chart);
        }

        public void Delete(Models.SpotifyChart chart)
        {
            session.Delete(chart);
        }

    }
}
