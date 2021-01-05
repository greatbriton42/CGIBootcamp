namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ProjectConsensusRating")]
    public partial class ProjectConsensusRating
    {
        public int ProjectConsensusRatingID { get; set; }

        public int RatingCategoryID { get; set; }

        public int ProjectID { get; set; }

        public bool VeryDissatisfied { get; set; }

        public bool Dissatisfied { get; set; }

        public bool Neutral { get; set; }

        public bool Satisfied { get; set; }

        public bool VerySatisfied { get; set; }

        public virtual ConsensusRatingCategory ConsensusRatingCategory { get; set; }

        public virtual Project Project { get; set; }
    }
}
