using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGI.ParkingLot.ConsoleApp.DTO
{
    /// <summary>
    /// TransactionDTO for transfering data to UI
    /// </summary>
    public class TransactionDTO
    {
        public int CustomerID { get; set; }
        public int TransactionID { get; set; }
        public int ParkingSpotID { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool Active { get; set; }
        public int KeyCardKey { get; set; }

    }
}
