namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("LessonLearned")]
    public partial class LessonLearned
    {
        public int LessonLearnedID { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Recommendation { get; set; }

        public int? LessonLearnedTypeID { get; set; }

        public int? ProjectID { get; set; }

        public virtual LessonLearnedType LessonLearnedType { get; set; }

        public virtual Project Project { get; set; }
    }
}
