namespace ABC.Venture.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Risk")]
    public partial class Risk
    {
        public int RiskID { get; set; }

        public int ProjectTeamID { get; set; }

        public DateTime TargetDate { get; set; }

        [Column("Risk")]
        [StringLength(255)]
        public string Risk1 { get; set; }

        [StringLength(255)]
        public string MitigationApproach { get; set; }

        public int ImpactID { get; set; }

        public int ProbabilityID { get; set; }

        public int RiskStatusID { get; set; }

        [StringLength(3000)]
        public string Notes { get; set; }

        public bool ShowInStatus { get; set; }

        public int? ProjectID { get; set; }

        public int RiskNumber { get; set; }

        public virtual Impact Impact { get; set; }

        public virtual Probability Probability { get; set; }

        public virtual Project Project { get; set; }

        public virtual ProjectTeam ProjectTeam { get; set; }

        public virtual RiskStatu RiskStatu { get; set; }
    }
}
