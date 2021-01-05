using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Venture.Common;

namespace ABC.Venture.DTO
{
   public class ProjectDetailOverviewDTO
   {
      public string ProjectHealthString;
      public string ProjectNumber { get; set; }
      public string ProjectName { get; set; }
      public decimal ProjectCompletion { get; set; }
      public EnumTypes.ProjectRatingColor RatingColor { get; set; }
      public EnumTypes.ProjectRatingText RatingText { get; set; }
      public EnumTypes.ProjectHealthColor ProjectHealth => ProjectHealthString.ToProjectHealthColor();
      public decimal? PercentCapitalSpent { get; set; }
      public string ProjectDirectory { get; set; }
   }
}
