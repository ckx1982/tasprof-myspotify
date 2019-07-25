using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;

namespace Tasprof.Components.SpotifyChart.Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private InMemoryDatabase database;
        private ISession session;

        [TestInitialize]
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
                id = session.Save(new SpotifyChart.Models.SpotifyChart());
                transaction.Commit();
            }

            session.Clear();

            using(var transaction = session.BeginTransaction())
            {
                //var chart = session.Get<SpotifyChart.Models.SpotifyChart>(id);
                //Assert.AreEqual("My first Chart", chart.Title);
                var query = session.CreateSQLQuery("select * from charts where id = :id and created = :created");
                query.SetParameter("id", id);
                query.SetParameter("created", DateTime.Today);
                var result = query.List();
                transaction.Commit();
            }
        }
    }
}
