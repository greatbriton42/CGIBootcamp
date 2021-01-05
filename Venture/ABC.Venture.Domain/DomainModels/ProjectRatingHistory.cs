namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ProjectRatingHistory")]
    public partial class ProjectRatingHistory
    {
        public int ProjectRatingHistoryID { get; set; }

        public int? ProjectRatingTextId { get; set; }

        public int? ProjectID { get; set; }

        public int? ProjectRatingID { get; set; }

        public DateTime? ProjectRatingDate { get; set; }

        public virtual Project Project { get; set; }

        public virtual ProjectRating ProjectRating { get; set; }

        public virtual ProjectRatingText ProjectRatingText { get; set; }
    }
}
