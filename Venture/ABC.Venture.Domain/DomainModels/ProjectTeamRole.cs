namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ProjectTeamRole")]
    public partial class ProjectTeamRole
    {
        public int ProjectTeamRoleID { get; set; }

        public int? TeamRoleID { get; set; }

        public int? ProjectTeamID { get; set; }

        public virtual ProjectTeam ProjectTeam { get; set; }

        public virtual TeamRole TeamRole { get; set; }
    }
}
