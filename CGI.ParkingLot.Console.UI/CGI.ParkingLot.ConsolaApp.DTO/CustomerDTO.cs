using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGI.ParkingLot.ConsoleApp.DTO
{
    /// <summary>
    /// CustomerDTO for transfering data to UI
    /// </summary>
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StateInitial { get; set; }
        public string PhoneNumber { get; set; }
        public int KeyCardKey { get; set; }

    }
}
