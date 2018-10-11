using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorys.DataAccess.MappingModule;
using Repositorys.DataAccess.ProfessModule;

namespace Infrastructure.DtoExtension
{
    public class ProfessDto
    {
        public Guid Guid { get; set; }
        public string ProfessName { get; set; }
        public string Specific { get; set; }//具体的说明
        public int State { get; set; }//0,正常，1，删除
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }//最后一次操作时间
        public int VisitCount { get; set; }//访问次数

        public virtual ICollection<Role_Profess> Role_Professs { get; set; }
        public virtual ICollection<Profess_CoreSkill> Profess_CoreSkills { get; set; }
        public virtual ICollection<Profess_TeachSkill> Profess_TeachSkills { get; set; }

        public Profess ToEntity()
        {
            return new Profess
            {
                Guid = Guid != null ? Guid : System.Guid.NewGuid(),
                ProfessName = ProfessName,
                Specific = Specific,
                CreateTime = DateTime.Now,
                State = 1,
                UpdateTime = DateTime.Now,
                VisitCount = 11
            };
        }
    }
}
