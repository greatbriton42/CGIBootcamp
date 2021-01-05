namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ProjectMilestone")]
    public partial class ProjectMilestone
    {
        public int ProjectMilestoneID { get; set; }

        public int? ProjectID { get; set; }

        public DateTime? BaselineStart { get; set; }

        public DateTime? BaselineFinish { get; set; }

        public DateTime? RevisedStart { get; set; }

        public DateTime? RevisedFinish { get; set; }

        public DateTime? ActualStart { get; set; }

        public DateTime? ActualFinish { get; set; }

        public decimal? PercentComplete { get; set; }

        [StringLength(50)]
        public string Milestone { get; set; }

        public bool? ShowInReport { get; set; }

        public virtual Project Project { get; set; }
    }
}
