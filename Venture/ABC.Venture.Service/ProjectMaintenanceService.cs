using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Venture.DTO;
using ABC.Venture.Common;
using ABC.Venture.Data;
using System.Data.Entity;
using ABC.Venture.Domain;
using ABC.Venture.Common.GridEx;
using System.Data.Entity.Infrastructure;

namespace ABC.Venture.Service
{
   public class ProjectMaintenanceService
   {
      private VentureDatabase _ctx = new VentureDatabase();
      public List<ResourceDTO> GetResources()
      {
         return _ctx.Resources.Select(r => new ResourceDTO
         {
            ResourceID = r.ResourceID,
            ResourceName = r.Resource1,
            Email = r.Email,
            Phone = r.Phone,
            UserID = r.UserID
         }).ToList<ResourceDTO>();
      }

      public ProjectDetailsDTO GetProjectDetailsById(int projectId)
      {

         var projectDetails = _ctx.Projects.Include(x => x.LOB)
                                           .Include(x => x.Indicator)
                                           .Include(x => x.Indicator.Status)
                                           .Include(x => x.ProjectGoal)
                                           .Include(x => x.ProjectLevel)
                                           .Include(x => x.Department)
                                           .Where(p => p.ProjectID == projectId);
         var projectDetailsDTO = projectDetails.Select(d => new ProjectDetailsDTO
         {
            ProjectId = projectId,
            AddToWatchlist = d.Watchlist,
            Benefits = d.Benefits,
            BusinessIssue = d.BusinessIssue,
            DepartmentId = d.Department.DepartmentID,
            LOBId = d.LOB.LOBID,
            ProjectName = d.ProjectName,
            ProjectNumber = d.ProjectNumber,
            ProjectDirectory = d.ProjectDirectory,
            ProjectIndicatorId = d.Indicator.IndicatorID,
            ProjectStatus = d.Indicator.Status.Status1,
            ProjectGoalId = d.ProjectGoal.ProjectGoalID,
            Solution = d.Solution,
            ProjectLevelId = d.ProjectLevel.ProjectLevelID,

         }).First();

         var projectHealth = _ctx.ProjectProjectHealths.Include(x => x.ProjectHealth)
                                                       .Where(x => x.ProjectID == projectId);
         var health = BusinessValues.GetCurrentProjectHealth(projectHealth).FirstOrDefault();
         var previousHealth = BusinessValues.GetPreviousHealth(projectHealth).FirstOrDefault();
         var projectRating = _ctx.Projects.Include(x => x.Indicator)
                                          .Include(x => x.FinancialInformations)
                                          .Include(x => x.ProjectStandardMilestones)
                                          .Include(x => x.ProjectStandardMilestones.Select(y => y.StandardMilestone))
                                          .Include(x => x.Indicator.Status)
                                          .Where(p => p.ProjectID == projectId)
                                          .First();

         var projectCompletion = _ctx.ProjectStandardMilestones.Include(x => x.StandardMilestone)
                                                               .Where(p => p.ProjectID == projectId)
                                                               .ToList();

         projectDetailsDTO.RatingColor = BusinessValues.GetProjectRatingColor(projectRating);
         projectDetailsDTO.ProjectRatingText = BusinessValues.GetProjectRatingText(projectRating);
         projectDetailsDTO.ProjectCompletion = BusinessValues.GetProjectCompletion(projectCompletion);
         projectDetailsDTO.ProjectHealthString = health != null ?  health.ProjectHealth.ProjectHealth1 : null;
         projectDetailsDTO.PreviousMonthHealthString = previousHealth != null ? health.ProjectHealth.ProjectHealth1 : null;

         return projectDetailsDTO;
      }

      public ProjectDetailOverviewDTO GetProjectDetailOverview(int projectId)
      {
         var projectDetails = _ctx.Projects.Include(x => x.FinancialInformations)
                                           .Where(x => x.ProjectID == projectId)
                                           .First();
         var financialInformation = projectDetails.FinancialInformations.FirstOrDefault();

         var projectCompletion = _ctx.ProjectStandardMilestones.Include(x => x.StandardMilestone)
                                                               .Where(p => p.ProjectID == projectId)
                                                               .ToList();
         var projectRating = _ctx.Projects.Include(x => x.Indicator)
                                          .Include(x => x.FinancialInformations)
                                          .Include(x => x.ProjectStandardMilestones)
                                          .Include(x => x.ProjectStandardMilestones.Select(y => y.StandardMilestone))
                                          .Include(x => x.Indicator.Status)
                                          .Where(p => p.ProjectID == projectId)
                                          .First();
         var projectHealth = _ctx.ProjectProjectHealths.Include(x => x.ProjectHealth)
                                                       .Where(x => x.ProjectID == projectId);
         var health = BusinessValues.GetCurrentProjectHealth(projectHealth).FirstOrDefault();

         ProjectDetailOverviewDTO detailsDTO = new ProjectDetailOverviewDTO
         {
            ProjectName = projectDetails.ProjectName,
            ProjectNumber = projectDetails.ProjectNumber,
            PercentCapitalSpent = financialInformation != null ? financialInformation.CapitalSpent / 
                                    (financialInformation.ApprovedCapital != 0 ? financialInformation.ApprovedCapital: null) : null,
            ProjectDirectory = projectDetails.ProjectDirectory
         };

         detailsDTO.ProjectCompletion = BusinessValues.GetProjectCompletion(projectCompletion);
         detailsDTO.ProjectHealthString = health != null ? health.ProjectHealth.ProjectHealth1 : null;
         detailsDTO.RatingColor = BusinessValues.GetProjectRatingColor(projectRating);
         detailsDTO.RatingText = BusinessValues.GetProjectRatingText(projectRating);

         return detailsDTO;
      }

      public List<LOBDTO> GetLOBList()
      {
         return _ctx.LOBs.Select(x => new LOBDTO
         {
            LOB = x.LOB1,
            LOBID = x.LOBID
         }).ToList();
      }

      public List<DepartmentDTO> GetDepartmentsList()
      {
         return _ctx.Departments.Select(x => new DepartmentDTO
         {
            Department1 = x.Department1,
            DepartmentHeadID = x.DepartmentHeadID,
            DepartmentID = x.DepartmentID
         }).ToList();
      }

      public List<ProjectGoalDTO> GetProjectGoalsList()
      {
         return _ctx.ProjectGoals.Select(x => new ProjectGoalDTO
         {
            ProjectGoal1 = x.ProjectGoal1,
            ProjectGoalID = x.ProjectGoalID
         }).ToList();

      }

      public List<IndicatorDTO> GetIndicatorsList()
      {
         return _ctx.Indicators.Select(x => new IndicatorDTO
         {
            IndicatorID = x.IndicatorID,
            ProjectIndicator = x.ProjectIndicator,
            ProjectStatusID = x.ProjectStatusID,
            SortNumber = x.SortNumber
         }).ToList();
      }

      public List<ProjectLevelDTO> GetProjectLevelsList()
      {
         return _ctx.ProjectLevels.Select(x => new ProjectLevelDTO
         {
            ProjectLevel1 = x.ProjectLevel1,
            ProjectLevelID = x.ProjectLevelID
         }).ToList();
      }

      public IGrid<ProjectTeamDTO> GetProjectTeam(int projectId, PageSortCriteria pageSortCriteria)
      {
         return _ctx.ProjectTeams.Include(x => x.Resource)
                                 .Include(x => x.ProjectTeamRoles)
                                 .Include(x => x.ProjectTeamRoles.Select(y => y.TeamRole))
                                 .Where(x => x.ProjectID == projectId && x.Deleted != true)
                                 .Select(x => new ProjectTeamDTO
                                 {
                                    ProjectTeamId = x.ProjectTeamID,
                                    ResourceId = x.ResourceID,
                                    RoleId = x.ProjectTeamRoles.Where(y => y.ProjectTeamID == x.ProjectTeamID).FirstOrDefault().TeamRole.TeamRoleID,
                                    Resource = x.Resource.Resource1,
                                    Email = x.Resource.Email,
                                    Phone = x.Resource.Phone,
                                    Role = x.ProjectTeamRoles.Where(y => y.ProjectTeamID == x.ProjectTeamID).FirstOrDefault().TeamRole.TeamRole1
                                 }).ToPagedList(pageSortCriteria.Filter, pageSortCriteria.Sort,
                                     pageSortCriteria.Order, (int)pageSortCriteria.Page,
                                     Constants.MAX_RECORDS_PER_TABLE);

      }

      public List<TeamRoleDTO> GetTeamRoles()
      {
         return _ctx.TeamRoles.Select(t => new TeamRoleDTO
         {
            TeamRoleID = t.TeamRoleID,
            TeamRole = t.TeamRole1
         }).ToList<TeamRoleDTO>();
      }

      /// <summary>
      /// Member variable is used to check if that resource/role/project combination already exists
      ///   query will return a null enumerable if no records exist with that combination and exception is thrown
      ///
      /// </summary>
      /// <param name="projectId"></param>
      /// <param name="roleId"></param>
      /// <param name="resourceId"></param>
      public void AddProjectTeamMember(int projectId, int roleId, int resourceId)
      {
         var member = _ctx.ProjectTeams.Where(x => x.ProjectID == projectId 
                                                && x.ResourceID == resourceId 
                                                && !x.Deleted 
                                                && x.ProjectTeamRoles.Any(y => y.TeamRoleID == roleId)).ToList();

         if(member.Count != 0)
         {
            throw new InvalidOperationException("This Resource and Role combination already exist");
         }

         var projectTeam = new ProjectTeam()
         {
            Deleted = false,
            ProjectID = projectId,
            ResourceID = resourceId,
         };
         projectTeam = _ctx.ProjectTeams.Add(projectTeam);
         _ctx.SaveChanges();
         var projectTeamRole = new ProjectTeamRole()
         {
            ProjectTeamID = projectTeam.ProjectTeamID,
            TeamRoleID = roleId
         };
         _ctx.ProjectTeamRoles.Add(projectTeamRole);
         _ctx.SaveChanges();
      }

      public void DeleteProjectTeamMember(int projectTeamId)
      {
         var teamMember = _ctx.ProjectTeams.Find(projectTeamId);
         teamMember.Deleted = true;
            _ctx.SaveChanges();
      }

      /// <summary>
      /// Member variable is used to check if that resource/role/project combination already exists
      ///   query will return a null enumerable if no records exist with that combination and exception is thrown
      /// </summary>
      /// <param name="projectTeamId"></param>
      /// <param name="roleId"></param>
      /// <param name="resourceId"></param>
      public void UpdateProjectTeamMember(int projectTeamId, int projectId, int roleId, int resourceId)
      {
         var member = _ctx.ProjectTeams.Where(x => x.ProjectID == projectId
                                                && x.ResourceID == resourceId
                                                && !x.Deleted
                                                && x.ProjectTeamRoles.Any(y => y.TeamRoleID == roleId)).ToList();

         if(member.Count != 0)
         {
            throw new InvalidOperationException("This Resource and Role combination already exist");
         }
         var projectTeam =_ctx.ProjectTeams.Where(x => x.ProjectTeamID == projectTeamId).Include(x => x.ProjectTeamRoles).FirstOrDefault();
         projectTeam.ResourceID = resourceId;
         projectTeam.ProjectTeamRoles.Where(x => x.ProjectTeamID == projectTeamId).FirstOrDefault().TeamRoleID = roleId;
         _ctx.SaveChanges();
      }

      public int SaveProjectDetails(ProjectDetailsDTO dto)
      {
         if(dto.ProjectId == 0)
         {
            var newSeqNumber = _ctx.Projects.Max(x => x.ProjectSeqNumber) + 1;
            var project = new Project()
            {
               LOBID = dto.LOBId,
               Benefits = dto.Benefits,
               BusinessIssue = dto.BusinessIssue,
               DepartmentID = dto.DepartmentId,
               IndicatorID = dto.ProjectIndicatorId,
               ProjectDirectory = dto.ProjectDirectory,
               ProjectGoalID = dto.ProjectGoalId,
               ProjectLevelID = dto.ProjectLevelId,
               Watchlist = dto.AddToWatchlist,
               ProjectName = dto.ProjectName,
               ProjectNumber = DateTime.Now.Year.ToString() + newSeqNumber.ToString(),
               PriorityCode = "0000",
               ProjectSeqNumber = newSeqNumber

            };
            var newProject = _ctx.Projects.Add(project);
            _ctx.SaveChanges();
            if(dto.ProjectHealth != EnumTypes.ProjectHealthColor.White)
            {
               var health = new ProjectProjectHealth()
               {
                  ProjectHealthDate = DateTime.Now,
                  ProjectHealthID = (int)dto.ProjectHealth,
                  ProjectID = newProject.ProjectID,
               };
               _ctx.ProjectProjectHealths.Add(health);
               _ctx.SaveChanges();
            }
            return newProject.ProjectID;
         }
         else
         {
            var project = _ctx.Projects.Where(x => x.ProjectID == dto.ProjectId).Include(x => x.ProjectProjectHealths).FirstOrDefault();
            project.LOBID = dto.LOBId;
            project.Benefits = dto.Benefits;
            project.BusinessIssue = dto.BusinessIssue;
            project.DepartmentID = dto.DepartmentId;
            project.IndicatorID = dto.ProjectIndicatorId;
            project.ProjectDirectory = dto.ProjectDirectory;
            project.ProjectGoalID = dto.ProjectGoalId;
            project.ProjectLevelID = dto.ProjectLevelId;
            project.Watchlist = dto.AddToWatchlist;
            project.ProjectName = dto.ProjectName;
            var health = new ProjectProjectHealth()
            {
               ProjectHealthDate = DateTime.Now,
               ProjectHealthID = (int)dto.ProjectHealth,
               ProjectID = dto.ProjectId,
            };
            _ctx.ProjectProjectHealths.Add(health);
            _ctx.SaveChanges();
            return dto.ProjectId;
         }
      }
   }
}
