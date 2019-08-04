using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasprof.Components.SpotifyChart.Core.Tests.Repositories
{
    [TestClass]
    public class BaseRepositoryTest: IDisposable
    {
        //protected static InMemoryDatabase database;
        protected static ISession session = SessionManager.GetCurrentSession();

        static BaseRepositoryTest()
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
