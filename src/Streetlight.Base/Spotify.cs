using System;
using System.Linq;
using System.Threading;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using Streetlight.Base.Helpers;

namespace Streetlight.Base
{
    internal class Spotify : IDisposable
    {
        //TO BE REPLACED LATER WITH SECRET MGMT, FOR NOW, HARDCODED:
        private const string _clientId = "ae8e2b78a5c145d6af9c9e26a1f91c0c";
        private SpotifyWebAPI _spotify;
        private ManualResetEvent _authenticated;

        public Spotify()
        {
            Authenticate();
        }

        private void Authenticate()
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

        public FullTrack GetTrack() => _spotify.GetTrack("3Hvu1pq89D4R0lyPBoujSv");

        public FullTrack GetRandomTrack()
        {
            var query = SearchTerm.GetWithSeed("a");
            var type = SpotifyAPI.Web.Enums.SearchType.Track;

            Console.WriteLine($"Searching for '{query}'... ");
            var r = _spotify.SearchItems(query, type, limit: 1);

            if (r.HasError()) throw new SpotifyException(r.Error);
            
            Console.WriteLine($"Spotify returned {r?.Tracks?.Items.Count} tracks.");
            return r.Tracks?.Items?.FirstOrDefault();
        }

        public void Dispose()
        {
            _authenticated.Reset();
            _spotify.Dispose();
            Console.WriteLine(">> Spotify has been disposed");
        }
    }
}