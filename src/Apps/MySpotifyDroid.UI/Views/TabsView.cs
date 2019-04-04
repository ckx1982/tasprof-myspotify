using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using Tasprof.Apps.MySpotifyDroid.UI.Fragments;
using Tasprof.Apps.MySpotifyDroid.ViewModels;

namespace Tasprof.Apps.MySpotifyDroid.UI.Views
{
    [Activity(Label = "Top Tracks & Artists")]
    public class TabsView : MvxAppCompatActivity<TabsViewModel>
    {
        private TabLayout _tabLayout;
        private ViewPager _viewPager;
        //private Android.Support.V4.App.Fragment _topTracksFrg;
        //private Android.Support.V4.App.Fragment _topArtistsFrg;
        private TracksFragment _topTracksFrg;
        private ArtistsFragment _topArtistsFrg;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TabsView);

            _viewPager = FindViewById<ViewPager>(Resource.Id.viewpager1);

            SetupViewPager(_viewPager);

            _tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout1);
            _tabLayout.SetupWithViewPager(_viewPager);
        }

        private void SetupViewPager(ViewPager viewPager)
        {
            InitialFragment();
        }

        private void InitialFragment()
        {
            //_topTracksFrg = new Android.Support.V4.App.Fragment();
            //_topArtistsFrg = new Android.Support.V4.App.Fragment();
            _topTracksFrg = new TracksFragment();
            _topArtistsFrg = new ArtistsFragment();

            //ViewPagerAdapter adapter = new ViewPagerAdapter(this.SupportFragmentManager);
            //adapter.AddFragment(_topTracksFrg, "Tracks");
            //adapter.AddFragment(_topArtistsFrg, "Artists");
            List<MvxViewPagerFragmentInfo> fragmentInfos = new List<MvxViewPagerFragmentInfo>
            {
                new MvxViewPagerFragmentInfo("Tracks", "tracks", typeof(TracksFragment), typeof(TracksViewModel)),
                new MvxViewPagerFragmentInfo("Artists", "artists", typeof(ArtistsFragment), typeof(ArtistsViewModel))
            };

            MvxFragmentPagerAdapter adapter = new MvxFragmentPagerAdapter(this, this.SupportFragmentManager, fragmentInfos);
            _viewPager.Adapter = adapter;

        }
    }


}