namespace Repositorys.DataAccess.ProfessModule
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public  class TeachLever
    {
        public Guid Guid { get; set; }
        public string TeachLeverName { get; set; }
        public string Specific { get; set; }//�����˵��
        public int LeverNumber { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }//���һ�β���ʱ��
        public int VisitCount { get; set; }//���ʴ���
        public Guid TeachSkillGuid { get; set; }

        public virtual TeachSkill TeachSkill { get; set; }
    }
}
