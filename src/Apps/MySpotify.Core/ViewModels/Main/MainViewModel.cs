using MvvmCross.Commands;
using MvvmCross.Navigation;
using Tasprof.Apps.MySpotify.Core.ViewModels.PlayHistory;
using Tasprof.Apps.MySpotify.Core.ViewModels.Playlists;
using Tasprof.Apps.MySpotify.Core.ViewModels.Toplists;

namespace Tasprof.Apps.MySpotify.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        public IMvxAsyncCommand NavigateCommand { get; private set; }
        public IMvxAsyncCommand PlaylistsCommand { get; private set; }
        public IMvxAsyncCommand RecentlyPlayedCommand { get; private set; }

        public string RedirectUri
        {
            get { return _globalSettingsService.RedirectUri; }
            set { _globalSettingsService.RedirectUri = value; }
        }

        public string ClientId
        {
            get { return _globalSettingsService.ClientId; }
        }

        public string AccessToken
        {
            get { return _globalSettingsService.AccessToken; }
            set
            {
                _globalSettingsService.AccessToken = value;
            }
        }

        public string AuthorizationCode
        {
            get { return _globalSettingsService.AuthorizationCode; }
            set { _globalSettingsService.AuthorizationCode = value; }
        }

        private readonly IMvxNavigationService _navigationService;
        private readonly IGlobalSettingsService _globalSettingsService;

        public MainViewModel(IMvxNavigationService navigationService, IGlobalSettingsService globalSettings)
        {
            _navigationService = navigationService;
            _globalSettingsService = globalSettings;
            NavigateCommand = new MvxAsyncCommand(() => _navigationService.Navigate<TabsViewModel>());
            PlaylistsCommand = new MvxAsyncCommand(() => _navigationService.Navigate<PlaylistsViewModel>());
            RecentlyPlayedCommand = new MvxAsyncCommand(() => _navigationService.Navigate<PlayHistoryViewModel>());
        }
    }
}
