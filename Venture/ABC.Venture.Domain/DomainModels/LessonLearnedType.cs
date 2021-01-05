namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LessonLearnedType")]
    public partial class LessonLearnedType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LessonLearnedType()
        {
            LessonLearneds = new HashSet<LessonLearned>();
        }

        public int LessonLearnedTypeID { get; set; }

        [Column("LessonLearnedType")]
        [Required]
        [StringLength(25)]
        public string LessonLearnedType1 { get; set; }

        public bool Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LessonLearned> LessonLearneds { get; set; }
    }
}
