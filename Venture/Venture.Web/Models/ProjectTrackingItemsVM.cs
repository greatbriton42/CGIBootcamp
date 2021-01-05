using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ABC.Venture.Common;
using ABC.Venture.DTO;

namespace ABC.Venture.Web.Models
{
   public class ProjectTrackingItemsVM
   {

      public string ProjectName { get; set; }
      public int IssueId { get; set; }
      public int? ProjectID { get; set; }
      public string IssueType { get; set; }
      public string Issue { get; set; }
      public string AssignedTo { get; set; }
      public string NextAction { get; set; }
      [DisplayFormat(DataFormatString = Constants.DATE_FORMAT, ApplyFormatInEditMode = true)]
      public DateTime? TargetDate { get; set; }
      public string Status { get; set; }

      public ProjectTrackingItemsVM(ProjectTrackingItemsDTO project)
      {
         ProjectName = project.ProjectName;
         ProjectID = project.ProjectID;
         IssueType = project.IssueType;
         Issue = project.Issue;
         AssignedTo = project.AssignedTo;
         NextAction = project.NextAction;
         TargetDate = project.TargetDate;
         Status = project.Status;
         IssueId = project.IssueId;
      }

   }
}