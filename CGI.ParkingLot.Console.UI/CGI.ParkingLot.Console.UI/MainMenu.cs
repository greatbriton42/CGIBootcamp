using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGI.ParkingLot.ConsoleApp.UI
{
    /// <summary>
    /// Main Menu with options to exit or search customers
    /// </summary>
    class MainMenu : MenuState
    {
        /// <summary>
        /// Entry point for this screen. Workflow for what this screen performs
        /// </summary>
        /// <returns></returns>
        public override MenuState Start()
        {
            Console.Clear();
            PrintHeading("Main Menu");
            PrintMenu("(S)earch by Customer", "E(x)it");
            Console.Write("\nEnter a selection: ");
            do
            {
                var keyPressed = Console.ReadKey();
                switch (keyPressed.Key)
                {
                    case ConsoleKey.S:
                        return new SearchCustomer(); // Go to Search Customers
                    case ConsoleKey.X:
                        Environment.Exit(0); // Exit the Program
                        break;
                    default:
                        Console.WriteLine("Invalid Menu Option");
                        break;
                }
            } while (true);
        }
    }
}
