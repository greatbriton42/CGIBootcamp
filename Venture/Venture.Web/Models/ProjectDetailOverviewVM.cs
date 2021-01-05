using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ABC.Venture.Common;
using ABC.Venture.DTO;

namespace ABC.Venture.Web.Models
{
   public class ProjectDetailOverviewVM
   {
      public string ProjectNumber { get; set; }
      public string ProjectName { get; set; }
      [DisplayFormat(DataFormatString = "{0:P}", ApplyFormatInEditMode = true)]
      public decimal ProjectCompletion { get; set; }
      public EnumTypes.ProjectRatingColor RatingColor { get; set; }
      public EnumTypes.ProjectRatingText RatingText { get; set; }
      public EnumTypes.ProjectHealthColor ProjectHealth { get; set; }

      [DisplayFormat(NullDisplayText = "N/A", DataFormatString = "{0:P}", ApplyFormatInEditMode = true)]
      public decimal? PercentCapitalSpent { get; set; }
      public string ProjectDirectory { get; set; }

      public ProjectDetailOverviewVM(ProjectDetailOverviewDTO dto)
      {
         ProjectNumber = dto.ProjectNumber;
         ProjectName = dto.ProjectName;
         ProjectCompletion = dto.ProjectCompletion;
         RatingColor = dto.RatingColor;
         ProjectHealth = dto.ProjectHealth;
         PercentCapitalSpent = dto.PercentCapitalSpent;
         RatingText = dto.RatingText;
         ProjectDirectory = dto.ProjectDirectory;
      }
   }
}