using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Tasprof.Components.SpotifyChart.Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private InMemoryDatabase database;
        private ISession session;

        [ClassInitialize]
        public void SetupDatabase()
        {
            database = new InMemoryDatabase();
            session = database.Session;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(SpotifyChart.Models.SpotifyChart).Assembly);
            new SchemaExport(cfg).Execute(true, true, false);
        }


        [TestMethod]
        public void TestMethod2()
        {
            object id;
            using(var transaction = session.BeginTransaction())
            {
                id = session.Save(new SpotifyChart.Models.SpotifyChart
                {
                    Title = "My first Chart"
                  
                });
                transaction.Commit();
            }

            session.Clear();

            using(var transaction = session.BeginTransaction())
            {
                var chart = session.Get<SpotifyChart.Models.SpotifyChart>(id);
                Assert.AreEqual("My first Chart", chart.Title);
                transaction.Commit();
            }
        }

    }
}
