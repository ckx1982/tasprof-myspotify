using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Environment = NHibernate.Cfg.Environment;

namespace Tasprof.Components.SpotifyChart.Core.Tests
{
    /// <summary>
    /// https://stackoverflow.com/questions/6353692/what-is-the-best-nhibernate-session-management-approach-for-using-in-a-multithrea/6357390#6357390
    /// </summary>
    public class SessionManager
    {
        protected static Configuration configuration;
        private static readonly ISessionFactory sessionFactory;

        static SessionManager()
        {
            configuration = new Configuration();
            configuration.SetProperty(Environment.ReleaseConnections, "on_close");
            configuration.SetProperty(Environment.ShowSql, "true");
            configuration.SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName);
            configuration.SetProperty(Environment.ConnectionString, "Data Source=:memory:;Version=3;New=True;");
            configuration.SetProperty(Environment.CurrentSessionContextClass, "thread_static"); // web, thread etc.
            configuration.AddFile("../../../../SpotifyChart/Mappings/SpotifyChart.hbm.xml");
            configuration.AddFile("../../../../SpotifyChart/Mappings/SpotifyChartItem.hbm.xml");
            configuration.AddFile("../../../../SpotifyChart/Mappings/SpotifyChartTrack.hbm.xml");
            // create session factory from database configuration
            // how do I get my db configuration in here?
            sessionFactory = configuration.BuildSessionFactory();
            new SchemaExport(configuration).Execute(false, true, false, GetCurrentSession().Connection, Console.Out);
        }

        public static ISession GetCurrentSession()
        {
            if (!CurrentSessionContext.HasBind(sessionFactory))
                CurrentSessionContext.Bind(sessionFactory.OpenSession());

            return sessionFactory.GetCurrentSession();
        }


        public static void DisposeCurrentSession()
        {
            ISession currentSession = CurrentSessionContext.Unbind(sessionFactory);

            // disconnect from connection and cleaning up
            currentSession.Close();
            // 
            currentSession.Dispose();
        }
    }

    public class InMemoryDatabase : IDisposable
    {
        protected Configuration configuration;
        protected ISessionFactory sessionFactory;

        public ISession Session { get; set; }

        /// <summary>
        /// Initializes a new InMemoryDatabase instance
        /// </summary>
        public InMemoryDatabase()
        {
            configuration = new Configuration();
            configuration.SetProperty(Environment.ReleaseConnections, "on_close");
            configuration.SetProperty(Environment.ShowSql, "true");
            configuration.SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName);
            configuration.SetProperty(Environment.ConnectionString, "Data Source=:memory:;Version=3;New=True;");
            configuration.SetProperty(Environment.CurrentSessionContextClass, "thread_static"); // web, thread etc.
            configuration.AddFile("../../../../SpotifyChart/Mappings/SpotifyChart.hbm.xml");
            configuration.AddFile("../../../../SpotifyChart/Mappings/SpotifyChartItem.hbm.xml");
            configuration.AddFile("../../../../SpotifyChart/Mappings/SpotifyChartTrack.hbm.xml");

            //Session = sessionFactory.OpenSession(); // opens a session = connection to the database that must be closed manually no context
            Session = SessionManager.GetCurrentSession(); // contextual session = connection to the database is closed when context finishes?
            new SchemaExport(configuration).Execute(false, true, false, Session.Connection, Console.Out);
        }

        public void Dispose()
        {
            //Session.Dispose()
            SessionManager.DisposeCurrentSession();
            //sessionFactory.Dispose();
        }
    }
}
