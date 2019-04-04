using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotifyDroid.Interfaces;
using Tasprof.Apps.MySpotifyDroid.Models;
using Tasprof.Apps.MySpotifyDroid.Services.Spotify;

namespace Tasprof.Apps.MySpotifyDroid.ViewModels
{
    public class PlayHistoryViewModel : MvxViewModel, ILoadingMoreViewModel
    {
        private readonly ISpotifyService _spotifyService;
        private readonly int _limit = 15;
        private long _before = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        private MvxObservableCollection<PlayHistoryItem> _playHistoryItems; 
        public MvxObservableCollection<PlayHistoryItem> PlayHistoryItems { get { return _playHistoryItems; } set { SetProperty(ref _playHistoryItems, value); } }

        private IMvxAsyncCommand _loadMoreItemsCommand => new MvxAsyncCommand(LoadMoreItems);
        IMvxAsyncCommand ILoadingMoreViewModel.LoadMoreItemsCommand { get => _loadMoreItemsCommand; }

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

            foreach (var item in playHistory.Items)
            {
                PlayHistoryItems.Add(item);
            }
            //PlayHistoryItems.AddRange(playHistory.Items);
        }
    }
}
