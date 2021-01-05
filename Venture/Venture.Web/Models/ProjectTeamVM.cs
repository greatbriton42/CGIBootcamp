using ABC.Venture.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABC.Venture.Web.Models
{
   public class ProjectTeamVM
   {
      public int RoleId { get; set; }
      public int ResourceId { get; set; }
      public int ProjectTeamId { get; set; }
      [StringLength(50)]
      public string Role { get; set; }
      [StringLength(50)]
      public string Resource { get; set; }
      [StringLength(20)]
      public string Phone { get; set; }
      [StringLength(75)]
      public string Email { get; set; }

      public ProjectTeamVM(ProjectTeamDTO dto)
      {
         RoleId = dto.RoleId;
         ProjectTeamId = dto.ProjectTeamId;
         ResourceId = dto.ResourceId;
         Role = dto.Role;
         Resource = dto.Resource;
         Phone = dto.Phone;
         Email = dto.Email;
      }
   }
}