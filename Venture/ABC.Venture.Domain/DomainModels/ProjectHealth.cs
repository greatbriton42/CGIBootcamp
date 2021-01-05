namespace ABC.Venture.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ProjectHealth")]
    public partial class ProjectHealth
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectHealth()
        {
            ProjectProjectHealths = new HashSet<ProjectProjectHealth>();
        }

        public int ProjectHealthID { get; set; }

        [Column("ProjectHealth")]
        [Required]
        [StringLength(25)]
        public string ProjectHealth1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectProjectHealth> ProjectProjectHealths { get; set; }
    }
}
