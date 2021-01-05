namespace ABC.Venture.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class RiskStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RiskStatu()
        {
            Risks = new HashSet<Risk>();
        }

        [Key]
        public int RiskStatusID { get; set; }

        [Column("RiskStatus")]
        [StringLength(25)]
        public string RiskStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Risk> Risks { get; set; }
    }
}
