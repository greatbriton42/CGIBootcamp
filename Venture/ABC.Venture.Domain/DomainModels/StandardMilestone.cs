namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("StandardMilestone")]
    public partial class StandardMilestone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StandardMilestone()
        {
            ProjectStandardMilestones = new HashSet<ProjectStandardMilestone>();
        }

        public int StandardMilestoneID { get; set; }

        [Column("StandardMilestone")]
        [StringLength(50)]
        public string StandardMilestone1 { get; set; }

        public int? BaselinePoints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectStandardMilestone> ProjectStandardMilestones { get; set; }
    }
}
