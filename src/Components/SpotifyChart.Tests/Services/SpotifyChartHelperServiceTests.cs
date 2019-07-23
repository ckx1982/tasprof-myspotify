using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Tasprof.Components.SpotifyChart.Services;
using Tasprof.Components.SpotifyModels;

namespace Tasprof.Components.SpotifyChart.Tests.Services
{
    [TestClass]
    public class SpotifyChartHelperServiceTests
    {
        [TestMethod]
        public void T001_ConvertPlaylistItemsToSpotifyChart_ReturnsNNull()
        {
            // Arrange
            var playlistItems = new PlaylistItems
            {
                Items = new List<PlaylistItem>()
            };

            ISpotifyChartHelperService spotifyChartHelper = new SpotifyChartHelperService();

            // Act
            Models.SpotifyChart spotifyChart = spotifyChartHelper.ConvertSpotifyPlaylistItemsToSpotifyChart(playlistItems);

            // Assert
            Assert.IsNull(spotifyChart);
        }

        [TestMethod]
        public void T002_ConvertPlaylistItemsToSpotifyChart_ReturnsNotNull()
        {
            // Arrange
            var playlistItems = new PlaylistItems {
                Items = new List<PlaylistItem>
                {
                    new PlaylistItem
                    {
                        Track = new Track
                        {
                            Artists = new List<Artist>
                            {
                                new Artist
                                {
                                     Name = "Artist 1"
                                }
                            },
                            Title = "Title 1"
                        }
                    },
                    new PlaylistItem
                    {
                        Track = new Track
                        {
                            Artists = new List<Artist>
                            {
                                new Artist
                                {
                                     Name = "Artist 2"
                                }
                            },
                            Title = "Title 2"
                        }
                    }
                }
            };

            ISpotifyChartHelperService spotifyChartHelper = new SpotifyChartHelperService();

            // Act
            Models.SpotifyChart spotifyChart = spotifyChartHelper.ConvertSpotifyPlaylistItemsToSpotifyChart(playlistItems);

            // Assert
            Assert.IsNotNull(spotifyChart);
            Assert.AreEqual(2, spotifyChart.Items.Count());
            Assert.AreEqual(1, spotifyChart.Items.First().Position);
            Assert.AreEqual(2, spotifyChart.Items.Last().Position);
        }
    }
}
