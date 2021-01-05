namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ProjectRating")]
    public partial class ProjectRating
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectRating()
        {
            ProjectRatingHistories = new HashSet<ProjectRatingHistory>();
        }

        public int ProjectRatingID { get; set; }

        [Column("ProjectRating")]
        [Required]
        [StringLength(25)]
        public string ProjectRating1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectRatingHistory> ProjectRatingHistories { get; set; }
    }
}
