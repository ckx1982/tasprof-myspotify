using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using Tasprof.Components.SpotifyChart.Repositories;

namespace Tasprof.Components.SpotifyChart.Core.Tests.Repositories
{
    [TestClass]
    public class SpotifyChartsRepositoryTest : BaseRepositoryTest
    {

        [TestMethod]
        public void TestInsertChartWithNewTracks()
        {
            // Arrange
            ISpotifyChartsRepository spotifyChartsRepository = new SpotifyChartsRepository(session);

            var chart = new Models.SpotifyChart
            {
                Created = DateTime.Now,
                ValidUntil = DateTime.Today.AddDays(7),
                ValidFrom = DateTime.Today,
            };

            var chartTracks = new List<Models.SpotifyChartTrack>
                    {
                        new Models.SpotifyChartTrack
                        {
                            Artist = "Prince",
                            Title = "1999",
                            Created = DateTime.Now,
                            Updated = DateTime.Now
                        },
                        new Models.SpotifyChartTrack
                        {
                            Artist = "Madonna",
                            Title = "Like A Prayer",
                            Created = DateTime.Now,
                            Updated = DateTime.Now
                        }
                    };

            foreach (var item in chartTracks)
            {
                chart.AddChartTrack(item);
            };

            int insertedChartId = 0;
            Models.SpotifyChart spotifyChartFromDb = null;

            // Act
            using (var transaction = SessionManager.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    insertedChartId = spotifyChartsRepository.Insert(chart).Id;

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }


            // Assert
            using (var transaction = SessionManager.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    spotifyChartFromDb = session.Get<Models.SpotifyChart>(insertedChartId);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            Assert.IsNotNull(spotifyChartFromDb);
            Assert.AreEqual(2, spotifyChartFromDb.ChartItems.Count);

            Assert.IsTrue(spotifyChartFromDb.ChartItems[0].Id > 0);
            Assert.AreEqual("Prince", spotifyChartFromDb.ChartItems[0].ChartTrack.Artist);
            Assert.AreEqual("1999", spotifyChartFromDb.ChartItems[0].ChartTrack.Title);

            Assert.IsTrue(spotifyChartFromDb.ChartItems[1].Id > 0);
            Assert.AreEqual("Madonna", spotifyChartFromDb.ChartItems[1].ChartTrack.Artist);
            Assert.AreEqual("Like A Prayer", spotifyChartFromDb.ChartItems[1].ChartTrack.Title);

        }


        //[TestMethod]
        //public void TestInsertChartWithExistingTracks()
        //{
        //    // Arrange
        //    ISpotifyChartsRepository spotifyChartsRepository = new SpotifyChartsRepository(session);

        //    var chart = new Models.SpotifyChart
        //    {
        //        Created = DateTime.Now,
        //        ValidFrom = DateTime.Today,
        //        ValidUntil = DateTime.Today.AddDays(7)
        //    };

        //    var chartTracks = new List<Models.SpotifyChartTrack>
        //            {
        //                new Models.SpotifyChartTrack
        //                {
        //                    Artist = "Cher",
        //                    Title = "Believe",
        //                    Created = DateTime.Now,
        //                    Updated = DateTime.Now
        //                },
        //                new Models.SpotifyChartTrack
        //                {
        //                    Artist = "Michael Jackson",
        //                    Title = "Man In The Mirror",
        //                    Created = DateTime.Now,
        //                    Updated = DateTime.Now
        //                }
        //            };

        //    foreach (var item in chartTracks)
        //    {
        //        chart.AddChartTrack(item);
        //    };

        //    int insertedChartId = 0;
        //    Models.SpotifyChart spotifyChartFromDb = null;

        //    // Act
        //    using (var transaction = session.BeginTransaction())
        //    {
        //        try
        //        {
        //            insertedChartId = spotifyChartsRepository.Insert(chart).Id;

        //            transaction.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            transaction.Rollback();
        //            throw;
        //        }
        //    }

        //    // Assert
        //    Assert.IsNotNull(spotifyChartFromDb);
        //    Assert.AreEqual(2, spotifyChartFromDb.ChartItems.Count);

        //    Assert.IsTrue(spotifyChartFromDb.ChartItems[0].Id > 0);
        //    Assert.AreEqual("Prince", spotifyChartFromDb.ChartItems[0].ChartTrack.Artist);
        //    Assert.AreEqual("1999", spotifyChartFromDb.ChartItems[0].ChartTrack.Title);

        //    Assert.IsTrue(spotifyChartFromDb.ChartItems[1].Id > 0);
        //    Assert.AreEqual("Madonna", spotifyChartFromDb.ChartItems[1].ChartTrack.Artist);
        //    Assert.AreEqual("Like A Prayer", spotifyChartFromDb.ChartItems[1].ChartTrack.Title);
        //}
    }
}
