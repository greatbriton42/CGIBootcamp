using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABC.Venture.Common;
using ABC.Venture.DTO;

namespace ABC.Venture.Web.Models
{
   public class MyProjectsVM
   {
      public int ProjectId { get; set; }
      public string ProjectNumber { get; set; }
      public string ProjectName { get; set; }
      public EnumTypes.StatusUpdateFlag StatusUpdate { get; set; }

      public MyProjectsVM(MyProjectDTO dto)
      {
         ProjectId = dto.ProjectId;
         ProjectNumber = dto.ProjectNumber;
         ProjectName = dto.ProjectName;
         StatusUpdate = dto.StatusUpdate;
      }
   }
}