using Infrastructure.Dto;
using Infrastructure.DtoExtension;
using Infrastructure.EntityExtension;
using Infrastructure.Exception;
using Repositorys.DataAccess.Context;
using Repositorys.DataAccess.MappingModule;
using Repositorys.DataAccess.UserModule;
using Repositorys.Repositroy.Specific;
using Repositorys.Repositroy.Specific.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UserInfoDomain.UserTerritory
{
    /// <summary>
    /// 用户角色权限管理
    /// </summary>
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepositroy userRepositroy = UnityConfig.Container.Resolve(typeof(IUserRepositroy), null) as IUserRepositroy;
        private readonly IUser_RoleRepositroy user_RoleRepositroy = UnityConfig.Container.Resolve(typeof(IUser_RoleRepositroy), null) as IUser_RoleRepositroy;

        public void InitDbContext(DBContext dBContext)
        {
            userRepositroy.InitDbContext(dBContext);
            user_RoleRepositroy.InitDbContext(dBContext);
        }

        public List<UserDto> Get(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProp = null)
        {
            var userList = userRepositroy.Get(filter, orderBy, includeProp).ToList();
            var userDtoList = new List<UserDto>();
            foreach (var userListItem in userList)
            {
                userDtoList.Add(userListItem.ToDto());
            }
            return userDtoList;

        }

        public UserDto GetByID(Guid userGuid)
        {
            if (userGuid != null)
            {
                return userRepositroy.GetByID(userGuid).ToDto();
            }
            throw new Exception("<public UserDto GetByID(Guid userGuid)> hava null !");
        }

        public void Insert(User user)
        {
            if (user == null)
            {
                throw new EntityIsNullException("参数为空！");
            }
            userRepositroy.Insert(user.ToInsertEntity());
        }

        public void Update(User user)
        {
            if (user == null)
            {
                throw new EntityIsNullException("参数为空！");
            }
            User userAndInfo = null;
            if (user.UserInfo != null)
            {
                userAndInfo = userRepositroy.Get(o => o.Guid == user.Guid, null, "UserInfo").FirstOrDefault();

            }
            else
            {
                userAndInfo = userRepositroy.Get(o => o.Guid == user.Guid).FirstOrDefault();
            }
            userRepositroy.Update(userAndInfo.ToUpdateEntity(user));
        }

        public void RealDelete(Guid userGuid)
        {
            userRepositroy.Delete(userGuid);
        }

        public void FakeDelete(Guid userGuid)
        {
            var user = userRepositroy.GetByID(userGuid);
            if (user != null)
            {
                user.State = 1;
                userRepositroy.Update(user);
            }
        }

        public void Save()
        {
            userRepositroy.Save();
        }


        public List<RoleDto> GetRoleByUserGuid(Guid userGuid)
        {
            if (userGuid == null)
            {
                throw new EntityIsNullException("<public void GetRoleByUserGuid(User user)> User is null !");
            }
            var user_RoleList = user_RoleRepositroy.Get(o => o.UserGuid == userGuid, null, "Role");
            if (user_RoleList != null)
            {
                var roleDtoList = new List<RoleDto>();
                foreach (var item in user_RoleList)
                {
                    roleDtoList.Add(item.Role.ToDto());
                }
                return roleDtoList;
            }
            return null;
        }

        public void SetRoleToUser(Guid userGuid, Guid roleGuid)
        {
            if (userGuid == null || roleGuid == null)
            {
                throw new EntityIsNullException("<  public void SetRoleToUser(Guid userGuid,Guid roleGuid)> have null !");
            }


            if (user_RoleRepositroy.Get(o => o.UserGuid == userGuid && o.RoleGuid == roleGuid) != null)
            {
                var userRole = new User_Role();
                userRole.UserGuid = userGuid;
                userRole.RoleGuid = roleGuid;
                user_RoleRepositroy.Insert(userRole);
            }
            throw new EntityRepeatException("<if (user_RoleRepositroy.Get(o => o.UserGuid == userGuid && o.RoleGuid == roleGuid) != null)> ");
        }

        public void DeleteRoleToUser(Guid userGuid, Guid roleGuid)
        {
            if (userGuid == null || roleGuid == null)
            {
                throw new EntityIsNullException("<  public void SetRoleToUser(Guid userGuid,Guid roleGuid)> have null !");
            }
            var userRole = user_RoleRepositroy.Get(o => o.UserGuid == userGuid && o.RoleGuid == roleGuid).FirstOrDefault();
            if (userRole != null)
            {
                user_RoleRepositroy.Delete(userRole);
            }
        }
    }
}
