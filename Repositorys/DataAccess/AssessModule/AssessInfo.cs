using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Repositorys.DataAccess.AssessModule
{
    public  class AssessInfo
    {
        public Guid Guid { get; set; }

        public Guid AssessGuid { get; set; }

        public Guid AssessItemGuid { get; set; }//������������

        public Guid LeverGuid { get; set; }//�ȼ����

        public string Message { get; set; }//����

        public int VisitCount { get; set; }//���ʴ���

        public virtual Assess Assess { get; set; }
    }
}
