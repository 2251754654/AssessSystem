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

        public Guid AssessItemGuid { get; set; }//评价内容子项

        public Guid LeverGuid { get; set; }//等级编号

        public string Message { get; set; }//留言

        public int VisitCount { get; set; }//访问次数

        public virtual Assess Assess { get; set; }
    }
}
