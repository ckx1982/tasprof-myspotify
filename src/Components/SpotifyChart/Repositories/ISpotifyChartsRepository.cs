using System;
using System.Collections.Generic;
using System.Text;

namespace Tasprof.Components.SpotifyChart.Repositories
{
    public interface ISpotifyChartsRepository
    {
        IList<Models.SpotifyChart> Get();

        Models.SpotifyChart Get(int id);

        Models.SpotifyChart Add(Models.SpotifyChart chart);

        void Update(Models.SpotifyChart chart);

        void Delete(Models.SpotifyChart chart);

        void Save();

    }
}
