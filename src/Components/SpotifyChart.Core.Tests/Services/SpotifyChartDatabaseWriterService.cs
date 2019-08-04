using Newtonsoft.Json;
using NUnit;
using NUnit.Framework;
using System.IO;
using System.Linq;
using Tasprof.Components.SpotifyChart.Models;
using Tasprof.Components.SpotifyChart.Services;
using Tasprof.Components.SpotifyModels;

namespace Tasprof.Components.SpotifyChart.Core.Tests.Services
{
    [TestFixture]
    public class SpotifyChartDatabaseWriterServiceTest: BaseServiceTest
    {
        [Test]
        public void TestWriteSpotifyChartWithExistingTracks()
        {
            // Arrange
            ISpotifyChartWriterService spotifyChartWriterService = new SpotifyChartDatabaseWriterService(session);

            var testDataFilename = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Data\T001_playlistitems.json");
            var testData = File.ReadAllText(testDataFilename);

            PlaylistItems playlistItems = JsonConvert.DeserializeObject<PlaylistItems>(testData);

            Assert.IsNotNull(playlistItems);
            Assert.IsNotNull(playlistItems.Items);
            Assert.IsTrue(playlistItems.Items.Count > 0);

            // Act
            spotifyChartWriterService.WritePlaylistToSpotifyChart(playlistItems);

            // Assert
            var charts = session.Query<Models.SpotifyChart>().ToList();
            Assert.IsTrue(charts.Count > 0);
        }

    }

}


