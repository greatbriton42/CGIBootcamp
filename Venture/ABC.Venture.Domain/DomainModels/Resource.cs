namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Resource")]
    public partial class Resource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resource()
        {
            Departments = new HashSet<Department>();
            ProjectTeams = new HashSet<ProjectTeam>();
        }

        public int ResourceID { get; set; }

        [Column("Resource")]
        [Required]
        [StringLength(50)]
        public string Resource1 { get; set; }

        [Required]
        [StringLength(75)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(25)]
        public string UserID { get; set; }

        public bool Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Departments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectTeam> ProjectTeams { get; set; }
    }
}
