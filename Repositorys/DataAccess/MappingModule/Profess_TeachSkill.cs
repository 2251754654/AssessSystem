namespace Repositorys.DataAccess.MappingModule
{
    using Repositorys.DataAccess.ProfessModule;
    using System;
    using System.ComponentModel.DataAnnotations;

    public  class Profess_TeachSkill
    {
        public Guid Guid { get; set; }
        public Guid ProfessGuid { get; set; }
        public Guid TeachSkillGuid { get; set; }

        public virtual Profess Profess { get; set; }
        public virtual TeachSkill TeachSkill { get; set; }
    }
}
