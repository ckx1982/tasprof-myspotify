﻿using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotify.Core.Interfaces;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Navigation;
using Tasprof.Apps.MySpotify.Core.Services.Spotify;

namespace Tasprof.Apps.MySpotify.Core.ViewModels.PlayHistory
{
    public class PlayHistoryViewModel : BaseViewModel, ILoadingMoreViewModel
    {
        private readonly ISpotifyService _spotifyService;
        private readonly IMvxNavigationService _navigationService;
        private readonly int _limit = 15;
        private long _before = DateTimeOffset.Now.ToUnixTimeMilliseconds();


        private string _isLoading = "invisible";
        public string IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private MvxObservableCollection<PlayHistoryItemViewModel> _playHistoryItems; 
        public MvxObservableCollection<PlayHistoryItemViewModel> PlayHistoryItems { get { return _playHistoryItems; } set { SetProperty(ref _playHistoryItems, value); } }

        private IMvxAsyncCommand _loadMoreItemsCommand => new MvxAsyncCommand(LoadMoreItems);
        IMvxAsyncCommand ILoadingMoreViewModel.LoadMoreItemsCommand { get => _loadMoreItemsCommand; }

        //public IMvxAsyncCommand<PlayHistoryItemViewModel> PlayTrackCommand { get; private set; }

        public PlayHistoryViewModel(IMvxNavigationService navigationService, ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
            _navigationService = navigationService;
            //PlayTrackCommand = new MvxAsyncCommand<PlayHistoryItemViewModel>(OnPlayTrackClicked);
        }

        public async override Task Initialize()
        {
            await base.Initialize();
            _playHistoryItems = new MvxObservableCollection<PlayHistoryItemViewModel>();
            IsLoading = "visible";
            await LoadItems();
            IsLoading = "invisible";

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
                PlayHistoryItems.Add(new PlayHistoryItemViewModel(_navigationService, _spotifyService, item));
            }

          
            //PlayHistoryItems.AddRange(playHistory.Items);
        }

        //private Task OnPlayTrackClicked(PlayHistoryItem item)
        //{
        //    return _navigationService.Navigate<PlayHistoryItemViewModel, PlayHistoryItemNavigationArgs>(new PlayHistoryItemNavigationArgs() { TrackUri = item.Track.Uri }); 
        //}
    }
}
