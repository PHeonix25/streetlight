using System;

namespace Streetlight.Base
{
    public class SpotifyController : IDisposable
    {
        private Spotify _spotify;

        public SpotifyController()
        {
            _spotify = new Spotify();
        }

        public void Dispose() => _spotify.Dispose();

        public void PrintTrackName()
        {
            var track = _spotify.GetRandomTrack();
            if (track != null) Console.WriteLine($"First track: '{track.Name}' by '{track.Artists[0].Name}'");
        }
    }
}
