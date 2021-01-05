using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Venture.Common;

namespace ABC.Venture.Domain
{
   public static class TableFiltering
   {
      /// <summary>
   /// Returns all upcoming or over due tracking items 
   /// </summary>
   /// <param name="issues"></param>
   /// <returns></returns>
      public static IQueryable<Issue> UpcomingProjectTrackingItemsFilter(IQueryable<Issue> issues)
      {
         return issues.Where(i => DbFunctions.DiffDays(DateTime.Now, i.TargetDate) < Constants.DAYS_TILL_TRACKINGITEMS_DUE);
      }

      /// <summary>
      /// Upcoming Milestone Filter Overloaded for ProjectMilestone
      /// </summary>
      /// <param name="milestone"></param>
      /// <returns></returns>
      public static IQueryable<ProjectMilestone> UpcomingMilestoneFilter(IQueryable<ProjectMilestone> milestone)
      {
         return milestone.Where(m => DbFunctions.DiffDays(DateTime.Now, m.BaselineFinish) < Constants.DAYS_TILL_MILESTONES_DUE);
      }

      /// <summary>
      /// Upcoming Milestone Filter Overloaded for ProjectStandardMilestone
      /// </summary>
      /// <param name="milestone"></param>
      /// <returns></returns>
      public static IQueryable<ProjectStandardMilestone> UpcomingMilestoneFilter(IQueryable<ProjectStandardMilestone> milestone)
      {
         return milestone.Where(m => DbFunctions.DiffDays(DateTime.Now, m.BaselineFinish) < Constants.DAYS_TILL_MILESTONES_DUE);
      }
   }
}
