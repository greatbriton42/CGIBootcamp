using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.Common.GridEx
{
   /// <summary>
   /// Criterai used for the paginated Milestones Table
   /// </summary>
   public class MilestoneCriteria: PageSortCriteria
   {
      public MilestoneCriteria()
      {
         Sort = "ProjectName";
         Order = SortDirection.Ascending.ToString();
         Page = 1;
      }
   }
}
