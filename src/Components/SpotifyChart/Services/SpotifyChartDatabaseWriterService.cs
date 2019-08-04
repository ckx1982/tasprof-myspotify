using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using Tasprof.Components.SpotifyChart.Repositories;
using Tasprof.Components.SpotifyModels;

namespace Tasprof.Components.SpotifyChart.Services
{
    public class SpotifyChartDatabaseWriterService : ISpotifyChartWriterService
    {
        private ISession session;

        private ISpotifyChartTracksRepository spotifyChartTracksRepository;

        public SpotifyChartDatabaseWriterService(ISession session)
        {
            this.session = session;
        }

        public void WritePlaylistToSpotifyChart(PlaylistItems playlistItems)
        {
            if (playlistItems == null || playlistItems.Items == null || playlistItems.Items.Count == 0)
                return;

            using (var unitOfWork = new UnitOfWork(session))
            {
                try
                {
                    // get chart tracks from db
                    // for now we are getting all - optimize to get only tracks from playlist
                    var spotifyChartTracks = unitOfWork.SpotifyChartTracksRepository.Get().ToDictionary(x => String.Concat(x.Artist, x.Title));

                    var spotifyChart = new Models.SpotifyChart
                    {
                        Created = DateTime.Now,
                        ValidUntil = DateTime.Today.AddDays(7),
                        ValidFrom = DateTime.Today,
                    };

                    foreach (var playlistItem in playlistItems.Items)
                    {
                        Models.SpotifyChartTrack spotifyChartTrackToAdd;
                        if (!spotifyChartTracks.TryGetValue(String.Concat(playlistItem.Track.MainArtist.Name, playlistItem.Track.Title), out spotifyChartTrackToAdd))
                        {
                            spotifyChartTrackToAdd = new Models.SpotifyChartTrack
                            {
                                Artist = playlistItem.Track.MainArtist.Name,
                                Title = playlistItem.Track.Title,
                                Created = DateTime.Now,
                                Updated = DateTime.Now
                            };
                        }
                        spotifyChart.AddChartTrack(spotifyChartTrackToAdd);
                    }

                    unitOfWork.SpotifyChartsRepository.Insert(spotifyChart);
                    unitOfWork.Commit();

                }
                catch (Exception e)
                {

                }
            }
        }
    }
}