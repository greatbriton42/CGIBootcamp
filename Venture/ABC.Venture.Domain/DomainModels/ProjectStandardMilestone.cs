namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ProjectStandardMilestone")]
    public partial class ProjectStandardMilestone
    {
        public int ProjectStandardMilestoneID { get; set; }

        public int? ProjectID { get; set; }

        public DateTime? BaselineStart { get; set; }

        public DateTime? BaselineFinish { get; set; }

        public DateTime? RevisedStart { get; set; }

        public DateTime? RevisedFinish { get; set; }

        public DateTime? ActualStart { get; set; }

        public DateTime? ActualFinish { get; set; }

        public decimal? PercentComplete { get; set; }

        public int? StandardMilestoneID { get; set; }

        public bool? ShowInReport { get; set; }

        public virtual Project Project { get; set; }

        public virtual StandardMilestone StandardMilestone { get; set; }
    }
}
