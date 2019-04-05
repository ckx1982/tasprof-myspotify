using System;
namespace Tasprof.Apps.MySpotify.Core.Exceptions
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
