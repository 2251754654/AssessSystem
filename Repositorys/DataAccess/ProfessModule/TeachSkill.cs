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
        public string Specific { get; set; }//�����˵��
        public int State { get; set; }//0,������1��ɾ��
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }//���һ�β���ʱ��
        public int VisitCount { get; set; }//���ʴ���

        public virtual ICollection<Profess_TeachSkill> Profess_TeachSkills { get; set; }
        public virtual ICollection<TeachLever> TeachLevers { get; set; }
    }
}
