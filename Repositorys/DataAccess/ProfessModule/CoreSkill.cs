namespace Repositorys.DataAccess.ProfessModule
{
    using Repositorys.DataAccess.MappingModule;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class CoreSkill
    {
        public Guid Guid { get; set; }
        public string CoreSkillName { get; set; }
        public string Specific { get; set; }//�����˵��
        public int State { get; set; }//0,������1��ɾ��
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }//���һ�β���ʱ��
        public int VisitCount { get; set; }//���ʴ���

        public virtual ICollection<Profess_CoreSkill> Profess_CoreSkills { get; set; }
        public virtual ICollection<CoreLever> CoreLevers { get; set; }

    }
}
