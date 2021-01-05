using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ABC.Venture.Common;
using ABC.Venture.DTO;

namespace ABC.Venture.Web.Models
{
   public class ProjectDetailsVM
   {
      public int ProjectId { get; set; }
      [StringLength(50)]
      [Display(Name = "Project Number")]
      public string ProjectNumber { get; set; }
      [Required]
      [RegularExpression(@".*\S.*", ErrorMessage = "Project Name is Required")]
      [Display(Name = "Project Name")]
      public string ProjectName { get; set; }
      [StringLength(25)]
      [Display(Name = "Project Status")]
      public string ProjectStatus { get; set; }
      private decimal _projectCompletion;
      [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
      [Display(Name = "Project Completion")]
      public decimal ProjectCompletion { get => _projectCompletion * 100; set => _projectCompletion = value; }
      [Required]
      [Display(Name = "Add to WatchList")]
      public bool AddToWatchlist { get; set; }
      [Required]
      [Display(Name = "Project Goal")]
      public int ProjectGoalId { get; set; }
      [Required]
      [Display(Name = "Project Indicator")]
      public int ProjectIndicatorId { get; set; }
      [Display(Name = "Project Level")]
      public int ProjectLevelId { get; set; }
      [Display(Name = "Project Rating")]
      public EnumTypes.ProjectRatingText ProjectRatingText { get; set; }
      public EnumTypes.ProjectRatingColor RatingColor { get; set; }
      [Required]
      [Display(Name = "LOB")]
      public int LOBId { get; set; }
      [Required]
      [Display(Name = "Department:")]
      public int DepartmentId { get; set; }
      [StringLength(3000)]
      [Display(Name = "Business Issue:")]
      public string BusinessIssue { get; set; }
      [StringLength(3000)]
      [Display(Name = "Solution:")]
      public string Solution { get; set; }
      [StringLength(3000)]
      [Display(Name = "Benefits:")]
      public string Benefits { get; set; }
      [Required]
      [StringLength(255)]
      [Display(Name= "Project Directory:")]
      [RegularExpression(@".*\S.*", ErrorMessage = "Project Directory is Required")]
      public string ProjectDirectory { get; set; }
      [Required]
      [Display(Name = "Current Health")]
      public EnumTypes.ProjectHealthColor ProjectHealth { get; set; }
      [Display(Name = "Previous Project Health")]
      public EnumTypes.ProjectHealthColor PreviousHealthColor { get; set; }
      public IEnumerable<ProjectGoalVM> ProjectGoals { get; set;}

      public IEnumerable<ProjectLevelVM> ProjectLevels { get; set; }
      public IEnumerable<IndicatorVM> Indicators { get; set; }
      public IEnumerable<LOBVM> LOBs { get; set; }
      public IEnumerable<DepartmentVM> Departments { get; set; }

      public ProjectDetailsVM(ProjectDetailsDTO dto)
      {
         ProjectId = dto.ProjectId;
         ProjectNumber = dto.ProjectNumber;
         ProjectName = dto.ProjectName;
         ProjectRatingText = dto.ProjectRatingText;
         ProjectStatus = dto.ProjectStatus;
         ProjectLevelId = dto.ProjectLevelId;
         ProjectIndicatorId = dto.ProjectIndicatorId;
         ProjectHealth = dto.ProjectHealth;
         PreviousHealthColor = dto.PreviousHealthColor;
         RatingColor = dto.RatingColor;
         LOBId = dto.LOBId;
         DepartmentId = dto.DepartmentId;
         BusinessIssue = dto.BusinessIssue;
         Solution = dto.Solution;
         Benefits = dto.Benefits;
         ProjectDirectory = dto.ProjectDirectory;
         ProjectRatingText = dto.ProjectRatingText;
         RatingColor = dto.RatingColor;
         ProjectCompletion = dto.ProjectCompletion;
         AddToWatchlist = (bool)dto.AddToWatchlist;
      }
      public ProjectDetailsVM(){}
   }
}