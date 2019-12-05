using System;
using Streetlight.Base;

namespace Streetlight.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Action onDispose = () => Console.WriteLine("Cleanup completed.");
            new ConsoleHandler(onDispose).Run(new Class1().PrintTrackName);
            Console.WriteLine("Exiting gracefully.");
        }
    }
}