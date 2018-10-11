namespace Repositorys.DataAccess.ProfessModule
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class CoreLever
    {
        public Guid Guid { get; set; }
        public string CoreLeverName { get; set; }
        public int LeverNumber { get; set; }
        public string Specific { get; set; }//�����˵��
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }//���һ�β���ʱ��
        public int VisitCount { get; set; }//���ʴ���
        public Guid CoreSkillGuid { get; set; }

        public virtual CoreSkill CoreSkill { get; set; }
    }
}
