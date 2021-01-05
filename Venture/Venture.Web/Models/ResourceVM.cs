using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABC.Venture.Web.Models
{
   public class ResourceVM
   {
      public int ResourceID { get; set; }

      [StringLength(50)]
      public string ResourceName { get; set; }
   }
}