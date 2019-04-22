using System.Collections.Generic;
using System.Threading.Tasks;
using Tasprof.Components.SpotifyChart.ViewModels;

namespace SpotifyChart.WebAPI.Repositories
{
    public interface ISpotifyChartRepository
    {
        Task<IEnumerable<SpotifyChartViewModel>> GetAll();
    }
}