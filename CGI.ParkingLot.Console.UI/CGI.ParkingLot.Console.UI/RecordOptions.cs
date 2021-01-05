using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGI.ParkingLot.ConsoleApp.DTO;

namespace CGI.ParkingLot.ConsoleApp.UI
{
    /// <summary>
    /// After selecting a transaction menu screen to choose between edit or delete
    /// </summary>
    class RecordOptions : MenuState
    {
        private CustomerDTO _customer;
        private TransactionDTO _transaction;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customer">Current Customer</param>
        /// <param name="transaction">Current Transaction</param>
        public RecordOptions(CustomerDTO customer, TransactionDTO transaction)
        {
            _customer = customer;
            _transaction = transaction;
        }

        /// <summary>
        /// Entry point for this screen. Workflow for what this screen performs
        /// </summary>
        /// <returns></returns>
        public override MenuState Start()
        {
            Console.Clear();
            PrintHeading(string.Format("Parking Record Options: {0}", _customer.FirstName + " " + _customer.LastName));
            PrintMenu("(E)dit", "(D)elete", "(B)ack-Transaction Options");

            //Validate input was a menu option
            do
            {
                Console.Write("\nEnter a Selection: ");
                var keyPressed = Console.ReadKey();
                Console.WriteLine();
                switch (keyPressed.Key)
                {
                    case ConsoleKey.E:
                        return new EditTransaction(_customer, _transaction);
                    case ConsoleKey.D:
                        return new DeleteTransaction(_customer, _transaction);
                    case ConsoleKey.B:
                        return new CustomerRecordOptions(_customer);
                    default:
                        Console.WriteLine("Invalid Menu Option");
                        break;
                }

            } while (true);
        }
    }
}
