namespace Repositorys.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_TechSkills
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_TechSkills()
        {
            TB_MappingTeach = new HashSet<TB_MappingTeach>();
            TB_TeachLever = new HashSet<TB_TeachLever>();
        }

        [Key]
        public int TeachSkillsID { get; set; }

        [Required]
        [StringLength(50)]
        public string TeachSkillsName { get; set; }

        [Required]
        [StringLength(100)]
        public string TeachAkillsDetails { get; set; }

        [Required]
        [StringLength(50)]
        public string TeachAkillsGUID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_MappingTeach> TB_MappingTeach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_TeachLever> TB_TeachLever { get; set; }
    }
}
