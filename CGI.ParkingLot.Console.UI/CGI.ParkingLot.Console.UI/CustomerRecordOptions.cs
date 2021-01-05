using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGI.ParkingLot.ConsoleApp.DTO;

namespace CGI.ParkingLot.ConsoleApp.UI
{
    /// <summary>
    /// Display and handle the options associated with a particular selected record
    /// </summary>
    class CustomerRecordOptions : MenuState
    {
        private CustomerDTO _customer;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customer">Current Customer</param>
        public CustomerRecordOptions(CustomerDTO customer)
        {
            _customer = customer;
        }

        /// <summary>
        /// Entry point for this screen. Workflow for what this screen performs
        /// </summary>
        /// <returns></returns>
        public override MenuState Start()
        {
            Console.Clear();
            PrintHeading("Parking Record Options");
            PrintMenu("(L)ist", "(A)dd", "(B)ack-Customer", "E(x)it");
            do
            {
                Console.Write("\nEnter a selection: ");
                var keyPressed = Console.ReadKey();

                switch (keyPressed.Key)
                {
                    case ConsoleKey.L:
                        return new ListCustomerTransactions(_customer);
                    case ConsoleKey.A:
                        return new AddTransaction(_customer);
                    case ConsoleKey.B:
                        return new SearchCustomer();
                    case ConsoleKey.X:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Menu Option");
                        break;
                }
            } while (true);
        }
    }
}
