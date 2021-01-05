namespace ABC.Venture.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ConsensusRatingCategory")]
    public partial class ConsensusRatingCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConsensusRatingCategory()
        {
            ProjectConsensusRatings = new HashSet<ProjectConsensusRating>();
        }

        public int ConsensusRatingCategoryID { get; set; }

        [Column("ConsensusRatingCategory")]
        [StringLength(50)]
        public string ConsensusRatingCategory1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectConsensusRating> ProjectConsensusRatings { get; set; }
    }
}
