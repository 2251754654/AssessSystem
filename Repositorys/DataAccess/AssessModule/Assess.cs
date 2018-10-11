using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace Repositorys.DataAccess.AssessModule
{
    public  class Assess
    {
        
        public Guid Guid { get; set; }
        
        public Guid AssessUserGuid { get; set; }
        
        public Guid ByAssessUserGuid { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public string AssessDigest { get; set; }//ժҪ

        public int VisitCount { get; set; }//���ʴ���

        public int State { get; set; }//0����״̬��1ɾ��״̬

        public virtual ICollection<AssessInfo> AssessInfos { get; set; }
    }
}
