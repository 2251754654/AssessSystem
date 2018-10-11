using Infrastructure.DtoExtension;
using Repositorys.DataAccess.ProfessModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityExtension
{
   public static  class TeachLeverExtension
    {
        public  static TeachLeverDto ToDto(this TeachLever teachLever)
        {

            return new TeachLeverDto() {
                Guid = teachLever.Guid,
                CreateTime = teachLever.CreateTime,
                LeverNumber = teachLever.LeverNumber,
                Specific = teachLever.Specific,
                TeachLeverName = teachLever.TeachLeverName,
                TeachSkillGuid = teachLever.TeachSkillGuid,
                VisitCount = teachLever.VisitCount,
            };
        }

        public static TeachLever ToInsertEntity(this TeachLever  teachLever)
        {
            teachLever.Guid = Guid.NewGuid();
            teachLever.CreateTime = DateTime.Now;
            teachLever.UpdateTime = DateTime.Now;
            teachLever.VisitCount = 0;
            return teachLever;

        }
    }
}
