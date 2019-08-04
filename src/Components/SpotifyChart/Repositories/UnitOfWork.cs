using NHibernate;
using System;

namespace Tasprof.Components.SpotifyChart.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private ISpotifyChartsRepository spotifyChartsRepository;
        private ISpotifyChartTracksRepository spotifyChartTracksRepository;
        private readonly ISession session;
        private ITransaction transaction;

        public UnitOfWork(ISession session)
        {
            this.session = session;
            this.transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            if (!this.transaction.IsActive)
            {
                throw new InvalidOperationException("No active transaction");
            }

            this.transaction.Commit();
        }

        public void Rollback()
        {
            if (this.transaction.IsActive)
            {
                this.transaction.Rollback();
            }
        }

        public void Dispose()
        {
            if(this.transaction.IsActive)
            {
                this.transaction.Rollback();
            }
        }

        public ISpotifyChartsRepository SpotifyChartsRepository
        {
            get
            {
                if (this.spotifyChartsRepository == null)
                {
                    this.spotifyChartsRepository = new SpotifyChartsRepository(session);
                }
                return this.spotifyChartsRepository;
            }
        }

        public ISpotifyChartTracksRepository SpotifyChartTracksRepository
        {
            get
            {
                if (this.spotifyChartTracksRepository == null)
                {
                    this.spotifyChartTracksRepository = new SpotifyChartTracksRepository(session);
                }
                return this.spotifyChartTracksRepository;
            }
        }
    }
}
