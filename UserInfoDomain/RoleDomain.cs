using Models;
using Repositorys;
using System;
using System.Collections.Generic;

namespace Domains
{
    public class RoleDomain
    {
        public RoleDomain()
        {
        }

        public List<RoleModel> GetAllRole()
        {
            RoleRepository roleRepository = new RoleRepository();
            return roleRepository.GetAllRole();
        }

        public int InsertRole(RoleModel roleModel)
        {
            RoleRepository roleRepository = new RoleRepository();
            return roleRepository.InsertRole(roleModel);
        }

        public bool UpdateRole(RoleModel roleModel)
        {
            RoleRepository roleRepository = new RoleRepository();
            if (roleRepository.UpdateRole(roleModel) > 0)
            {
                return true;
            }
            return false;

        }

        public bool DeletRole(int[] roleArr)
        {
            RoleRepository roleRepository = new RoleRepository();
            if (roleRepository.DeleteRole(roleArr) > 0)
            {
                return true;
            }
            return false;
        }
    }
}