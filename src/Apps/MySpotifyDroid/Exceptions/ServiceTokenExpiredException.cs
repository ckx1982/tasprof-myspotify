using System;
namespace Tasprof.Apps.MySpotifyDroid.Exceptions
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
