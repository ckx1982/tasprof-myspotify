﻿using System.Threading.Tasks;
using Tasprof.Components.SpotifyModels;

namespace Tasprof.Components.SpotifyClient.Services.Identity
{
    public interface IIdentityService
    {
        string CreateAuthorizationRequest();
        string CreateLogoutRequest(string token);
        Task<UserToken> GetTokenAsync(string code);

    }
}
