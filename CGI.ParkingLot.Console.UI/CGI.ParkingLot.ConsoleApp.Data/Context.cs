using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGI.ParkingLot.ConsoleApp.Data
{
    /// <summary>
    /// Context Wrapper class
    /// </summary>
    public class Context
    {
        public ParkingLotEntities ABCContext { get; set; }

        public Context()
        {
            ABCContext = new ParkingLotEntities();

            ABCContext.Configuration.LazyLoadingEnabled = false;

        }
       
    }
}
