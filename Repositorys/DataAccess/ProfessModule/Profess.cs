namespace Repositorys.DataAccess.ProfessModule
{
    using Repositorys.DataAccess.MappingModule;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class Profess
    {
        public Guid Guid { get; set; }
        public string ProfessName { get; set; }
        public string Specific { get; set; }//具体的说明
        public int State { get; set; }//0,正常，1，删除
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }//最后一次操作时间
        public int VisitCount { get; set; }//访问次数

        public virtual ICollection<Role_Profess> Role_Professs { get; set; }
        public virtual ICollection<Profess_CoreSkill> Profess_CoreSkills { get; set; }
        public virtual ICollection<Profess_TeachSkill> Profess_TeachSkills { get; set; }
    }
}
