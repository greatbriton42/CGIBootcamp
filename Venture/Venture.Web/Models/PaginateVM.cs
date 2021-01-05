using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABC.Venture.Common.GridEx;

namespace ABC.Venture.Web.Models
{
   public class PaginateVM<TDTO,UVM>
   {
      public IEnumerable<UVM> Records { get; private set; }
      public PageSortCriteria Criteria { get; private set; }
      public PaginateVM(IGrid<TDTO> grid, PageSortCriteria pageSortCriteria, IEnumerable<UVM> records)
      {
         pageSortCriteria.UpdateFromGrid(grid);
         Criteria = pageSortCriteria;
         Records = records;
      }
   }
}