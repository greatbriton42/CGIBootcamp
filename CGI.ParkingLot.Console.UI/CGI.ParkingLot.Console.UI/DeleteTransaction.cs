using System;
using System.Threading;
using CGI.ParkingLot.ConsoleApp.DTO;
using CGI.ParkingLot.ConsoleApp.Service;

namespace CGI.ParkingLot.ConsoleApp.UI
{
    /// <summary>
    /// Screen for verifing the deletion of a selected record
    /// </summary>
    class DeleteTransaction : MenuState
    {
        private CustomerDTO _customer;
        private TransactionDTO _transaction;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customer">Current Customer</param>
        /// <param name="transaction">Current Transaction</param>
        public DeleteTransaction(CustomerDTO customer, TransactionDTO transaction)
        {
            this._customer = customer;
            this._transaction = transaction;
        }

        /// <summary>
        /// Entry point for this screen. Workflow for what this screen performs
        /// </summary>
        /// <returns></returns>
        public override MenuState Start()
        {
            Console.Clear();
            PrintHeading(string.Format("Delete Parking Record: {0}", _transaction.TransactionID));
            Console.Write("Do you wish to delete this transaction Y/N: ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                CustomerService service = new CustomerService();
                service.DeleteTransaction(_transaction);
                Console.WriteLine("\nThe Transaction has been deleted");
            }
            else Console.WriteLine("\nTransaction was not deleted");

            Console.WriteLine("Press Enter to view options");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    return new CustomerRecordOptions(_customer);
                }
            }
        }
    }
}