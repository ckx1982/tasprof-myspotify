using NHibernate;
using System;
using System.Collections.Generic;
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

        public Models.SpotifyChart Add(Models.SpotifyChart chart)
        {
            throw new NotImplementedException();
        }

        public void Delete(Models.SpotifyChart chart)
        {
            throw new NotImplementedException();
        }

        public IList<Models.SpotifyChart> Get()
        {
            throw new NotImplementedException();
        }

        public Models.SpotifyChart Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Models.SpotifyChart chart)
        {
            throw new NotImplementedException();
        }
    }
}
