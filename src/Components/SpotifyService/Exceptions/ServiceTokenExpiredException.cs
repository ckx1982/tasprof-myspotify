using System;

namespace Tasprof.Components.SpotifyClient.Exceptions
{
    public class ServiceTokenExpiredException : Exception
    {
        public string Content { get; }

        public ServiceTokenExpiredException()
        {
        }

        public ServiceTokenExpiredException(string content)
        {
            Content = content;
        }
    }
}
