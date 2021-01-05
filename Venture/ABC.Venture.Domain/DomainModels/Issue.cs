namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Issue")]
    public partial class Issue
    {
        public int IssueID { get; set; }

        public int IssueTypeID { get; set; }

        public int IssueStatusID { get; set; }

        public int DepartmentID { get; set; }

        public int ProjectTeamID { get; set; }

        public DateTime? TargetDate { get; set; }

        public DateTime? ActualDate { get; set; }

        [Column("Issue")]
        [StringLength(255)]
        public string Issue1 { get; set; }

        [StringLength(1000)]
        public string NextAction { get; set; }

        [StringLength(25)]
        public string Source { get; set; }

        public int? IssueNumber { get; set; }

        public virtual Department Department { get; set; }

        public virtual IssueStatu IssueStatu { get; set; }

        public virtual IssueType IssueType { get; set; }

        public virtual ProjectTeam ProjectTeam { get; set; }
    }
}
