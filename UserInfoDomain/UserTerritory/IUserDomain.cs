using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure.Dto;
using Infrastructure.DtoExtension;
using Repositorys.DataAccess.Context;
using Repositorys.DataAccess.UserModule;

namespace UserInfoDomain.UserTerritory
{
    public interface IUserDomain
    {
        void DeleteRoleToUser(Guid userGuid, Guid roleGuid);
        void FakeDelete(Guid userGuid);
        List<UserDto> Get(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProp = null);
        UserDto GetByID(Guid userGuid);
        List<RoleDto> GetRoleByUserGuid(Guid userGuid);
        void InitDbContext(DBContext dBContext);
        void Insert(User user);
        void RealDelete(Guid userGuid);
        void Save();
        void SetRoleToUser(Guid userGuid, Guid roleGuid);
        void Update(User user);
    }
}