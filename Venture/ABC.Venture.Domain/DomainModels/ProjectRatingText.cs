namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ProjectRatingText")]
    public partial class ProjectRatingText
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectRatingText()
        {
            ProjectRatingHistories = new HashSet<ProjectRatingHistory>();
        }

        public int ProjectRatingTextID { get; set; }

        [Required]
        [StringLength(1)]
        public string ProjectRatingCode { get; set; }

        [Column("ProjectRatingText")]
        [Required]
        [StringLength(15)]
        public string ProjectRatingText1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectRatingHistory> ProjectRatingHistories { get; set; }
    }
}
