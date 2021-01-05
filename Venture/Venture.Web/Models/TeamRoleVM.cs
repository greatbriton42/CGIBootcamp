using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABC.Venture.Web.Models
{
   public class TeamRoleVM
   {
      public int TeamRoleID { get; set; }
      [StringLength(50)]
      public string TeamRole { get; set; }
   }
}