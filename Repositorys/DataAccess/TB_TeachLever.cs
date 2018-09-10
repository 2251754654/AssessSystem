namespace Repositorys.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_TeachLever
    {
        [Key]
        public int TeachLeverID { get; set; }

        public int TeachLeverNum { get; set; }

        [Required]
        [StringLength(100)]
        public string TeachLeverDetails { get; set; }

        public int TeachSkillsID { get; set; }

        public virtual TB_TechSkills TB_TechSkills { get; set; }
    }
}
