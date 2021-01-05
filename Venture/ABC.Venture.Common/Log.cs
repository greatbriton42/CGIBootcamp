using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.Common
{
   public class Log
   {
      private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      public Log(string message)
      {
         _log.Info(message);
      }

      public void Error(string message, Exception e)
      {
         _log.Error(message, e);
      }
   }
}
