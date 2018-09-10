namespace Repositorys.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_CoreSkills
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_CoreSkills()
        {
            TB_CoreLever = new HashSet<TB_CoreLever>();
            TB_MappingCore = new HashSet<TB_MappingCore>();
        }

        [Key]
        public int CoreSkillsID { get; set; }

        [Required]
        [StringLength(50)]
        public string CoreSkillsName { get; set; }

        [Required]
        [StringLength(100)]
        public string CoreSkillsDetails { get; set; }

        [Required]
        [StringLength(50)]
        public string CoreSkillsGUID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_CoreLever> TB_CoreLever { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_MappingCore> TB_MappingCore { get; set; }
    }
}
