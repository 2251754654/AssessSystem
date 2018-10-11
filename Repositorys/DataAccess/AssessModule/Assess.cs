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

        public string AssessDigest { get; set; }//摘要

        public int VisitCount { get; set; }//访问次数

        public int State { get; set; }//0正常状态，1删除状态

        public virtual ICollection<AssessInfo> AssessInfos { get; set; }
    }
}
