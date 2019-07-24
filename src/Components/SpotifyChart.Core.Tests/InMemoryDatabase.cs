using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Environment = NHibernate.Cfg.Environment;

namespace Tasprof.Components.SpotifyChart.Core.Tests
{
    public class InMemoryDatabase : IDisposable
    {
        protected Configuration configuration;
        protected ISessionFactory sessionFactory;

        public ISession Session { get; set; }

        public InMemoryDatabase()
        {
            configuration = new Configuration();
            configuration.SetProperty(Environment.ReleaseConnections, "on_close");
            configuration.SetProperty(Environment.ShowSql, "true");
            configuration.SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName);
            configuration.SetProperty(Environment.ConnectionString, ":memory:");
            configuration.AddFile("../SpotifyChart/Mappings.SpotifyChart.hbm.xml");
            configuration.AddFile("../SpotifyChart/Mappings.SpotifyChartItem.hbm.xml");
            Session = sessionFactory.OpenSession();
            new SchemaExport(configuration).Execute(true, true, false, Session.Connection, Console.Out);
        }

        public void Dispose()
        {
            Session.Dispose();
            sessionFactory.Dispose();
        }
    }
}
