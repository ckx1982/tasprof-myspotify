using MvvmCross.Navigation;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Navigation;

namespace Tasprof.Apps.MySpotify.Core.ViewModels.PlayHistory
{
    public class PlayHistoryItemDetailsViewModel : BaseViewModelParam<PlayHistoryItemNavigationArgs>
    {
        private readonly IMvxNavigationService _navigationService;

        public PlayHistoryItem PlayHistoryItem { get; set; }

        public PlayHistoryItemDetailsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(PlayHistoryItemNavigationArgs parameter)
        {
            PlayHistoryItem = parameter.Item;
        }
    }
}
