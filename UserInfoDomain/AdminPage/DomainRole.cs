using Models;
using Repositorys;
using System;
using System.Collections.Generic;

namespace Domains
{
    public class DomainRole : IDomainRole
    {
        private readonly IRepositoryRole repositoryRole;
        private readonly IRepositoryRoleContent repositoryRoleContent;

        public DomainRole(IRepositoryRole repositoryRole, IRepositoryRoleContent repositoryRoleContent)
        {
            this.repositoryRole = repositoryRole ?? throw new ArgumentNullException(nameof(repositoryRole));
            this.repositoryRoleContent = repositoryRoleContent ?? throw new ArgumentNullException(nameof(repositoryRoleContent));
        }

        /// <summary>
        ///删除角色
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public bool DeleteRole(int roleID)
        {
            return repositoryRole.ReallyDelete(roleID);
        }

        /// <summary>
        /// 查找所有角色
        /// </summary>
        /// <returns></returns>
        public List<ModelRole> FindAllRole()
        {
            return repositoryRole.FindAllRole(); ;
        }
        /// <summary>
        /// 根据RoleID查询某个指定的Role
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public ModelRole FindRole(int roleID)
        {
            return repositoryRole.FindRole(roleID); ;
        }
        /// <summary>
        /// 插入角色
        /// </summary>
        /// <param name="modelRol"></param>
        /// <returns></returns>
        public bool InsertRole(ModelRole modelRol)
        {
            return repositoryRole.Insert(modelRol);
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="modelRole"></param>
        /// <returns></returns>
        public bool UpdateRole(ModelRole modelRole)
        {
            return repositoryRole.Update(modelRole);
        }

        /// <summary>
        /// 分配职业
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="professionalID"></param>
        /// <returns></returns>
        public bool InsertRoleProfessional(int roleID, int professionalID)
        {
            return repositoryRoleContent.Insert(roleID, professionalID);
        }

    }
}