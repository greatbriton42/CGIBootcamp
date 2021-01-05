namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("TeamRole")]
    public partial class TeamRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TeamRole()
        {
            ProjectTeamRoles = new HashSet<ProjectTeamRole>();
        }

        public int TeamRoleID { get; set; }

        [Column("TeamRole")]
        [Required]
        [StringLength(50)]
        public string TeamRole1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectTeamRole> ProjectTeamRoles { get; set; }
    }
}
