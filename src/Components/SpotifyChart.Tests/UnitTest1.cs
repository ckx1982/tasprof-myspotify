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
        [TestMethod]
        public void TestMethod1()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(SpotifyChart.Models.SpotifyChart).Assembly);
            new SchemaExport(cfg).Execute(true, true, false);

            var sessionFactory = cfg.BuildSessionFactory();
            var session = sessionFactory.OpenSession();

            using (var transaction = session.BeginTransaction())
            {

                var id = session.Save(
                    new Models.SpotifyChart
                    {
                        ValidFrom = DateTime.Today,
                        ValidUntil = DateTime.Today.AddDays(7),
                        Items = new List<Models.SpotifyChartItem>
                        {
                           new Models.SpotifyChartItem
                           {
                               Position = 1,
                               ChartTrack = new Models.SpotifyChartTrack
                               {
                                   Artist = "Prince",
                                   Title = "1999"
                               }
                           }
                        }
                    }
                );

                transaction.Commit();
            }
        }
    }
}
