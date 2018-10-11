using Infrastructure.DtoExtension;
using Repositorys.DataAccess.ProfessModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityExtension
{
    public static class CoreSkillExtention
    {
        public static CoreSkillDto ToDto(this CoreSkill coreSkill)
        {
            var coreSkillDto = new CoreSkillDto()
            {
                Guid = coreSkill.Guid,
                CoreSkillName = coreSkill.CoreSkillName,
                CreateTime = coreSkill.CreateTime,
                UpdateTime = coreSkill.UpdateTime,
                Specific = coreSkill.Specific,
                State = coreSkill.State,
                VisitCount = coreSkill.VisitCount,
            };
                coreSkillDto.CoreLevers = new List<CoreLeverDto>();
                foreach (var item in coreSkill.CoreLevers)
                {
                    coreSkillDto.CoreLevers.Add(item.ToDto());
                }
            return coreSkillDto;
        }

        public static CoreSkill ToUpdateEntity(this CoreSkill coreSkill, CoreSkill detachedCoreSkill)
        {
            coreSkill.CoreSkillName = detachedCoreSkill.CoreSkillName;
            coreSkill.Specific = detachedCoreSkill.Specific;
            coreSkill.UpdateTime = DateTime.Now;
            coreSkill.VisitCount = coreSkill.VisitCount + 1;
            return coreSkill;
        }

        public static CoreSkill ToInsertEntity(this CoreSkill coreSkill)
        {
            coreSkill.Guid = Guid.NewGuid();
            coreSkill.CreateTime = DateTime.Now;
            coreSkill.UpdateTime = DateTime.Now;
            coreSkill.VisitCount = 0;
            coreSkill.State = 0;
            return coreSkill;
        }
    }
}
