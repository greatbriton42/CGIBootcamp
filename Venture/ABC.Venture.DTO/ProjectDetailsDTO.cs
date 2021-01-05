using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Venture.Common;

namespace ABC.Venture.DTO
{
   public class ProjectDetailsDTO
   {
      public int ProjectId { get; set; }
      public string ProjectHealthString { get; set; }
      public string PreviousMonthHealthString { get; set; }
      public string ProjectNumber { get; set; }
      public string ProjectName { get; set; }
      public string ProjectStatus { get; set; }
      public decimal ProjectCompletion { get; set; }
      public bool? AddToWatchlist { get; set; }
      public int ProjectGoalId { get; set; }
      public int ProjectIndicatorId { get; set; }
      public int ProjectLevelId { get; set; }
      public EnumTypes.ProjectRatingText ProjectRatingText { get; set; }
      public EnumTypes.ProjectRatingColor RatingColor { get; set; }
      public int LOBId { get; set; }
      public int DepartmentId { get; set; }
      public string BusinessIssue { get; set; }
      public string Solution { get; set; }
      public string Benefits { get; set; }
      public string ProjectDirectory { get; set; }
      public EnumTypes.ProjectHealthColor ProjectHealth => ProjectHealthString.ToProjectHealthColor();
      public EnumTypes.ProjectHealthColor PreviousHealthColor => PreviousMonthHealthString.ToProjectHealthColor();
   }
}
