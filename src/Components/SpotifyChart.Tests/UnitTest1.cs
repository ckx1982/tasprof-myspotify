using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Tasprof.Components.SpotifyChart.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize]
        public static void TestStart(TestContext testContext)
        {

        }

        [ClassCleanup]
        public static void TestEnd(TestContext testContext)
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(SpotifyChart.Models.SpotifyChart).Assembly);
            new SchemaExport(cfg).Execute(true, true, false);

            var sessionFactory = cfg.BuildSessionFactory();
            var session = sessionFactory.OpenSession();

            object id;
            using (var transaction = session.BeginTransaction())
            {

                var track = new Models.SpotifyChartTrack
                {
                    Artist = "Prince",
                    Title = "1999"
                };

                var trackid = session.Save(track);

                var chart = new Models.SpotifyChart
                {
                    ValidFrom = DateTime.Today,
                    ValidUntil = DateTime.Today.AddDays(7),
                };

                chart.AddChartTrack(track);


                id = session.Save(chart);
                    
                transaction.Commit();
            }

            using (var transaction = session.BeginTransaction())
            {

                var chart = session.Get<Models.SpotifyChart>(id);

                transaction.Commit();
            }
        }
    }
}
