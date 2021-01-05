namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FinancialInformation")]
    public partial class FinancialInformation
    {
        public int FinancialInformationID { get; set; }

        [Column(TypeName = "money")]
        public decimal? BaselineCapital { get; set; }

        [Column(TypeName = "money")]
        public decimal? ApprovedCapital { get; set; }

        [Column(TypeName = "money")]
        public decimal? CapitalSpent { get; set; }

        [Column(TypeName = "money")]
        public decimal? PendingCapital { get; set; }

        [Column(TypeName = "money")]
        public decimal? BaselineExpense { get; set; }

        [Column(TypeName = "money")]
        public decimal? ApprovedExpense { get; set; }

        [Column(TypeName = "money")]
        public decimal? ExpenseSpent { get; set; }

        [Column(TypeName = "money")]
        public decimal? PendingExpense { get; set; }

        [Column(TypeName = "money")]
        public decimal? BaselineCap { get; set; }

        [Column(TypeName = "money")]
        public decimal? ApprovedCap { get; set; }

        [Column(TypeName = "money")]
        public decimal? CapSpent { get; set; }

        [Column(TypeName = "money")]
        public decimal? CumulativeNetIncome { get; set; }

        [Column(TypeName = "money")]
        public decimal? CumalativeNEIImpact { get; set; }

        [StringLength(25)]
        public string CostCenter { get; set; }

        public int ProjectID { get; set; }

        public bool Active { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual Project Project { get; set; }
    }
}
