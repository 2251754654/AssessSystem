namespace Repositorys.DataAccess.MappingModule
{
    using Repositorys.DataAccess.ProfessModule;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class Profess_CoreSkill
    {
        public Guid Guid { get; set; }
        public Guid ProfessGuid { get; set; }
        public Guid CoreSkillGuid { get; set; }

        public virtual Profess Profess { get; set; }
        public virtual CoreSkill CoreSkill { get; set; }
    }
}
