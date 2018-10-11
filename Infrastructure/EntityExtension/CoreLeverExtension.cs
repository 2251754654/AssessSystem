using Infrastructure.DtoExtension;
using Repositorys.DataAccess.ProfessModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityExtension
{
   public static class CoreLeverExtension
    {
        public static CoreLeverDto ToDto(this CoreLever coreLever)
        {
            return new CoreLeverDto() {
                Guid = coreLever.Guid,
                CoreLeverName = coreLever.CoreLeverName,
                CreateTime = coreLever.CreateTime,
                UpdateTime = coreLever.UpdateTime,
                LeverNumber = coreLever.LeverNumber,
                Specific = coreLever.Specific,
                VisitCount = coreLever.VisitCount,
                CoreSkillGuid = coreLever.CoreSkillGuid,
            };

        }
        
        public static CoreLever ToInsertEntity(this CoreLever coreLever)
        {
            coreLever.Guid = Guid.NewGuid();
            coreLever. CreateTime = DateTime.Now;
            coreLever. UpdateTime = DateTime.Now;
            coreLever. VisitCount = 0;
            return coreLever;

        }
    }
}
