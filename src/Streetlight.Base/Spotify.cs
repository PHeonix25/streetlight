using System;
using System.Linq;
using System.Threading;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;

namespace Streetlight.Base
{
    internal class Spotify
    {
        private const string _clientId = "ae8e2b78a5c145d6af9c9e26a1f91c0c";
        private static SpotifyWebAPI _spotify;
        private ManualResetEvent _authenticated;

        public Spotify()
        {
            _authenticated = new ManualResetEvent(false);

            var auth = new ImplicitGrantAuth(
                _clientId,
                "http://localhost:5000",
                "http://localhost:5000"
              );
            
            auth.AuthReceived += (sender, payload) =>
            {
                auth.Stop(); // `sender` is also the auth instance
                _spotify = new SpotifyWebAPI()
                {
                    TokenType = payload.TokenType,
                    AccessToken = payload.AccessToken
                };
                _authenticated.Set();
            };

            auth.Start(); // Starts an internal HTTP Server
            auth.OpenBrowser();
            _authenticated.WaitOne(); // Wait for the auth-token to come back.
        }

        public void GetTrack()
        {
            FullTrack track = _spotify.GetTrack("3Hvu1pq89D4R0lyPBoujSv");
            Console.WriteLine($"Track: '{track.Name}' by '{track.Artists.First().Name}'");
        }

        public void GetRandomTrack()
        {
            var query = SearchTerm.GetNext(false);
            var lookingFor = SpotifyAPI.Web.Enums.SearchType.All;
            Console.WriteLine($"Searching for '{query}'... ");

            var r = _spotify.SearchItems(query, lookingFor, limit: 1);
            if (r.HasError())
            {
                Console.WriteLine($"Spotify failed: {r.Error.Status} - {r.Error.Message}");
            }
            else if (r?.Tracks?.Items.Count > 0)
            {
                Console.WriteLine($"Spotify returned {r?.Tracks?.Items.Count} tracks.");
                var track = r.Tracks?.Items?.FirstOrDefault();
                if (track != null) Console.WriteLine($"First track: '{track.Name}' by '{track.Artists.First().Name}'");
            }
        }
    }
}