using System;
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
        }
    }
}
