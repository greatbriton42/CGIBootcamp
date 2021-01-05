namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Project")]
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            FinancialInformations = new HashSet<FinancialInformation>();
            LessonLearneds = new HashSet<LessonLearned>();
            ProjectConsensusRatings = new HashSet<ProjectConsensusRating>();
            ProjectMilestones = new HashSet<ProjectMilestone>();
            ProjectProjectHealths = new HashSet<ProjectProjectHealth>();
            ProjectRatingHistories = new HashSet<ProjectRatingHistory>();
            ProjectStandardMilestones = new HashSet<ProjectStandardMilestone>();
            ProjectStatus = new HashSet<ProjectStatu>();
            ProjectTeams = new HashSet<ProjectTeam>();
            Risks = new HashSet<Risk>();
        }

        public int ProjectID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectName { get; set; }

        public int ProjectYear { get; set; }

        public int ProjectSeqNumber { get; set; }

        public bool? Watchlist { get; set; }

        [StringLength(3000)]
        public string BusinessIssue { get; set; }

        [StringLength(3000)]
        public string Solution { get; set; }

        [StringLength(3000)]
        public string Benefits { get; set; }

        [Required]
        [StringLength(2000)]
        public string ProjectDirectory { get; set; }

        public int? DepartmentID { get; set; }

        public int? ProjectGoalID { get; set; }

        public int? ProjectLevelID { get; set; }

        public int? LOBID { get; set; }

        public int? IndicatorID { get; set; }

        [Required]
        [StringLength(20)]
        public string ProjectNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string PriorityCode { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinancialInformation> FinancialInformations { get; set; }

        public virtual Indicator Indicator { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LessonLearned> LessonLearneds { get; set; }

        public virtual LOB LOB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectConsensusRating> ProjectConsensusRatings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectMilestone> ProjectMilestones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectProjectHealth> ProjectProjectHealths { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectRatingHistory> ProjectRatingHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectStandardMilestone> ProjectStandardMilestones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectStatu> ProjectStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectTeam> ProjectTeams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Risk> Risks { get; set; }

        public virtual ProjectGoal ProjectGoal { get; set; }

        public virtual ProjectLevel ProjectLevel { get; set; }
    }
}
