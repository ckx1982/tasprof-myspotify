namespace Tasprof.Components.SpotifyClient.Services
{
    public abstract class BaseService<IGlobalSettings>
    {
        public IGlobalSettings GlobalSettings { get; set; }
    }
}
