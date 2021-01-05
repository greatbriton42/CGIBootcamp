using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Venture.Common;

namespace ABC.Venture.Domain
{
   public static class BusinessValues
   {
      /// <summary>
      /// Returns Latest Project Health
      /// </summary>
      /// <param name="health">Tables Required: ProjectProjectHealth, ProjectHealth, Limited by one project</param>
      /// <returns></returns>
      public static IQueryable<ProjectProjectHealth> GetCurrentProjectHealth(IQueryable<ProjectProjectHealth> health)
      {
         return health.OrderByDescending(x => x.ProjectHealthDate);
      }

      /// <summary>
      /// Returns Previous Latest Project Health
      /// </summary>
      /// <param name="health">Tables Required: ProjectProjectHealth, ProjectHealth, Limited by one project</param>
      /// <returns></returns>
      public static IQueryable<ProjectProjectHealth> GetPreviousHealth(IQueryable<ProjectProjectHealth> health)
      {
         return health.OrderByDescending(x => x.ProjectHealthDate).Skip(1);
      }

      /// <summary>
      /// Determine what the Project Rating Text is
      /// </summary>
      /// <param name="info">Required Tables: One Project, Indicator, StandardMilestones, ProjectStandardMilestone,
      ///                                     FinancialInformation, Status </param>
      /// <returns></returns>
      public static EnumTypes.ProjectRatingText GetProjectRatingText(Project info)
      {
         var implementationMilestone = info.ProjectStandardMilestones.Where(x => (int?)EnumTypes.StandardMilestonesOptions.Implementation
                                                                        == x.StandardMilestoneID)
                                                               .FirstOrDefault();
         var financialInformation = info.FinancialInformations.FirstOrDefault();
         var statusClass = info.Indicator.Status;
         var indicator = info.Indicator;

         var baselineFinish = implementationMilestone != null ? implementationMilestone.BaselineFinish : null;
         var capitalSpent = financialInformation != null ? financialInformation.CapitalSpent : null;
         var approvedCapital = financialInformation != null ? financialInformation.ApprovedCap : null;
         var status = statusClass?.StatusID;
         var projectIndicator = indicator?.ProjectIndicator;



         if((int)EnumTypes.ProjectStatus.Pending == status)
         {
            return EnumTypes.ProjectRatingText.Empty;
         }

         if(baselineFinish >= DateTime.Now
           && capitalSpent < approvedCapital)
         {
            return EnumTypes.ProjectRatingText.Empty;
         }

         if(baselineFinish <= DateTime.Now
          && capitalSpent > approvedCapital)
         {
            return EnumTypes.ProjectRatingText.Both;
         }

         if(baselineFinish <= DateTime.Now
          && capitalSpent < approvedCapital)
         {
            return EnumTypes.ProjectRatingText.Schedule;
         }
         else if((int)EnumTypes.ProjectStatus.Cancelled == status
                 || (int)EnumTypes.ProjectStatus.Complete == status)
         {
            return EnumTypes.ProjectRatingText.Empty;
         }
         else
            return EnumTypes.ProjectRatingText.Empty;

      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="info"> Tables Required: One Project, Indicator, StandardMilestones, ProjectStandardMilestone,
      ///                                     FinancialInformation, Status </param>
      /// <returns></returns>
      public static EnumTypes.ProjectRatingColor GetProjectRatingColor(Project info)
      { 
         var implementationMilestone = info.ProjectStandardMilestones.Where(x => (int?)EnumTypes.StandardMilestonesOptions.Implementation
                                                                              ==  x.StandardMilestoneID)
                                                                     .FirstOrDefault();
         var financialInformation = info.FinancialInformations.FirstOrDefault();
         var statusClass = info.Indicator.Status;
         var indicator = info.Indicator;

         var baselineFinish = implementationMilestone != null ? implementationMilestone.BaselineFinish : null;
         var capitalSpent = financialInformation != null ? financialInformation.CapitalSpent : 0;
         var approvedCapital = financialInformation != null ? financialInformation.ApprovedCap : 0;
         var status = statusClass?.StatusID;
         var projectIndicator = indicator?.ProjectIndicator;


         if((int)EnumTypes.ProjectStatus.Pending == info.Indicator.Status.StatusID)
         {
            return EnumTypes.ProjectRatingColor.Gray;
         }

         if(baselineFinish >= DateTime.Now
            && capitalSpent < approvedCapital
            || projectIndicator == "Override Green")
         {
            return EnumTypes.ProjectRatingColor.Green;
         }

         if(projectIndicator == "Override Yellow"
          || baselineFinish < DateTime.Now
               && DateTime.Now.AddMonths(-Constants.MONTHS_AFTER_BASELINE_FINISH) <= baselineFinish
          || capitalSpent > approvedCapital
               && capitalSpent <= approvedCapital * Constants.APPROVED_CAPITAL_MULTIPLIER)
         {
            return EnumTypes.ProjectRatingColor.Yellow;
         }

         if(projectIndicator == "Override Red"
         || baselineFinish > DateTime.Now.AddMonths(-Constants.MONTHS_AFTER_BASELINE_FINISH)
         || capitalSpent > approvedCapital * Constants.APPROVED_CAPITAL_MULTIPLIER)
         {
            return EnumTypes.ProjectRatingColor.Red;
         }

         if((int)EnumTypes.ProjectStatus.Cancelled == status
         || (int)EnumTypes.ProjectStatus.Complete == status)
         {
            return EnumTypes.ProjectRatingColor.Blue;
         }
         else
            return EnumTypes.ProjectRatingColor.White; // White used for undetermined

      }

      /// <summary>
      /// Calculate the Project Completion Percentage
      /// </summary>
      /// <param name="standardMilestones">Tables Required: ProjectStandardMilestone, StandardMilestones</param>
      /// <returns>Returns a decimal representation of percent</returns>
      public static decimal GetProjectCompletion(List<ProjectStandardMilestone> standardMilestones)
      {
         decimal? pointTotal = 0M;
         int? totalPoints = 0;
         foreach(ProjectStandardMilestone milestone in standardMilestones)
         {
            if(milestone.PercentComplete != null)
            {
               pointTotal += milestone.StandardMilestone.BaselinePoints * (milestone.PercentComplete / 100);
               totalPoints += milestone.StandardMilestone.BaselinePoints;
            }
         }
         if(totalPoints == 0)
         {
            return 0;
         }
         return (decimal)(pointTotal / totalPoints);
      }
      /// <summary>
      /// 6.3.9 Calculate Project Status
      /// </summary>
      /// <param name="statusDate"></param>
      /// <returns></returns>
      public static EnumTypes.StatusUpdateFlag GetStatusUpdateFlag(DateTime? statusDate)
      {
         if(statusDate == null)
         {
            return EnumTypes.StatusUpdateFlag.None;
         }
         else if(statusDate.Value.AddDays(Constants.WITHIN_GREEN_STATUS_FLAG_DAYS) >= DateTime.Now)
         {
            return EnumTypes.StatusUpdateFlag.Green;
         }
         else if(statusDate.Value.AddDays(Constants.WITHIN_YELLOW_STATUS_FLAG_DAYS) >= DateTime.Now)
         {
            return EnumTypes.StatusUpdateFlag.Yellow;
         }
         else
         {
            return EnumTypes.StatusUpdateFlag.Red;
         }

      }
   }
}
