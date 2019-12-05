namespace Streetlight.Base
{
    public class Class1
    {
        private static Spotify _spotify;

        public Class1()
        {
            _spotify = new Spotify();
        }

        public void PrintTrackName()
        {
            _spotify.GetRandomTrack();
        }
    }
}
