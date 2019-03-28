using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotifyDroid.Models;
using Tasprof.Apps.MySpotifyDroid.Services.Spotify;

namespace Tasprof.Apps.MySpotifyDroid.ViewModels
{
    public class PlayHistoryViewModel : MvxViewModel
    {
        private readonly ISpotifyService _spotifyService;
        private readonly int _limit = 10;
        private long _before = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        public IMvxAsyncCommand LoadMoreItemsCommand => new MvxAsyncCommand(LoadMoreItems);

        private MvxObservableCollection<PlayHistoryItem> _playHistoryItems; 
        public MvxObservableCollection<PlayHistoryItem> PlayHistoryItems { get { return _playHistoryItems; } set { SetProperty(ref _playHistoryItems, value); } }

        public PlayHistoryViewModel(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async override Task Initialize()
        {
            await base.Initialize();
            _playHistoryItems = new MvxObservableCollection<PlayHistoryItem>();
            await LoadItems();
        }

        public async Task LoadMoreItems()
        {
            await LoadItems();
        }

        private async Task LoadItems()
        {
            var playHistory = await _spotifyService.GetRecentlyPlayedTracks(_before, _limit);
            _before = playHistory.Cursors.Before;
            PlayHistoryItems.AddRange(playHistory.Items);
            //PlayHistoryItems = PlayHistoryItems;
        }
    }
}
