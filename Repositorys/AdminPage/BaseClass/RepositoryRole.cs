using System;
using System.Linq;
using Repositorys.DataAccess;
using Models;
using System.Collections.Generic;
using ProjectUtils;

namespace Repositorys
{
    public class RepositoryRole : IRepositoryRole
    {
        private readonly DBContext dbContext = new DBContext();

        /// <summary>
        /// 更具角色ID查询角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ModelRole FindRole(int id)
        {
            var role = dbContext.TB_Role.Find(id);
            var modelRole = new ModelRole();
            if (UtilClass.Convert(role, modelRole))
            {
                return modelRole;
            }
            return null;
        }
        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns></returns>
        public List<ModelRole> FindAllRole()
        {
            var role = dbContext.TB_Role.ToList();
            var modelRole = new List<ModelRole>();
            if (role != null)
            {
                foreach (var roleItem in role)
                {
                    var modelRoleItem = new ModelRole();
                    UtilClass.Convert(roleItem, modelRoleItem);
                    modelRole.Add(modelRoleItem);
                }
                return modelRole;
            }
            return null;
        }
        /// <summary>
        /// 查询所有删除的用户
        /// </summary>
        /// <param name="evaluationID"></param>
        /// <returns></returns>
        public List<ModelRole> FindAllDeleteRole()
        {
            var role = dbContext.TB_Role.Where(o=>o.RoleDelete == 0).ToList();
            var modelRole = new List<ModelRole>();
            if (role != null)
            {
                foreach (var roleItem in role)
                {
                    var modelRoleItem = new ModelRole();
                    UtilClass.Convert(roleItem, modelRoleItem);
                    modelRole.Add(modelRoleItem);
                }
                return modelRole;
            }
            return null;
        }
        /// <summary>
        /// 查询所有未删除的用户
        /// </summary>
        /// <param name="evaluationID"></param>
        /// <returns></returns>
        public List<ModelRole> FindAllNotDeleteRole()
        {
            var role = dbContext.TB_Role.Where(o => o.RoleDelete == 1).ToList();
            var modelRole = new List<ModelRole>();
            if (role != null)
            {
                foreach (var roleItem in role)
                {
                    var modelRoleItem = new ModelRole();
                    UtilClass.Convert(roleItem, modelRoleItem);
                    modelRole.Add(modelRoleItem);
                }
                return modelRole;
            }
            return null;
        }
        /// <summary>
        /// 插入角色
        /// </summary>
        /// <param name="modelRole"></param>
        /// <returns></returns>
        public bool Insert(ModelRole modelRole)
        {
            var role = new TB_Role();
            UtilClass.Convert(modelRole, role);
            dbContext.TB_Role.Add(role);
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 更新角色(上层必须确保字段确实更新了，没更新则为false)
        /// </summary>
        /// <param name="modelRole"></param>
        /// <returns></returns>
        public bool Update(ModelRole modelRole)
        {
            var role = dbContext.TB_Role.Find(modelRole.RoleID);
            if (role != null)
            {
                UtilClass.Convert(modelRole, role);
                if (dbContext.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// 物理删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ReallyDelete(int id)
        {

            var result = dbContext.TB_Role.Include("TB_RoleContent").Where(o=>o.RoleID == id).FirstOrDefault();
            if (result != null)
            {
                dbContext.TB_Role.Remove(result);  
                if (dbContext.SaveChanges()>0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        /// <summary>
        /// 逻辑删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FakeDelete(int id)
        {
            var result = dbContext.TB_Role.Find(id);
            if (result != null)
            {
                result.RoleDelete = 0;
                try
                {
                    dbContext.SaveChanges();
                }
                catch(Exception e)
                {
                    return false;
                    throw e;
                }
                return true;
            }
            return true;
        }

    }
}