using Infrastructure.DtoExtension;
using Repositorys.DataAccess.ProfessModule;
using Repositorys.DataAccess.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityExtension
{
    public static class ProfessExtension
    {
        public static ProfessDto ToDto(this Profess profess )
        {
            return new ProfessDto() {
                Guid = profess.Guid,
                ProfessName = profess.ProfessName,
                Specific = profess.Specific,
                CreateTime = profess.CreateTime,
                State = profess.State,
                UpdateTime = profess.UpdateTime,
                VisitCount = profess.VisitCount,
            };
        }

        public static Profess ToInsertEntity(this Profess profess)
        {
            profess.Guid = Guid.NewGuid();
            profess.CreateTime = DateTime.Now;
            profess.State = 0;
            profess.UpdateTime = DateTime.Now;
            profess.VisitCount = 0;
            return profess;
        }

        public static Profess ToUpdateEntity(this Profess profess,Profess newProfess)
        {
            profess.ProfessName = newProfess.ProfessName;
            profess.Specific = newProfess.Specific;
            profess.VisitCount = profess.VisitCount + 1;
            profess.UpdateTime = DateTime.Now;
            return profess;
        }
    }
}
