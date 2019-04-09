using System;
using Android.App;
using Android.Content;
using Android.OS;
using Com.Spotify.Sdk.Android.Authentication;
using MvvmCross.Droid.Support.V7.AppCompat;
using Tasprof.Apps.MySpotify.Core.ViewModels.Main;

namespace Tasprof.Apps.MySpotify.Droid.UI.Views
{
    [Activity(Label = "@string/app_name")]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {

        private readonly int AUTH_CODE_REQUEST_CODE = 10001;
        private readonly int AUTH_TOKEN_REQUEST_CODE = 10002;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);

            if (ViewModel.AccessToken == null)
            {
                ViewModel.RedirectUri = "myspotify://customtabs";

                try
                {
                    AuthenticationRequest request = GetAuthenticationRequest(AuthenticationResponse.Type.Code);
                    AuthenticationClient.OpenLoginActivity(this, AUTH_CODE_REQUEST_CODE, request);

                    AuthenticationRequest requestToken = GetAuthenticationRequest(AuthenticationResponse.Type.Token);
                    AuthenticationClient.OpenLoginActivity(this, AUTH_TOKEN_REQUEST_CODE, requestToken);

                }
                catch (Exception e)
                {
                    var ex = e;
                }
            }
            else
            {
                this.Finish();
            }

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationResponse response = AuthenticationClient.GetResponse(Convert.ToInt32(resultCode), data);

            if (requestCode == AUTH_CODE_REQUEST_CODE)
            {
                ViewModel.AuthorizationCode = response.Code;
            }

            if (requestCode == AUTH_TOKEN_REQUEST_CODE)
            {
                ViewModel.AccessToken = response.AccessToken;
            }
        }

        #region "Private Methods"

        private AuthenticationRequest GetAuthenticationRequest(AuthenticationResponse.Type type)
        {
            return new AuthenticationRequest.Builder(ViewModel.ClientId, type, ViewModel.RedirectUri)
                .SetShowDialog(true)
                .SetScopes(new string[] {
                    "user-read-email",
                    "user-read-recently-played"
                })
                .Build();
        }

        #endregion

    }
}
