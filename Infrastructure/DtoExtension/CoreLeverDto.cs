using Repositorys.DataAccess.ProfessModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoExtension
{
    public class CoreLeverDto
    {
        public Guid Guid { get; set; }
        public string CoreLeverName { get; set; }
        public int LeverNumber { get; set; }
        public string Specific { get; set; }//具体的说明
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }//最后一次操作时间
        public int VisitCount { get; set; }//访问次数
        public Guid CoreSkillGuid { get; set; }
    }
}
