using System;
using System.Threading;
using CGI.ParkingLot.ConsoleApp.DTO;
using CGI.ParkingLot.ConsoleApp.Service;

namespace CGI.ParkingLot.ConsoleApp.UI
{
   /// <summary>
   /// Screen for displaying and handle the editing of a selected record
   /// </summary>
   class EditTransaction : MenuState
   {
      private CustomerDTO _customer;
      private TransactionDTO _transaction;
      private CustomerService _service = new CustomerService();

      /// <summary>
      /// Constructor
      /// </summary>
      /// <param name="customer">Current Customer</param>
      /// <param name="transaction">Current Transaction</param>
      public EditTransaction(CustomerDTO customer, TransactionDTO transaction)
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
         PrintHeading(string.Format("Edit Parking Record: {0}", _transaction.TransactionID));

         Console.WriteLine("\nCurrent Parking Spot is: {0}", _transaction.ParkingSpotID);
         Console.Write("Wish to change Y/N: ");
         if(Console.ReadKey().Key == ConsoleKey.Y)
         {
            Console.Write("\nEnter new Parking Spot: ");
            int spot;
            while(!int.TryParse(Console.ReadLine(), out spot) || !_service.DoesSpotExist(spot))
            {
               Console.WriteLine("Invalid Parking Spot");
               Console.Write("Enter new Parking Spot: ");
            }
            _transaction.ParkingSpotID = spot;
         }

         bool timeValid = false;
         while(!timeValid)
         {
            Console.WriteLine("\nCurrent Time in is: {0}", _transaction.TimeIn);
            Console.Write("Wish to change Y/N: ");
            if(Console.ReadKey().Key == ConsoleKey.Y)
            {
               Console.WriteLine("\nTime In");
               DateTime? TimeIn = null;
               while(TimeIn == null)
               {
                  TimeIn = GetDateTime();
               }
               _transaction.TimeIn = (DateTime)TimeIn;

            }

            Console.WriteLine("\nCurrent Time out is: {0}", _transaction.TimeOut);
            Console.Write("Wish to change Y/N: ");
            if(Console.ReadKey().Key == ConsoleKey.Y)
            {
               Console.WriteLine("\nTime Out");
               _transaction.TimeOut = GetDateTime();
            }
            if(_transaction.TimeIn < _transaction.TimeOut)
               timeValid = true;
            else
            {
               timeValid = false;
               Console.WriteLine("Time in must be before Time out");
            }
         }

         Console.Write("\nDo you wish to save this transaction Y/N: ");
         if(Console.ReadKey().Key == ConsoleKey.Y)
         {

            if(_service.UpdateTransaction(_transaction))
            {
               Console.WriteLine("\nTransaction was Updated");
            }
            else
            {
               Console.WriteLine("\nThere was a conflict with another transaction");
               Console.WriteLine("\nTransaction was not saved");
            }
         }
         else Console.WriteLine("\nTransaction was not saved");

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