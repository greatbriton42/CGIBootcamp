using CGI.ParkingLot.ConsoleApp.DTO;
using CGI.ParkingLot.ConsoleApp.Service;
using System;
using System.Threading;

namespace CGI.ParkingLot.ConsoleApp.UI
{
   /// <summary>
   /// Screen which gather information from the user to be added into a new transaction
   /// </summary>
   class AddTransaction : MenuState
   {
      private TransactionDTO _transaction = new TransactionDTO();
      private CustomerDTO _customer;
      CustomerService _service = new CustomerService();

      /// <summary>
      /// Constructor
      /// </summary>
      /// <param name="customer">Current Customer</param>
      public AddTransaction(CustomerDTO customer)
      {
         this._customer = customer;
      }

      /// <summary>
      /// Entry point for this screen. Workflow for what this screen performs
      /// </summary>
      /// <returns></returns>
      public override MenuState Start()
      {
         Console.Clear();

         //Get and validate parking spot
         Console.Write("Enter new Parking Spot: ");
         int spot;
         while(!int.TryParse(Console.ReadLine(), out spot) || !_service.DoesSpotExist(spot))
         {
            Console.WriteLine("Invalid Parking Spot");
            Console.Write("Enter new Parking Spot: ");
         }
         _transaction.ParkingSpotID = spot;

         //Get and validate times
         bool timeValid = false;
         while(!timeValid)
         {
            Console.WriteLine("Time In");
            DateTime? TimeIn = null;
            while(TimeIn == null)
            {
               TimeIn = GetDateTime();
            }
            _transaction.TimeIn = (DateTime)TimeIn;

            Console.WriteLine("Time Out");
            _transaction.TimeOut = GetDateTime();
            if(_transaction.TimeIn < _transaction.TimeOut || !_transaction.TimeOut.HasValue)
               timeValid = true;
            else
            {
               timeValid = false;
               Console.WriteLine("Time in must be before Time out");
            }
         }

         //Verify if they want to save the transaction
         Console.Write("Do you wish to save this transaction Y/N: ");
         if(Console.ReadKey().Key == ConsoleKey.Y)
         {

            _transaction.KeyCardKey = _customer.KeyCardKey;
            if(_service.AddTransaction(_transaction))
            {
               Console.WriteLine("\nTransaction has been added");
            }
            else
            {
               Console.WriteLine("\nThere was a conflict with another transaction");
               Console.WriteLine("\nTransaction has not been added");
            }
         }
         else
            Console.WriteLine("Transaction was not added.");

         Console.WriteLine("Press Enter to view options");
         while(true)
         {
            if(Console.ReadKey().Key == ConsoleKey.Enter)
            {
               return new CustomerRecordOptions(_customer);
            }
         }
      }
   }
}