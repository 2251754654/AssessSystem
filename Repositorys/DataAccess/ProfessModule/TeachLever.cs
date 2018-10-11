namespace Repositorys.DataAccess.ProfessModule
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public  class TeachLever
    {
        public Guid Guid { get; set; }
        public string TeachLeverName { get; set; }
        public string Specific { get; set; }//具体的说明
        public int LeverNumber { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }//最后一次操作时间
        public int VisitCount { get; set; }//访问次数
        public Guid TeachSkillGuid { get; set; }

        public virtual TeachSkill TeachSkill { get; set; }
    }
}
