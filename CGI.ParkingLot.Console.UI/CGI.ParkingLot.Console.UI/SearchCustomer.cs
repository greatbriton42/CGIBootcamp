using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGI.ParkingLot.ConsoleApp.DTO;
using CGI.ParkingLot.ConsoleApp.Service;

namespace CGI.ParkingLot.ConsoleApp.UI
{
    /// <summary>
    /// Screen for searching for a customer, displaying the results, and selecting which customer to interact with
    /// </summary>
    class SearchCustomer : MenuState
    {
        private string _customerSelection;
        private string _searchInput;
        private int _selectedCustomerID;
        private List<CustomerDTO> _customerList;

        /// <summary>
        /// Entry point for this screen. Workflow for what this screen performs
        /// </summary>
        /// <returns></returns>
        public override MenuState Start()
        {
            Console.Clear();
            PrintHeading("Search Customers");

            Console.WriteLine("\nPress \"Enter\" to search or 'B' to go back:");
            ConsoleKey input;
            do
            {
                input = Console.ReadKey().Key;
            } while (input != ConsoleKey.Enter && input != ConsoleKey.B);
            if (input == ConsoleKey.B)
            {
                return new MainMenu();
            }

            Console.Write("Enter a Name (First/Last): ");

            bool isName = false;
            do
            {
                _searchInput = Console.ReadLine();
                if (_searchInput.Any(char.IsDigit) || _searchInput.All(char.IsWhiteSpace))
                {
                    Console.WriteLine("Please Enter a Name");
                }
                else
                    isName = true;
            } while (!isName);

            Console.Clear();
            PrintHeading("List of Customers");
            _customerList = GetCustomerList();
            DisplayCustomerList(_customerList);

            Console.WriteLine("\nPress \"Enter\" to enter an ID or 'B' to go back:");
            ConsoleKey backInput;
            do
            {
                backInput = Console.ReadKey().Key;
            }while (backInput != ConsoleKey.Enter && backInput != ConsoleKey.B);

            if(backInput == ConsoleKey.B)
            {
                return new SearchCustomer();
            }

            while (true)
            {
                //Validate input is integer
                do
                {
                    Console.Write("Enter a Customer (Id): ");
                    _customerSelection = Console.ReadLine();
                }
                while (!int.TryParse(_customerSelection, out _selectedCustomerID));

                //Validate customer selection was in the list
                foreach (CustomerDTO customer in _customerList)
                {
                    if (customer.CustomerID == _selectedCustomerID)
                    {
                        return new CustomerRecordOptions(customer);
                    }
                }
                Console.WriteLine("Selected Customer ID is not valid");
            }
        }
        /// <summary>
        /// Call a service to get a customer list by user search input
        /// </summary>
        private List<CustomerDTO> GetCustomerList()
        {
            return new CustomerService().SearchCustomers(_searchInput);
        }

        /// <summary>
        /// Display the Customers contained in the list
        /// </summary>
        /// <param name="list">List of Customers to be displayed</param>
        private void DisplayCustomerList(List<CustomerDTO> list)
        {
            Console.WriteLine();
            Console.WriteLine(string.Format("  {0,-5}{1,-15}{2,-13}{3,-12}{4,-5}", "Id", "First", "Last", "State", "Phone"));
            Console.WriteLine(new string('-', WIDTHOFTITLE));
            foreach (CustomerDTO customer in list)
            {
                Console.WriteLine(String.Format("  {0,-5}{1,-15}{2,-15}{3,-6}{4,-14}", 
                                                 customer.CustomerID, customer.FirstName, customer.LastName, 
                                                 customer.StateInitial, customer.PhoneNumber.Insert(0,"(").Insert(4,")").Insert(5," ").Insert(9,"-")));
            }
        }
    }
}
