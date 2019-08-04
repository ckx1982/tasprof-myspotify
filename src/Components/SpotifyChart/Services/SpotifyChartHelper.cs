using System.Collections.Generic;
using Tasprof.Components.SpotifyModels;

namespace Tasprof.Components.SpotifyChart.Services
{
    public class SpotifyChartHelper
    {
        public static Models.SpotifyChart ConvertSpotifyPlaylistItemsToSpotifyChart(PlaylistItems playlistItems)
        {
            if (playlistItems == null || playlistItems.Items == null || playlistItems.Items.Count == 0)
            {
                return null;
            }

            return ConvertSpotifyPlaylistItemsToSpotifyChart(playlistItems.Items);
        }

        public static Models.SpotifyChart ConvertSpotifyPlaylistItemsToSpotifyChart(IList<PlaylistItem> playlistItems)
        {
            var spotifyChart = new Models.SpotifyChart();
            spotifyChart.ChartItems = new List<Models.SpotifyChartItem>();
            var count = 1;
            foreach (var playlistItem in playlistItems)
            {
                var spotifyChartItem = new Models.SpotifyChartItem
                {
                    Position = count,
                    Chart = spotifyChart,
                    ChartTrack = new Models.SpotifyChartTrack
                    {
                        Artist = playlistItem.Track.MainArtist.Name,
                        Title = playlistItem.Track.Title
                    }
                    
                };
                spotifyChart.ChartItems.Add(spotifyChartItem);
                count++;
            }
            return spotifyChart;
        }
    }
}
