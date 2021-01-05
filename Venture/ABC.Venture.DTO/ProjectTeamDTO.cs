using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.DTO
{
   public class ProjectTeamDTO
   {
      public int RoleId { get; set; }
      public int ResourceId { get; set; }
      public int ProjectTeamId { get; set; }
      public string Role { get; set; }
      public string Resource { get; set; }
      public string Phone { get; set; }
      public string Email { get; set; }

   }
}
