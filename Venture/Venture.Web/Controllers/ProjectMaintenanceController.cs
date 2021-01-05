using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABC.Venture.Service;
using ABC.Venture.Web.Models;
using ABC.Venture.Common.GridEx;
using ABC.Venture.DTO;
using System.Text.RegularExpressions;
using System.Net;

namespace ABC.Venture.Web.Controllers
{
   public class ProjectMaintenanceController : Controller
   {
      public ActionResult ProjectMaintenance(int projectId = 0)
      {
         return View(projectId);
      }

      public PartialViewResult ProjectDetails(int projectId)
      {
         ProjectDetailsVM detailsVM;
         var service = new ProjectMaintenanceService();
         if(projectId != 0)
         {

            var projectDetails = service.GetProjectDetailsById(projectId);
            ProjectDetailsVM detailsVMtemp = new ProjectDetailsVM(projectDetails);
            detailsVM = detailsVMtemp;
         }
         else
         {
            var detailsVMtemp = new ProjectDetailsVM();
            detailsVM = detailsVMtemp;
            detailsVM.ProjectId = projectId;
         }
         detailsVM.Departments = service.GetDepartmentsList().Select(x => new DepartmentVM
         {
            DepartmentID = x.DepartmentID,
            Department = x.Department1
         });
         detailsVM.Indicators = service.GetIndicatorsList().Select(x => new IndicatorVM
         {
            IndicatorID = x.IndicatorID,
            ProjectIndicator = x.ProjectIndicator
         });
         detailsVM.ProjectLevels = service.GetProjectLevelsList().Select(x => new ProjectLevelVM
         {
            ProjectLevel = x.ProjectLevel1,
            ProjectLevelID = x.ProjectLevelID
         });
         detailsVM.ProjectGoals = service.GetProjectGoalsList().Select(x => new ProjectGoalVM
         {
            ProjectGoal = x.ProjectGoal1,
            ProjectGoalID = x.ProjectGoalID
         });
         detailsVM.LOBs = service.GetLOBList().Select(x => new LOBVM
         {
            LOB = x.LOB,
            LOBID = x.LOBID
         });
         return PartialView("_ProjectDetails", detailsVM);
      }

      public ActionResult ProjectTeam(int projectId)
      {
         try
         {
            return PartialView("_ProjectTeam", projectId);
         }
         catch(Exception)
         {
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
         }
         
      }

      public ActionResult ProjectDetailOverview(int projectId)
      {
         ProjectMaintenanceService service = new ProjectMaintenanceService();
         var detailsDTO = service.GetProjectDetailOverview(projectId);
         var detailsVM = new ProjectDetailOverviewVM(detailsDTO);
         return PartialView("_ProjectDetailsOverview", detailsVM);
      }

      public ActionResult ProjectTeamList(ProjectTeamCriteria criteria, int projectId)
      {
         ProjectMaintenanceService service = new ProjectMaintenanceService();
         var grid = service.GetProjectTeam(projectId, criteria);
         grid.Criteria = criteria ?? new ProjectTeamCriteria();
         var teamListVM = grid.Select(x => new ProjectTeamVM(x));
         var paginate = new PaginateVM<ProjectTeamDTO, ProjectTeamVM>(grid, criteria, teamListVM);
         var teamTabVM = new TeamTabVM();
         teamTabVM.projectId = projectId;
         teamTabVM.Paginate = paginate;
         teamTabVM.ResourceList = service.GetResources().Select(x => new ResourceVM
         {
            ResourceID = x.ResourceID,
            ResourceName = x.ResourceName
         });
         teamTabVM.RoleList = service.GetTeamRoles().Select(x => new TeamRoleVM
         {
            TeamRole = x.TeamRole,
            TeamRoleID = x.TeamRoleID
         });
         return PartialView("_ProjectTeamList", teamTabVM);
      }

      public void DeleteTeamMember(int projectTeamId)
      {
         var service = new ProjectMaintenanceService();
         service.DeleteProjectTeamMember(projectTeamId);
      }
      public JsonResult InsertTeamMember(int projectId, int roleId, int resourceId)
      {
         var service = new ProjectMaintenanceService();
         try
         {
            service.AddProjectTeamMember(projectId, roleId, resourceId);
         }
         catch(InvalidOperationException e)
         {
            return Json(e.Message);
         }

         return Json("");
      }

      public ActionResult SaveDetails(ProjectDetailsVM details)
      {
         if(!ModelState.IsValid)
         {
            return View("ProjectMaintenance", details.ProjectId);
         }
         var service = new ProjectMaintenanceService();
         var detailDTO = new ProjectDetailsDTO()
         {
            ProjectId = details.ProjectId,
            AddToWatchlist = details.AddToWatchlist,
            ProjectGoalId = details.ProjectGoalId,
            ProjectLevelId = details.ProjectLevelId,
            ProjectIndicatorId = details.ProjectIndicatorId,
            ProjectHealthString = details.ProjectHealth.ToString().ToLower(),
            LOBId = details.LOBId,
            DepartmentId = details.DepartmentId,
            BusinessIssue = details.BusinessIssue,
            Solution = details.Solution,
            Benefits = details.Benefits,
            ProjectDirectory = details.ProjectDirectory,
            ProjectName = details.ProjectName
         };

         int projectId = service.SaveProjectDetails(detailDTO);
         return RedirectToAction(nameof(ProjectMaintenance), new { projectId = projectId });

      }

      public JsonResult UpdateTeamMember(int projectTeamId,int projectId, int roleId, int resourceId)
      {
         var service = new ProjectMaintenanceService();
         try
         {
            service.UpdateProjectTeamMember(projectTeamId,projectId, roleId, resourceId);
         }
         catch(InvalidOperationException e)
         {
            return Json(e.Message);
         }
         return Json("");       
      }
   }

}