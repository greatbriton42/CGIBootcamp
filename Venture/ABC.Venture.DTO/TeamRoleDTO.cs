using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.DTO
{
   public class TeamRoleDTO
   {
      public int TeamRoleID { get; set; }
      [StringLength(50)]
      public string TeamRole { get; set; }
   }
}
