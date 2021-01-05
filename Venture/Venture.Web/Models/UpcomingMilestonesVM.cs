using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ABC.Venture.DTO;
using ABC.Venture.Common;

namespace ABC.Venture.Web.Models
{
   public class UpcomingMilestonesVM
   {

      public string ProjectName { get; set; }
      public string Milestone { get; set; }
      [DisplayFormat(DataFormatString = Constants.DATE_FORMAT, ApplyFormatInEditMode = true)]
      public DateTime? BaselineStart { get; set; }
      [DisplayFormat(DataFormatString = Constants.DATE_FORMAT, ApplyFormatInEditMode = true)]
      public DateTime? BaselineFinish { get; set; }
      [DisplayFormat(DataFormatString = Constants.DATE_FORMAT, ApplyFormatInEditMode = true)]
      public DateTime? ActualStart { get; set; }
      [DisplayFormat(DataFormatString = Constants.DATE_FORMAT, ApplyFormatInEditMode = true)]
      public DateTime? ActualFinish { get; set; }
      public Decimal? PercentComplete { get; set; }
      public UpcomingMilestonesVM(UpcomingMilestoneDTO dto)
      {
         ProjectName = dto.ProjectName;
         Milestone = dto.Milestone;
         BaselineStart = dto.BaselineStart;
         BaselineFinish = dto.BaselineFinish;
         ActualStart = dto.ActualStart;
         ActualFinish = dto.ActualFinish;
         PercentComplete = dto.PercentComplete;
      }

   }
}