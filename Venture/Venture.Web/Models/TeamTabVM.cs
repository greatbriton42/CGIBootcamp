using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABC.Venture.DTO;

namespace ABC.Venture.Web.Models
{
   public class TeamTabVM
   {
      public PaginateVM<ProjectTeamDTO, ProjectTeamVM> Paginate { get; set; }
      public IEnumerable<ResourceVM> ResourceList { get; set; }
      public IEnumerable<TeamRoleVM> RoleList { get; set; }
      public int projectId { get; set; }

   }
}