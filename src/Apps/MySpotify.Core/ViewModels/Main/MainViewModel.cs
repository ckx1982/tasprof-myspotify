using MvvmCross.Commands;
using MvvmCross.Navigation;
using Tasprof.Apps.MySpotify.Core.ViewModels.PlayHistory;
using Tasprof.Apps.MySpotify.Core.ViewModels.Playlists;
using Tasprof.Apps.MySpotify.Core.ViewModels.Toplists;

namespace Tasprof.Apps.MySpotify.Core.ViewModels.Main
{
    public class MainViewModel: BaseViewModel
    {
        public IMvxAsyncCommand NavigateCommand { get; private set; }
        public IMvxAsyncCommand PlaylistsCommand { get; private set; }
        public IMvxAsyncCommand RecentlyPlayedCommand { get; private set; }

        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new MvxAsyncCommand(() => _navigationService.Navigate<TabsViewModel>());
            PlaylistsCommand = new MvxAsyncCommand(() => _navigationService.Navigate<PlaylistsViewModel>());
            RecentlyPlayedCommand = new MvxAsyncCommand(() => _navigationService.Navigate<PlayHistoryViewModel>());

        }
    }
}
