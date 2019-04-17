using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasprof.Components.SpotifyChart.Models;
using Tasprof.Components.SpotifyClient.Models;
using Tasprof.Components.SpotifyClient.Services.Spotify;

namespace Tasprof.Components.SpotifyClient.Services.SpotifyChart
{
    public class SpotifyChartService : ISpotifyChartService
    {
        private readonly ISpotifyService _spotifyService;

        public SpotifyChartService(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<Components.SpotifyChart.Models.SpotifyChart> CreateChart(string playlistId)
        {
            var result = await _spotifyService.GetPlaylistItems(playlistId);

            var spotifyChart = new Components.SpotifyChart.Models.SpotifyChart
            {
                Items = GetSpotifyChartItems(result)
            };

            return spotifyChart;
        }

        private IEnumerable<SpotifyChartItem> GetSpotifyChartItems(List<PlaylistItem> result)
        {
            var items = new List<SpotifyChartItem>();
            var position = 1;
            foreach (var item in result)
            {
                items.Add(
                    new SpotifyChartItem
                    {
                        Artist = item.Track.MainArtist.Name,
                        Title = item.Track.Title,
                        Position =  position
                    }
                );
                position++;
            }
            return items;
        }
    }
}
