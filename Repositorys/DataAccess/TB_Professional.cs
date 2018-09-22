namespace Repositorys.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class TB_Professional
    {
        public TB_Professional()
        {
            TB_MappingTeach = new HashSet<TB_MappingTeach>();
            TB_RoleContent = new HashSet<TB_RoleContent>();
            TB_MappingCore = new HashSet<TB_MappingCore>();
        }

        [Key]
        public int ProfessionalID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProfessionalName { get; set; }

        [StringLength(200)]
        public string ProfessionalDetails { get; set; }

        public int ProfessionalDelete { get; set; }

        public virtual ICollection<TB_MappingCore> TB_MappingCore { get; set; }


        public virtual ICollection<TB_MappingTeach> TB_MappingTeach { get; set; }


        public virtual ICollection<TB_RoleContent> TB_RoleContent { get; set; }
    }
}
