namespace Repositorys.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class TB_MappingCore
    {
        [Key]
        public int MappingID { get; set; }

        public int ProfessionalID { get; set; }

        public int CoreSkillsID { get; set; }

        public virtual TB_CoreSkills TB_CoreSkills { get; set; }

        public virtual TB_Professional TB_Professional { get; set; }
    }
}
