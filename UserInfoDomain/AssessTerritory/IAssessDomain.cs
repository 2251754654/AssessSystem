using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure.Dto;
using Repositorys.DataAccess.AssessModule;
using Repositorys.DataAccess.Context;

namespace Domains.AssessTerritory
{
    public interface IAssessDomain
    {
        IEnumerable<AssessDto> Get(Expression<Func<Assess, bool>> filter = null, Func<IQueryable<Assess>, IOrderedQueryable<Assess>> orderBy = null);
        IEnumerable<AssessInfoDto> GetByID(Guid assessGuid, Expression<Func<AssessInfo, bool>> filter = null);
        void Insert(Assess assess);
        void Delete(Guid assessGuid, int deleteTag);
        void InitDbContext(DBContext dBContext);
    }
}