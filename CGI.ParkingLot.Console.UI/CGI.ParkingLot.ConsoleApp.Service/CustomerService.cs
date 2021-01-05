using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGI.ParkingLot.ConsoleApp.DTO;
using CGI.ParkingLot.ConsoleApp.Domain;
using CGI.ParkingLot.ConsoleApp.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CGI.ParkingLot.ConsoleApp.Service
{
   /// <summary>
   /// Service class which handles all interaction between the UI and Data
   /// </summary>
   public class CustomerService
   {
      private Context _ctx = new Context();

      /// <summary>
      /// Get a list of customers
      /// </summary>
      /// <param name="customerSearch">User search string for first and last name</param>
      /// <returns>List of customerDTO that match first/last name</returns>
      public List<CustomerDTO> SearchCustomers(string customerSearch)
      {

         return _ctx.ABCContext.Customers.Include(a => a.Addresses)
                                         .Include(k => k.KeyCards)
                                         .Where(x => (x.FirstName + x.LastName)
                                         .Contains(customerSearch))
             .Select(y => new CustomerDTO
             {
                FirstName = y.FirstName,
                LastName = y.LastName,
                CustomerID = y.CustomerKey,
                PhoneNumber = y.PhoneNumber,
                StateInitial = y.Addresses.Where(a => a.CurrentAddress).FirstOrDefault().State,
                KeyCardKey = y.KeyCards.Where(k => k.Active).FirstOrDefault().KeyCardKey
             }).ToList();
      }

      /// <summary>
      /// Get a list of Customer Transaction
      /// </summary>
      /// <param name="customer">Customer to find transactions for</param>
      /// <returns>List of transactions that match the passed customer</returns>
      public List<TransactionDTO> GetCustomerTransactions(CustomerDTO customer)
      {
         return _ctx.ABCContext.TransactionRecords.Include(k => k.KeyCard)
                                                  .Where(x => x.KeyCard.CustomerKey == customer.CustomerID)
             .Select(y => new TransactionDTO
             {
                CustomerID = y.KeyCard.CustomerKey,
                ParkingSpotID = y.ParkingSpotKey,
                TransactionID = y.TransactionKey,
                KeyCardKey = y.KeyCardKey,
                TimeIn = y.TimeIn,
                TimeOut = y.TimeOut,
                Active = y.Active
             }).ToList();
      }

      /// <summary>
      /// Update the a transaction
      /// </summary>
      /// <param name="transaction">Transaction with updated values to be updated</param>
      public bool UpdateTransaction(TransactionDTO transaction)
      {
         //TODO add for null
         var transactionRecord = _ctx.ABCContext.TransactionRecords.Find(transaction.TransactionID);
         transactionRecord.Active = transaction.Active;
         transactionRecord.TimeIn = transaction.TimeIn;
         transactionRecord.TimeOut = transaction.TimeOut;
         transactionRecord.ParkingSpotKey = transaction.ParkingSpotID;

         if(IsSpotAvailable(transactionRecord))
         {
            _ctx.ABCContext.SaveChanges();
            return true;
         }
         else
         {
            return false;
         }
      }

      /// <summary>
      /// Add a transaction
      /// </summary>
      /// <param name="transaction"></param>
      public bool AddTransaction(TransactionDTO transaction)
      {
         var spot = _ctx.ABCContext.ParkingSpots.Include(x => x.Lot).Where(x => x.ParkingSpotKey == transaction.ParkingSpotID).FirstOrDefault();     
         var lot = spot.Lot.LotHourlyRates.Where(x => x.Active);
         var rate = lot.FirstOrDefault();
         TransactionRecord record = new TransactionRecord
         {
            ParkingSpotKey = transaction.ParkingSpotID,
            TimeIn = transaction.TimeIn,
            TimeOut = transaction.TimeOut == null ? null : transaction.TimeOut,
            Active = true,
            KeyCardKey = transaction.KeyCardKey,
            RateKey = rate != null ? rate.LotHourlyRateKey : (Nullable<int>) null
         };

         if(IsSpotAvailable(record) && DoesSpotExist(transaction.ParkingSpotID))
         {
            _ctx.ABCContext.TransactionRecords.Add(record);
            _ctx.ABCContext.SaveChanges();
            return true;
         }
         else
         {
            return false;
         }
      }

      /// <summary>
      /// Soft delete the transaction
      /// </summary>
      /// <param name="transaction">transaction DTO with ID for transaction you wish to delete</param>
      public void DeleteTransaction(TransactionDTO transaction)
      {
         var record = _ctx.ABCContext.TransactionRecords.Find(transaction.TransactionID);
         record.Active = false;
         _ctx.ABCContext.SaveChanges();
      }

      /// <summary>
      /// Determine whether the spot is already in use or not for the time.
      /// </summary>
      /// <param name="transaction">DTO containing the information needed to check against like times and spot number</param>
      /// <returns></returns>
      private bool IsSpotAvailable(TransactionRecord transaction)
      {
         return transaction.IsSpotValid(_ctx.ABCContext.TransactionRecords.AsQueryable<TransactionRecord>());
      }

      /// <summary>
      /// Determine if this spot is a valid spot in the database
      /// </summary>
      /// <param name="spotID">Spot ID used to identify the spot in the database</param>
      /// <returns></returns>
      public bool DoesSpotExist(int spotID)
      {
         return _ctx.ABCContext.ParkingSpots.Any(x => x.ParkingSpotKey == spotID);
      }
   }
}
