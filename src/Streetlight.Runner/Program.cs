using System;
using Streetlight.Base;

namespace Streetlight.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var spotify = new SpotifyController();

            Action onDispose = () => 
            { 
                spotify.Dispose(); 
                Console.WriteLine("Cleanup completed."); 
            };
            var controller = new ConsoleHandler(onDispose);

            controller.Run(spotify.PrintTrackName);
            Console.WriteLine("Exiting gracefully.");
        }
    }
}