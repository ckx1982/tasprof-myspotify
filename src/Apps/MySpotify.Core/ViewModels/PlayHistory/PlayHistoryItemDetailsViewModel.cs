using System.Threading.Tasks;
using MvvmCross.Navigation;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Navigation;

namespace Tasprof.Apps.MySpotify.Core.ViewModels.PlayHistory
{
    public class PlayHistoryItemDetailsViewModel : BaseViewModelParam<PlayHistoryItemNavigationArgs>
    {
        private readonly IMvxNavigationService _navigationService;

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }


        private PlayHistoryItem _playHistoryItem;
        public PlayHistoryItem PlayHistoryItem
        {
            get { return _playHistoryItem; }
            set { SetProperty(ref _playHistoryItem, value); }
        }

        public PlayHistoryItemDetailsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(PlayHistoryItemNavigationArgs parameter)
        {
            PlayHistoryItem = parameter.Item;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }
    }
}
