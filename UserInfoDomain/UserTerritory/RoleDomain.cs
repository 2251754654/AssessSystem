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
    public class RoleDomain : IRoleDomain
    {
        private readonly IRoleRepositroy roleRepositroy = UnityConfig.Container.Resolve(typeof(IRoleRepositroy), null) as IRoleRepositroy;
        private readonly IRole_MenuRepositroy  role_MenuRepositroy = UnityConfig.Container.Resolve(typeof(IRole_MenuRepositroy), null) as IRole_MenuRepositroy;
        private readonly IRole_ProfessRepositroy  role_ProfessRepositroy = UnityConfig.Container.Resolve(typeof(IRole_ProfessRepositroy), null) as IRole_ProfessRepositroy;

        public void InitDbContext(DBContext dBContext)
        {
            roleRepositroy.InitDbContext(dBContext);
            role_MenuRepositroy.InitDbContext(dBContext);
            role_ProfessRepositroy.InitDbContext(dBContext);
            this.dbContext = dBContext;
        }
        private DBContext dbContext;
        public List<RoleDto> Get(Expression<Func<Role, bool>> filter = null, Func<IQueryable<Role>, IOrderedQueryable<Role>> orderBy = null, string includeProperties = null,int? page=null,int?number = null)
        {
            var roleList = roleRepositroy.Get(filter, orderBy, includeProperties, page,number);
            if (roleList == null)
            {
                return null;
            }
            var roleDtoList = new List<RoleDto>();
            foreach (var item in roleList)
            {
                roleDtoList.Add(item.ToDto());
            }
            return roleDtoList;
        }

        public void Insert(Role role)
        {
            if (role == null)
            {
                throw new EntityIsNullException("<public void Insert(Role role)> role is null !");
            }
            var oldRole = roleRepositroy.Get(o=>o.RoleName == role.RoleName).FirstOrDefault();
            if (oldRole == null)
            {
                roleRepositroy.Insert(role.ToInsertEntity());
                return;
            }
            throw new EntityRepeatException("插入重复！");
        }

        public void Save()
        {
            roleRepositroy.Save();
        }

        public void Update(Role role)
        {
            if (role == null)
            {
                throw new EntityIsNullException("Update Entity is null !");
            }
            var oldRole = roleRepositroy.GetByID(role.Guid);
            if (oldRole == null)
            {
                throw new EntityIsNullException("Update Entity is null !");
            }
            if (role.RoleName == null || role.RoleName.Equals(""))
            {
                throw new EntityIsNullException("EntityName is null !");
            }
            roleRepositroy.Update(oldRole.ToUpdateEntity(role));
        }

        public void RealDelete(Guid roleGuid)
        {
            if (roleGuid == null)
            {
                throw new EntityIsNullException(" RoleGuid is null !");
            }
            var user_RoleRepositroy = UnityConfig.Container.Resolve(typeof(IUser_RoleRepositroy), null) as IUser_RoleRepositroy;
            user_RoleRepositroy.InitDbContext(dbContext);
            var user_Role = user_RoleRepositroy.Get(o => o.RoleGuid == roleGuid).ToList();
            var roleMenu = role_MenuRepositroy.Get(o=>o.RoleGuid == roleGuid).ToList();
            var roleProfess = role_ProfessRepositroy.Get(o => o.RoleGuid == roleGuid).ToList();
            var oldRole = roleRepositroy.Get(o => o.Guid == roleGuid, null, "User_Roles,Role_Professs,User_Roles").FirstOrDefault();
            if (oldRole != null)
            {
                user_RoleRepositroy.Delete(user_Role);
                role_ProfessRepositroy.Delete(roleProfess);
                role_MenuRepositroy.Delete(roleMenu);
                roleRepositroy.Delete(roleGuid);
            }
        }

        public void SetProfessToRole(Guid roleGuid,Guid professGuid)
        {
            if (roleGuid == null || professGuid==null)
            {
                throw new EntityIsNullException("roleGuid or professGuid is null !");
            }
            if (role_ProfessRepositroy.Get(o=>o.RoleGuid == roleGuid && o.ProfessGuid == professGuid)!= null)
            {
                throw new EntityRepeatException("Entity is repeat !");
            }
            role_ProfessRepositroy.Insert(new Role_Profess() {
                Guid = Guid.NewGuid(),
                RoleGuid = roleGuid,
                ProfessGuid = professGuid,
            });
            
        }

        public List<ProfessDto> GetProfessByRoleGuid(Guid roleGuid)
        {
            if (roleGuid == null)
            {
                throw new EntityIsNullException("RoleGuid is null !");
            }
            var role_professList = role_ProfessRepositroy.Get(o => o.RoleGuid == roleGuid, null, "Profess");
            if (role_professList != null)
            {
                var professDtoList = new List<ProfessDto>();
                foreach (var item in role_professList)
                {
                    professDtoList.Add(item.Profess.ToDto());
                }
                return professDtoList;
            }
            return null;
        }

        public void DeleteProfessToRole(Guid roleGuid, Guid professGuid)
        {
            if (roleGuid == null || professGuid == null)
            {
                throw new EntityIsNullException("RoleGuid Or ProfessGuid hava null !");
            }
            var roleProfess = role_ProfessRepositroy.Get(o=>o.RoleGuid == roleGuid && o.ProfessGuid == professGuid).FirstOrDefault();
            if (roleProfess != null)
            {
                role_ProfessRepositroy.Delete(roleProfess);
            }
        }

        public void SetMenuToRole(Guid roleGuid, Guid menuGuid)
        {
            if (roleGuid == null || menuGuid == null)
            {
                throw new EntityIsNullException("roleGuid or menuGuid is null !");
            }
            if (role_MenuRepositroy.Get(o => o.RoleGuid == roleGuid && o.MenuGuid == menuGuid) != null)
            {
                throw new EntityRepeatException("Entity is repeat !");
            }
            role_MenuRepositroy.Insert(new Role_Menu()
            {
                Guid = Guid.NewGuid(),
                RoleGuid = roleGuid,
                MenuGuid = menuGuid,
            });

        }

        public List<MenuDto> GetMenuByRoleGuid(Guid roleGuid)
        {
            var roleMenuList = role_MenuRepositroy.Get(o=>o.RoleGuid == roleGuid,null,"Menu");
            if (roleMenuList != null)
            {
                var menuDtoList = new List<MenuDto>();
                foreach (var item in roleMenuList)
                {
                    menuDtoList.Add(item.Menu.ToDto());
                }
                return menuDtoList;
            }
            return null;
        }

        public void DeleteMenuToRole(Guid roleGuid, Guid menuGuid)
        {
            if (roleGuid == null || menuGuid == null)
            {
                throw new EntityIsNullException("RoleGuid Or menuGuid hava null !");
            }
            var roleMenu = role_MenuRepositroy.Get(o => o.RoleGuid == roleGuid && o.MenuGuid == menuGuid).FirstOrDefault();
            if (roleMenu != null)
            {
                role_ProfessRepositroy.Delete(roleMenu.Guid);
            }
        }



    }
}
