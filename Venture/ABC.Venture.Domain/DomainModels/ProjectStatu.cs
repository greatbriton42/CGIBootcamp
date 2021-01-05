namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class ProjectStatu
    {
        [Key]
        public int ProjectStatusID { get; set; }

        [Required]
        [StringLength(3000)]
        public string ExecutiveSummary { get; set; }

        [Required]
        [StringLength(3000)]
        public string Accomplishments { get; set; }

        [Required]
        [StringLength(3000)]
        public string PlannedActivities { get; set; }

        public DateTime StatusDate { get; set; }

        public int? ProjectID { get; set; }

        public decimal PercentEffort { get; set; }

        public virtual Project Project { get; set; }
    }
}
