using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.Common.GridEx
{
   /// <summary>
   /// Criteria used for the paginated Project Team Table
   /// </summary>
   public class ProjectTeamCriteria: PageSortCriteria
   {
      public ProjectTeamCriteria()
      {
         Sort = "Role";
         Order = SortDirection.Ascending.ToString();
         Page = 1;
      }
   }
}
