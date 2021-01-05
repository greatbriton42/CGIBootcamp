using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Venture.Data;
using ABC.Venture.Domain;
using ABC.Venture.DTO;
using ABC.Venture.Common;
using ABC.Venture.Common.GridEx;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ABC.Venture.Service
{
   public class ViewTodayService
   {
      private VentureDatabase _ctx = new VentureDatabase();

      public IGrid<ProjectTrackingItemsDTO> GetUpcomingTrackingItems(PageSortCriteria pageSortCriteria)
      {
         IQueryable<Issue> issues = _ctx.Issues.Include(x => x.ProjectTeam)
                                 .Include(x => x.ProjectTeam.Resource)
                                 .Include(x => x.ProjectTeam.Project);
         issues = TableFiltering.UpcomingProjectTrackingItemsFilter(issues);
         return issues.Select(i => new ProjectTrackingItemsDTO
         {
            Issue = i.Issue1,
            ProjectID = i.ProjectTeam.ProjectID,
            IssueType = i.IssueType.IssueType1,
            Status = i.IssueStatu.IssueStatus,
            ProjectName = i.ProjectTeam.Project.ProjectName,
            AssignedTo = i.ProjectTeam.Resource.Resource1,
            NextAction = i.NextAction,
            TargetDate = i.TargetDate,
            IssueId = i.IssueID
         }).ToPagedList(pageSortCriteria.Filter, pageSortCriteria.Sort,
                                     pageSortCriteria.Order, (int)pageSortCriteria.Page,
                                     Constants.MAX_RECORDS_PER_TABLE);

      }

      public IGrid<UpcomingMilestoneDTO> GetUpcomingMilestones(PageSortCriteria pageSortCriteria)
      {
         var projectMilestones = TableFiltering.UpcomingMilestoneFilter(_ctx.ProjectMilestones.Include(x => x.Project))
            .Select(milestone => new UpcomingMilestoneDTO
            {
               ProjectName = milestone.Project.ProjectName,
               Milestone = milestone.Milestone,
               ActualFinish = milestone.ActualFinish,
               ActualStart = milestone.ActualStart,
               BaselineFinish = milestone.BaselineFinish,
               BaselineStart = milestone.BaselineStart,
               PercentComplete = milestone.PercentComplete
            });

         var standardMilestones = TableFiltering.UpcomingMilestoneFilter(_ctx.ProjectStandardMilestones.Include(x => x.Project)
                                                                                                       .Include(x => x.StandardMilestone))
                                                 .Select(m => new UpcomingMilestoneDTO
                                                 {
                                                    ProjectName = m.Project.ProjectName,
                                                    Milestone = m.StandardMilestone.StandardMilestone1,
                                                    ActualFinish = m.ActualFinish,
                                                    ActualStart = m.ActualStart,
                                                    BaselineFinish = m.BaselineFinish,
                                                    BaselineStart = m.BaselineStart,
                                                    PercentComplete = m.PercentComplete
                                                 });

         var milestones = projectMilestones.Concat(standardMilestones);
         return milestones.ToPagedList(pageSortCriteria.Filter, pageSortCriteria.Sort,
                                       pageSortCriteria.Order, (int)pageSortCriteria.Page,
                                       Constants.MAX_RECORDS_PER_TABLE);

      }

      public IGrid<MyProjectDTO> GetMyProjects(PageSortCriteria pageSortCriteria)
      {
         var projects = _ctx.Projects.Include(x => x.ProjectStatus).ToList();

         return projects.Select(x => new MyProjectDTO
         {
            ProjectId = x.ProjectID,
            ProjectName = x.ProjectName,
            ProjectNumber = x.ProjectNumber,
            StatusUpdate = BusinessValues.GetStatusUpdateFlag
                                                   (x.ProjectStatus.Count == 0 ? default(DateTime?) :
                                                    x.ProjectStatus.OrderByDescending(y => y.StatusDate).FirstOrDefault().StatusDate)
         }).AsQueryable().ToPagedList(pageSortCriteria.Filter, pageSortCriteria.Sort,
                                            pageSortCriteria.Order, (int)pageSortCriteria.Page,
                                            Constants.MAX_RECORDS_PER_TABLE);
      }

   }
}
