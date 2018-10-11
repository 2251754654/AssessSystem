using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure.DtoExtension;
using Repositorys.DataAccess.Context;
using Repositorys.DataAccess.UserModule;

namespace UserInfoDomain.UserTerritory
{
    public interface IRoleDomain
    {
        void DeleteMenuToRole(Guid roleGuid, Guid menuGuid);
        void DeleteProfessToRole(Guid roleGuid, Guid professGuid);
        List<RoleDto> Get(Expression<Func<Role, bool>> filter = null, Func<IQueryable<Role>, IOrderedQueryable<Role>> orderBy = null, string includeProperties = null, int? page = null, int? number = null);
        List<MenuDto> GetMenuByRoleGuid(Guid roleGuid);
        List<ProfessDto> GetProfessByRoleGuid(Guid roleGuid);
        void InitDbContext(DBContext dBContext);
        void Insert(Role role);
        void RealDelete(Guid roleGuid);
        void Save();
        void SetMenuToRole(Guid roleGuid, Guid menuGuid);
        void SetProfessToRole(Guid roleGuid, Guid professGuid);
        void Update(Role role);
    }
}