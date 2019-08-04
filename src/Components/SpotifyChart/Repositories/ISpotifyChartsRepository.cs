using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasprof.Components.SpotifyChart.Repositories
{
    public interface ISpotifyChartsRepository
    {
        IQueryable<Models.SpotifyChart> Get();

        Models.SpotifyChart Get(int id);

        Models.SpotifyChart Insert(Models.SpotifyChart chart);

        void Update(Models.SpotifyChart chart);

        void Delete(Models.SpotifyChart chart);

    }
}
