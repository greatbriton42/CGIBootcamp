using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGI.ParkingLot.ConsoleApp.UI
{
    /// <summary>
    /// Splash screen for start of the application
    /// </summary>
    class WelcomeScreen : MenuState
    {
        /// <summary>
        /// Entry point for this screen. Workflow for what this screen performs
        /// </summary>
        /// <returns></returns>
        public override MenuState Start()
        {
            Console.Clear();
            PrintHeading("Welcome to ABC Company");
            Console.WriteLine("To Continue Press Enter....");
            while (Console.ReadKey().Key != ConsoleKey.Enter);
            return new MainMenu();
        }
    }
}
