using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGI.ParkingLot.ConsoleApp.Domain
{
    public partial class TransactionRecord
    {
        public bool IsSpotValid(IQueryable<TransactionRecord> records)
        {
            return !records.Where(x => x.TimeOut > TimeIn && x.TimeIn < TimeOut && x.TransactionKey != TransactionKey)
                           .Any(x => x.ParkingSpotKey == ParkingSpotKey);           
        }
    }
}
