using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using Tasprof.Components.SpotifyChart.Services;

namespace Tasprof.Components.SpotifyChart.Tests.Services
{
    [TestClass]
    public class SpotifyChartExportServiceTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var spotifyChart = new Models.SpotifyChart
            {
                ChartItems = new List<Models.SpotifyChartItem>
                {
                    new Models.SpotifyChartItem
                    {
                        Position = 1,
                        ChartTrack = new Models.SpotifyChartTrack
                        {
                            Artist = "Artist 1",
                            Title = "Title 1"
                        },
                    },
                    new Models.SpotifyChartItem
                    {
                        Position = 2,
                         ChartTrack = new Models.SpotifyChartTrack
                         {
                            Artist = "Artist 2",
                            Title = "Title 2"
                         }
                    }
                }
            };

            ISpotifyChartExportService spotifyChartExportService = new SpotifyChartExcelExportService();

            // Act
            spotifyChartExportService.ExportChart(spotifyChart, Path.Combine(TestContext.TestDeploymentDir, "export.xlsx"));

            // Assert
            Assert.IsTrue(File.Exists(Path.Combine(TestContext.TestDeploymentDir, "export.xlsx")));
        }
    }
}
