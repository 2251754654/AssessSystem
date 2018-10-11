using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure.DtoExtension;
using Repositorys.DataAccess.Context;
using Repositorys.DataAccess.ProfessModule;

namespace UserInfoDomain.ProfessTerritory
{
    public interface IProfessDomain
    {
        void DeleteCoreSkillToProfess(Guid professGuid, Guid coreSkillGuid);
        void DeleteTeachSkillToProfess(Guid professGuid, Guid teachSkillGuid);
        void FakeDelete(Guid professGuid);
        List<ProfessDto> Get(Expression<Func<Profess, bool>> filter = null, Func<IQueryable<Profess>, IOrderedQueryable<Profess>> orderBy = null);
        List<CoreSkillDto> GetCoreSkillByProfessGuid(Guid professGuid);
        List<TeachSkillDto> GetTeachSkillByProfessGuid(Guid professGuid);
        void InitDbContext(DBContext dBContext);
        void Insert(Profess profess);
        void RealDelete(Guid professGuid);
        void Save();
        void SetCoreSkillToProfessGuid(Guid professGuid, Guid coreSkillGuid);
        void SetTeachSkillToProfessGuid(Guid professGuid, Guid teachSkillGuid);
        void Update(Profess profess);
    }
}