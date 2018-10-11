using Infrastructure.DtoExtension;
using Repositorys.DataAccess.ProfessModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityExtension
{
     public static class TeachSkillExtension
    {
        public static TeachSkillDto ToDto(this TeachSkill teachSkill )
        {
            var teachSkillDto = new TeachSkillDto()
            {
                Guid = teachSkill.Guid,
                TeachSkillName = teachSkill.TeachSkillName,
                CreateTime = teachSkill.CreateTime,
                UpdateTime = teachSkill.UpdateTime,
                Specific = teachSkill.Specific,
                State = teachSkill.State,
                VisitCount = teachSkill.VisitCount,
            };
            teachSkillDto.TeachLevers = new List<TeachLeverDto>();
            foreach (var item in teachSkill.TeachLevers)
            {
                teachSkillDto.TeachLevers.Add(item.ToDto());
            }
            return teachSkillDto;
        }

        public static TeachSkill ToUpdateEntity(this TeachSkill teachSkill, TeachSkill detachedTeachSkill)
        {
            teachSkill.TeachSkillName = detachedTeachSkill.TeachSkillName;
            teachSkill.Specific = detachedTeachSkill.Specific;
            teachSkill.UpdateTime = DateTime.Now;
            teachSkill.VisitCount = teachSkill.VisitCount + 1;
            return teachSkill;
        }

        public static TeachSkill ToInsertEntity(this TeachSkill  teachSkill)
        {
            teachSkill.Guid = Guid.NewGuid();
            teachSkill.CreateTime = DateTime.Now;
            teachSkill.UpdateTime = DateTime.Now;
            teachSkill.VisitCount = 0;
            teachSkill.State = 0;
            return teachSkill;
        }
    }
}
