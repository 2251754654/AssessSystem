namespace Repositorys.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_Professional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Professional()
        {
            TB_MappingCore = new HashSet<TB_MappingCore>();
            TB_MappingTeach = new HashSet<TB_MappingTeach>();
            TB_RoleContent = new HashSet<TB_RoleContent>();
        }

        [Key]
        public int ProfessionalID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProfessionalName { get; set; }

        [StringLength(200)]
        public string ProfessionalDetails { get; set; }

        public int ProfessionalDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_MappingCore> TB_MappingCore { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_MappingTeach> TB_MappingTeach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_RoleContent> TB_RoleContent { get; set; }
    }
}
