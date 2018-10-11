namespace Repositorys.DataAccess.ProfessModule
{
    using Repositorys.DataAccess.MappingModule;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public  class TeachSkill
    {
        public Guid Guid { get; set; }
        public string TeachSkillName { get; set; }
        public string Specific { get; set; }//具体的说明
        public int State { get; set; }//0,正常，1，删除
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }//最后一次操作时间
        public int VisitCount { get; set; }//访问次数

        public virtual ICollection<Profess_TeachSkill> Profess_TeachSkills { get; set; }
        public virtual ICollection<TeachLever> TeachLevers { get; set; }
    }
}
