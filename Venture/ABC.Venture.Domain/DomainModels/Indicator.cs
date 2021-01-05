namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Indicator")]
    public partial class Indicator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Indicator()
        {
            Projects = new HashSet<Project>();
        }

        public int IndicatorID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectIndicator { get; set; }

        public int SortNumber { get; set; }

        public int? ProjectStatusID { get; set; }

        public bool Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Projects { get; set; }

        public virtual Status Status { get; set; }
    }
}
