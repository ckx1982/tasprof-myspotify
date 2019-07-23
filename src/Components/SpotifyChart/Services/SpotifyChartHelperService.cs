﻿using System;
using System.Collections.Generic;
using Tasprof.Components.SpotifyChart.Models;
using Tasprof.Components.SpotifyModels;

namespace Tasprof.Components.SpotifyChart.Services
{
    public class SpotifyChartHelperService : ISpotifyChartHelperService
    {
        public Models.SpotifyChart ConvertSpotifyPlaylistItemsToSpotifyChart(PlaylistItems playlistItems)
        {
            if (playlistItems == null || playlistItems.Items == null || playlistItems.Items.Count == 0)
            {
                return null;
            }

            return ConvertSpotifyPlaylistItemsToSpotifyChart(playlistItems.Items);
        }

        public Models.SpotifyChart ConvertSpotifyPlaylistItemsToSpotifyChart(IList<PlaylistItem> playlistItems)
        {
            var spotifyChart = new Models.SpotifyChart();
            spotifyChart.Items = new List<Models.SpotifyChartItem>();
            var count = 1;
            foreach (var playlistItem in playlistItems)
            {
                var spotifyChartItem = new Models.SpotifyChartItem
                {
                    Artist = playlistItem.Track.MainArtist.Name,
                    Position = count,
                    Title = playlistItem.Track.Title,
                    Chart = spotifyChart
                };
                spotifyChart.Items.Add(spotifyChartItem);
                count++;
            }
            return spotifyChart;
        }
    }
}