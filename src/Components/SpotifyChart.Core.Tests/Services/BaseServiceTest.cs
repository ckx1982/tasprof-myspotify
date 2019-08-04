using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasprof.Components.SpotifyChart.Core.Tests.Services
{
    [TestClass]
    public class BaseServiceTest : IDisposable
    {
        //protected static InMemoryDatabase database;
        protected static ISession session = SessionManager.GetCurrentSession();

        static BaseServiceTest()
        {
            using (var transaction = SessionManager.GetCurrentSession().BeginTransaction())
            {
                var chartTracks = new List<Models.SpotifyChartTrack>
                {
                    new Models.SpotifyChartTrack
                    {
                        Artist = "Michael Jackson",
                        Title = "Man In The Mirror",
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

                foreach (var chartTrack in chartTracks)
                {
                    SessionManager.GetCurrentSession().Save(chartTrack);
                }

                transaction.Commit();
            }
        }

        public void Dispose()
        {
            SessionManager.DisposeCurrentSession();
        }
    }
}
