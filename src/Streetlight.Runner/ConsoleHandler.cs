using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Streetlight.Runner
{
    public class ConsoleHandler
    {

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);
        private delegate bool EventHandler();

        private ManualResetEvent _exitEvent;
        private Action _cleanup;

        public ConsoleHandler(Action cleanup)
        {
            _exitEvent = new ManualResetEvent(false);
            _cleanup = cleanup;
        }

        private bool OnShutdown()
        {
            Console.WriteLine($"Shutdown requested.");
            _cleanup();
            _exitEvent.Set();
            return true;
        }

        public void Run(Action func)
        {
            SetConsoleCtrlHandler(new EventHandler(OnShutdown), true);
            func();
            _exitEvent.WaitOne();
        }
    }
}