using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Tasprof.Apps.MySpotifyDroid.Models;
using Tasprof.Apps.MySpotifyDroid.Navigation;
using Tasprof.Apps.MySpotifyDroid.Services.Spotify;

namespace Tasprof.Apps.MySpotifyDroid.ViewModels
{
    public class PlaylistsViewModel : MvxViewModel
    {
        private readonly ISpotifyService _spotifyService;
        private readonly IMvxNavigationService _navigationService;
        public IMvxAsyncCommand<Playlist> NavigateToPlaylistCommand { get; private set; }
        //public IMvxAsyncCommand<Playlist> PlaylistCommand => new MvxAsyncCommand<Playlist>(OnPlayListClicked);

        private List<Playlist> _playlists;
        public List<Playlist> Playlists 
        {
            get { return _playlists; }
            set { SetProperty(ref _playlists, value);  }
        }

        public PlaylistsViewModel(IMvxNavigationService navigationService, ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
            _navigationService = navigationService;

            NavigateToPlaylistCommand = new MvxAsyncCommand<Playlist>(OnPlayListClicked);
        }

        private Task OnPlayListClicked(Playlist playlist)
        {
           return _navigationService.Navigate<PlaylistViewModel, PlaylistNavigationArgs>(new PlaylistNavigationArgs() { PlaylistId = playlist.Id });
        }

        public async override Task Initialize()
        {
            await base.Initialize();
            //var result = await _requestService.GetAsync<Playlists>(CreateRequestUri(), GlobalSettings.Instance.AuthToken);
            //Playlists = result.Items;
            Playlists = await _spotifyService.GetPlaylists();
        }

       
    }
}
