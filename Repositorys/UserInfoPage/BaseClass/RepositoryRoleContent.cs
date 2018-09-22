using Models;
using ProjectUtils;
using Repositorys.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class RepositoryRoleContent : IRepositoryRoleContent
    {
        private DBContext dbContext = new DBContext();
        /// <summary>
        /// 查询某个角色对应的所有技能
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns></returns>
        public List<ModelRoleAndJob> FindRoleAllJob(int id)
        {
            var AllRole = dbContext.TB_RoleContent.Include("TB_Professional").Include("TB_Role").ToList();
            var oneRole = AllRole.Where(o=>o.TB_Role.RoleID == id).ToList();
            var list = new List<ModelRoleAndJob>();
            foreach (var item in oneRole)
            {
                var roleJob = new ModelRoleAndJob();
                UtilClass.Convert(item.TB_Role, roleJob);
                UtilClass.Convert(item.TB_Professional, roleJob);
                list.Add(roleJob);
            }
            return list;
        }
        /// <summary>
        /// 查询所有角色对应的所有技能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ModelRoleAndJob> FindRoleAllJob()
        {
            var AllRole = dbContext.TB_RoleContent.Include("TB_Professional").Include("TB_Role").ToList();
            var list = new List<ModelRoleAndJob>();
            foreach (var item in AllRole)
            {
                var roleJob = new ModelRoleAndJob();
                UtilClass.Convert(item.TB_Role, roleJob);
                UtilClass.Convert(item.TB_Professional, roleJob);
                list.Add(roleJob);
            }
            return list;
        }
        /// <summary>
        /// 查询某一职业对应的所有角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ModelRoleAndJob> FindJobAllRole(int id)
        {
            var AllRole = dbContext.TB_RoleContent.Include("TB_Professional").Include("TB_Role").ToList();
            var oneRole = AllRole.Where(o => o.TB_Professional.ProfessionalID == id).ToList();
            var list = new List<ModelRoleAndJob>();
            foreach (var item in oneRole)
            {
                var roleJob = new ModelRoleAndJob();
                UtilClass.Convert(item.TB_Role, roleJob);
                UtilClass.Convert(item.TB_Professional, roleJob);
                list.Add(roleJob);
            }
            return list;
        }

        /// <summary>
        /// 插入某个角色对应的职业
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="professionalID"></param>
        /// <returns></returns>
        public bool Insert(int roleID, int professionalID)
        {
            //var role = dbContext.TB_Role.Find(roleID);
            //var professional = dbContext.TB_Professional.Find(professionalID);
            var roleContent = new TB_RoleContent();
            roleContent.RoleID = roleID;
            roleContent.ProfessionalID = professionalID;
            dbContext.TB_RoleContent.Add(roleContent);
            if (dbContext.SaveChanges() >0)
            {
                return true;
            }
            return false;
        }
    }
}
