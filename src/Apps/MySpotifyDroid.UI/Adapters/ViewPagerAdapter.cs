using Android.Support.V4.App;
using Java.Lang;
using System.Collections.Generic;

namespace Tasprof.Apps.MySpotifyDroid.UI.Adapters
{
    public class ViewPagerAdapter : FragmentPagerAdapter
    {
        private List<Android.Support.V4.App.Fragment> _lstFragments = new List<Android.Support.V4.App.Fragment>();
        private List<string> _lstFragmentNames = new List<string>();

        public ViewPagerAdapter(Android.Support.V4.App.FragmentManager manager): base(manager)
        {
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return _lstFragments[position];
        }

        public override int Count
        {
            get
            {
                return _lstFragments.Count;
            }
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(_lstFragmentNames[position].ToLower());// display the title
            //return null;// display only the icon
        }

        public void AddFragment(Android.Support.V4.App.Fragment fragment, string title)
        {
            _lstFragments.Add(fragment);
            _lstFragmentNames.Add(title);
        }

    }

}