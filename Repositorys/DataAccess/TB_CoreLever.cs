namespace Repositorys.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class TB_CoreLever
    {
        [Key]
        public int CoreLeverID { get; set; }

        public int CoreLeverNum { get; set; }

        [Required]
        [StringLength(100)]
        public string CoreLeverDetails { get; set; }

        public int CoreSkillsID { get; set; }

        public int CoreLeverDelete { get; set; }

        public virtual TB_CoreSkills TB_CoreSkills { get; set; }
    }
}
