using System;

namespace CGI.ParkingLot.ConsoleApp.UI
{
    /// <summary>
    /// Main program. Entry Point
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MenuState _screen = new WelcomeScreen();

            while (true)
            {
                _screen = _screen.Start();
            }
        }
    }
}