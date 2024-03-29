﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tasprof.Apps.MySpotify.Core.Constants;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Core.Services.Request;

namespace Tasprof.Apps.MySpotify.Core.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IRequestService _requestProvider;
        private readonly IGlobalSettingsService _globalSettingsService;
        private string _codeVerifier;

        public IdentityService(IRequestService requestProvider, IGlobalSettingsService globalSettingsService)
        {
            _requestProvider = requestProvider;
            _globalSettingsService = globalSettingsService;
        }

        public string CreateAuthorizationRequest()
        {
            // Create URI to authorization endpoint
            var authorizeRequest = new AuthorizeRequest(SpotifyWebApi.AuthorizeUri);

            // Dictionary with values for the authorize request
            var dic = new Dictionary<string, string>();
            dic.Add("client_id", _globalSettingsService.ClientId);
            //dic.Add("client_secret", GlobalSettings.Instance.ClientSecret);
            dic.Add("response_type", "code");
            dic.Add("redirect_uri", _globalSettingsService.RedirectUri);
            dic.Add("scope", "user-read-private user-read-email user-top-read");

            // Add CSRF token to protect against cross-site request forgery attacks.
            var currentCSRFToken = Guid.NewGuid().ToString("N");
            dic.Add("state", currentCSRFToken);

            var authorizeUri = authorizeRequest.Create(dic);
            return authorizeUri;
        }

        public string CreateLogoutRequest(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return string.Empty;
            }

            return string.Empty;
            //return string.Format("{0}?id_token_hint={1}&post_logout_redirect_uri={2}",
            //    GlobalSettings.Instance.LogoutEndpoint,
            //    token,
            //    GlobalSettings.Instance.LogoutCallback);
        }

        public async Task<UserToken> GetTokenAsync(string code)
        {
            string data = string.Format("grant_type=authorization_code&code={0}&redirect_uri={1}&code_verifier={2}", code, WebUtility.UrlEncode(_globalSettingsService.RedirectUri), _codeVerifier);
            var token = await _requestProvider.PostAsync<UserToken>(SpotifyWebApi.TokenUri, data, _globalSettingsService.ClientId, _globalSettingsService.ClientSecret);
            return token;
        }

        //private string CreateCodeChallenge()
        //{
        //    _codeVerifier = RandomNumberGenerator.CreateUniqueId();
        //    var sha256 = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha256);
        //    var challengeBuffer = sha256.HashData(CryptographicBuffer.CreateFromByteArray(Encoding.UTF8.GetBytes(_codeVerifier)));
        //    byte[] challengeBytes;
        //    CryptographicBuffer.CopyToByteArray(challengeBuffer, out challengeBytes);
        //    return Base64Url.Encode(challengeBytes);
        //}
    }
}
