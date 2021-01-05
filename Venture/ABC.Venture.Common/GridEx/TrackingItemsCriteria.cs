using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.Common.GridEx
{
   /// <summary>
   /// Criteria used for the tracking items criteria table
   /// </summary>
   public class TrackingItemsCriteria: PageSortCriteria
   {
      public TrackingItemsCriteria()
      {
         Sort = "ProjectID";
         Order = SortDirection.Ascending.ToString();
         Page = 1;
      }
   }
}
