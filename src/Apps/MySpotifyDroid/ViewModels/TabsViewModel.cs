using MvvmCross.ViewModels;

namespace Tasprof.Apps.MySpotifyDroid.ViewModels
{
    public class TabsViewModel: MvxViewModel
    {
        private string _top= "Top";
        public string Top
        {
            get { return _top; }
            set { SetProperty(ref _top, value); }
        }
    }
}
