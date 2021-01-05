namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ProjectProjectHealth")]
    public partial class ProjectProjectHealth
    {
        public int ProjectProjectHealthID { get; set; }

        public int ProjectHealthID { get; set; }

        public int ProjectID { get; set; }

        public DateTime ProjectHealthDate { get; set; }

        public virtual Project Project { get; set; }

        public virtual ProjectHealth ProjectHealth { get; set; }
    }
}
