using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.Common.GridEx
{
   /// <summary>
   /// Criteria used for Paginated My Projects Table
   /// </summary>
   public class MyProjectsCriteria: PageSortCriteria
   {
      public string ProjectName { get; set; }
      public string ProjectNumber { get; set; }
      private string _filter;
      public override string Filter
      {
         get
         {
            if(string.IsNullOrEmpty(ProjectName) && string.IsNullOrEmpty(ProjectNumber))
            {
               return _filter;
            }
            else
            {
               return $"ProjectName.ToLower().Contains(\"{ProjectName.ToLower()}\") && ProjectNumber.Contains(\"{ProjectNumber}\")";
            }
         }
         set
         { 
            _filter = value;
         }
      }


      public MyProjectsCriteria()
      {
         Sort = "ProjectNumber";
         Order = SortDirection.Ascending.ToString();
         Page = 1;
      }




   }
}
