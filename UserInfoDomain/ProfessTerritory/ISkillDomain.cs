using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure.DtoExtension;
using Repositorys.DataAccess.Context;
using Repositorys.DataAccess.ProfessModule;

namespace UserInfoDomain.ProfessTerritory
{
    public interface ISkillDomain
    {
        void DeleteCoreLeverToCoreSkill(CoreLever coreLever);
        void DeleteTeachLeverToTeachsSkill(TeachLever teachLever);
        void FakeDeleteToCore(Guid coreSkillGuid);
        void FakeDeleteToTeach(Guid teachSkillGuid);
        List<CoreSkillDto> GetCore(Expression<Func<CoreSkill, bool>> filter = null, Func<IQueryable<CoreSkill>, IOrderedQueryable<CoreSkill>> orderBy = null,string includeProp = null);
        List<CoreLeverDto> GetCoreLeverByCoreSkillGuid(Guid coreSkillGuid, Func<IQueryable<CoreSkill>, IOrderedQueryable<CoreSkill>> orderBy = null);
        List<TeachSkillDto> GetTeach(Expression<Func<TeachSkill, bool>> filter = null, Func<IQueryable<TeachSkill>, IOrderedQueryable<TeachSkill>> orderBy = null,string includeProp=null);
        List<TeachLeverDto> GetTeachLeverByTeachSkillGuid(Guid teachSkillGuid, Func<IQueryable<TeachLever>, IOrderedQueryable<TeachLever>> orderBy = null);
        void InitDbContext(DBContext dBContext);
        void Insert(CoreSkill coreSkill);
        void Insert(TeachSkill teachSkill);
        void RealDeleteToCore(Guid coreSkillGuid);
        void RealDeleteToTeach(Guid teachSkillGuid);
        void Save();
        void SetCoreLeverToCoreSkill(CoreLever coreLever);
        void SetTeachLeverToTeachSkill(TeachLever teachLever);
        void Update(CoreSkill coreSkill);
        void Update(TeachSkill teachSkill);
    }
}