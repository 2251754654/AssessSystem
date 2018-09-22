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
    public class RepositoryMapingCore : IRepositoryMapingCore
    {
        
        private DBContext dbContext = new DBContext();
        /// <summary>
        /// 查询某个职业对应的所有核心技能
        /// </summary>
        /// <param name="id">职业ID</param>
        /// <returns></returns>
        public List<ModelJobAndCoreSkill> FindJobAllCoreSkill(int id)
        {
            var AllJob = dbContext.TB_MappingCore.Include("TB_CoreSkills").Include("TB_Professional").ToList();
            var oneJob = AllJob.Where(o => o.TB_Professional.ProfessionalID == id).ToList();
            var list = new List<ModelJobAndCoreSkill>();
            foreach (var item in oneJob)
            {
                var jobCore = new ModelJobAndCoreSkill();
                UtilClass.Convert(item.TB_Professional, jobCore);
                UtilClass.Convert(item.TB_CoreSkills, jobCore);
                list.Add(jobCore);
            }
            return list;
        }
        /// <summary>
        /// 查询所有职业对应的所有核心技能
        /// </summary>
        /// <returns></returns>
        public List<ModelJobAndCoreSkill> FindJobAllCoreSkill()
        {
            var AllJob = dbContext.TB_MappingCore.Include("ModelCoreSkillsItem").Include("ModelProfessionalItem").ToList();
            var list = new List<ModelJobAndCoreSkill>();
            foreach (var item in AllJob)
            {
                var jobCore = new ModelJobAndCoreSkill();
                UtilClass.Convert(item.TB_Professional, jobCore);
                UtilClass.Convert(item.TB_CoreSkills, jobCore);
                list.Add(jobCore);
            }
            return list;
        }
        /// <summary>
        /// 查询某一技能对应的所有职业
        /// </summary>
        /// <param name="id">技能ID</param>
        /// <returns></returns>
        public List<ModelJobAndCoreSkill> FindCoreSkillAllJob(int id)
        {
            var AllJob = dbContext.TB_MappingCore.Include("ModelCoreSkillsItem").Include("ModelProfessionalItem").ToList();
            var oneJob = AllJob.Where(o => o.TB_CoreSkills.CoreSkillsID == id).ToList();
            var list = new List<ModelJobAndCoreSkill>();
            foreach (var item in oneJob)
            {
                var jobCore = new ModelJobAndCoreSkill();
                UtilClass.Convert(item.TB_Professional, jobCore);
                UtilClass.Convert(item.TB_CoreSkills, jobCore);
                list.Add(jobCore);
            }
            return list;
        }
        /// <summary>
        /// 分配核心技能
        /// </summary>
        /// <param name="professionalID"></param>
        /// <param name="coreSkillsID"></param>
        /// <returns></returns>
        public bool Insert(int professionalID, int coreSkillsID)
        {
            dbContext.TB_MappingCore.Add(new TB_MappingCore() { ProfessionalID = professionalID, CoreSkillsID=coreSkillsID });
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
