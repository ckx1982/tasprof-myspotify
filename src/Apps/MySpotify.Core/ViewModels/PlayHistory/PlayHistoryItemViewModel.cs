using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Tasprof.Apps.MySpotify.Core.Enums;
using Tasprof.Apps.MySpotify.Core.Interactions;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Navigation;
using Tasprof.Apps.MySpotify.Core.Services.Spotify;

namespace Tasprof.Apps.MySpotify.Core.ViewModels.PlayHistory
{
    public class PlayHistoryItemViewModel : BaseViewModel
    {
        private readonly ISpotifyService _spotifyService;
        private readonly IMvxNavigationService _navigationService;

        private MvxInteraction<ContextMenuItemInteraction> _interaction = new MvxInteraction<ContextMenuItemInteraction>();
        public IMvxInteraction<ContextMenuItemInteraction> Interaction => _interaction;

        private readonly PlayHistoryItem _playHistoryItem;
        public PlayHistoryItem PlayHistoryItem { get { return _playHistoryItem; } }

        public IMvxAsyncCommand PlayCommand { get; private set; }


        public PlayHistoryItemViewModel(IMvxNavigationService navigationService, ISpotifyService spotifyService, PlayHistoryItem playHistoryItem)
        {
            _spotifyService = spotifyService;
            _navigationService = navigationService;
            _playHistoryItem = playHistoryItem;
            PlayCommand = new MvxAsyncCommand(PlayCommandTask);
        }

        //public override void Prepare(PlayHistoryItemNavigationArgs parameter)
        //{
        //    TrackUri = parameter.TrackUri;
        //}

        private async Task PlayCommandTask()
        {
            await _navigationService.Navigate<PlayHistoryItemDetailsViewModel, PlayHistoryItemNavigationArgs>(
                new PlayHistoryItemNavigationArgs()
                {
                    Item = _playHistoryItem
                });
            //    // 1. do cool stuff with profile data
            //    // ...

            //    // 2. request interaction from view
            //    // 3. execution continues in callbacks
            //    var request = new ContextMenuItemInteraction
            //    {
            //        Callback = async (ok) =>
            //        {
            //            switch (ok)
            //            {
            //                case ContextMenuItem.Play:
            //                   await _navigationService.Navigate<PlayHistoryItemViewModel>();
            //                   break;
            //                case ContextMenuItem.MoreInfo:
            //                   await Task.Delay(1); break;
            //                default:
            //                    break;
            //            }
            //        }
            //    };

            //    _interaction.Raise(request);
            //}
        }
    }
}
