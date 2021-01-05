using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.DTO
{
   public class IndicatorDTO
   {
      public int IndicatorID { get; set; }
      public string ProjectIndicator { get; set; }
      public int SortNumber { get; set; }
      public int? ProjectStatusID { get; set; }
   }
}
