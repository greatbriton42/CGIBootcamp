using System;
using CGI.ParkingLot.ConsoleApp.DTO;
using CGI.ParkingLot.ConsoleApp.Service;
using System.Collections.Generic;

namespace CGI.ParkingLot.ConsoleApp.UI
{
    /// <summary>
    /// List all selected customer's transactions to the screen
    /// </summary>
    class ListCustomerTransactions : MenuState
    {
        private CustomerDTO _customer;
        private List<TransactionDTO> _transactionList;
        private string _customerSelection;
        private int _selectedTransactionID;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customer">Current Customer</param>
        public ListCustomerTransactions(CustomerDTO customer)
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
            PrintHeading(string.Format("Parking Records: {0}", _customer.FirstName + " " + _customer.LastName));
            _transactionList = ListRecords();

            //Check if transaction list is empty
            if(_transactionList.Count == 0)
            {
                Console.WriteLine("No results found");
                Console.WriteLine("Press Enter to view more options");
                while(true)
                {
                    if(Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        return new CustomerRecordOptions(_customer);
                    }
                }
            }

            DisplayTransactionList(_transactionList);

            Console.WriteLine("\nPress \"Enter\" to enter an ID or 'B' to go back:");
            ConsoleKey input;
            do
            {
                input = Console.ReadKey().Key;
            } while (input != ConsoleKey.Enter && input != ConsoleKey.B);

            if (input == ConsoleKey.B)
            {
                return new CustomerRecordOptions(_customer);
            }
            // Prompt user until correct value has been entered
            while (true)
            {
                // Validate input to be integer
                do
                {
                    Console.Write("Enter a Transaction ID: ");
                    _customerSelection = Console.ReadLine();
                } while (!int.TryParse(_customerSelection, out _selectedTransactionID));

                // Validate selection was a listed transaction
                foreach (TransactionDTO transaction in _transactionList)
                {
                    if (transaction.TransactionID == _selectedTransactionID)
                    {
                        return new RecordOptions(_customer, transaction);
                    }
                }
                Console.WriteLine("Selected ID is invalid");
            }
        }
        /// <summary>
        /// Get the List of records
        /// </summary>
        /// <returns>Collection of transactions for the customer id</returns>
        private List<TransactionDTO> ListRecords()
        {
            CustomerService service = new CustomerService();
            return service.GetCustomerTransactions(_customer);
        }

        /// <summary>
        /// Display the List of transactions
        /// </summary>
        /// <param name="list">List of Transactions to be displayed</param>
        private void DisplayTransactionList(List<TransactionDTO> list)
        {
            Console.WriteLine();
            Console.WriteLine(string.Format(" {0,-7}{1,-16}{2,-24}{3,-16}{4,-7}","Tran#", "Spot#", "In", "Out", "Active"));
            Console.WriteLine(new string('-', WIDTHOFTITLE));
            foreach (TransactionDTO transaction in list)
            {
                Console.WriteLine(String.Format("  {0,-7}{1,-7}{2,-25}{3,-25}{4,-7}",
                                                transaction.TransactionID, transaction.ParkingSpotID, 
                                                transaction.TimeIn, transaction.TimeOut==null?"Checked Out":transaction.TimeOut.ToString(), 
                                                transaction.Active?"Y":"N"));
            }
        }
    }

}