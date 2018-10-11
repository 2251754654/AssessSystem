

using Infrastructure.DtoExtension;
using Infrastructure.EntityExtension;
using Infrastructure.Exception;
using Repositorys.DataAccess.Context;
using Repositorys.DataAccess.UserModule;
using Repositorys.Repositroy.Specific;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UserInfoDomain.UserTerritory
{
    public class MenuDomain
    {
        private readonly IMenuRepositroy menuRepositroy = UnityConfig.Container.Resolve(typeof(IMenuRepositroy), null) as IMenuRepositroy;


        public void InitDbContext(DBContext dBContext)
        {
            menuRepositroy.InitDbContext(dBContext);
        }

        public List<MenuDto> Get()
        {
            var menuList = menuRepositroy.Get();
            if (menuList != null)
            {
                var menuDtoList = new List<MenuDto>();
                foreach (var item in menuList)
                {
                    menuDtoList.Add(item.ToDto());
                }
                return menuDtoList;
            }
            return null;
        }

        public void Update(Menu menu)
        {
            if (menu == null)
            {
                throw new EntityIsNullException("Menu hava null");
            }
            var oldMenu = menuRepositroy.GetByID(menu.Guid);
            if (oldMenu == null)
            {
                throw new EntityIsNullException("Menu hava null");
            }
            oldMenu.ToUpdateEntity(menu);
            menuRepositroy.Update(oldMenu);
        }

        public void RealDelete(Guid menuGuid)
        {
            if (menuGuid == null)
            {
                throw new EntityIsNullException(" menuGuid is null !");
            }
            var oldRole = menuRepositroy.Get(o => o.Guid == menuGuid, null, "Role_Menus").FirstOrDefault();
            if (oldRole != null)
            {
                menuRepositroy.Delete(oldRole);
            }
        }

        public  void Insert(Menu menu)
        {
            if (menu == null)
            {
                throw new EntityIsNullException("Menuis null !");
            }
            var oldMenu = menuRepositroy.Get(o=>o.MenuName == menu.MenuName);
            if (oldMenu != null)
            {
                throw new EntityRepeatException("menu repeat !");
            }

            menuRepositroy.Insert(menu.ToInsertEntity());
        }
    }
}
