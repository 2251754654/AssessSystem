
using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using ProjectUtils;
namespace Domains
{
    public class DomainUserCoreSkills : AbstractDomainUserSkills, IDomainUserCoreSkills
    {
        public DomainUserCoreSkills(IRepositoryRole _repositoryRole, IRepositoryJob _repositoryJob, IRepositoryCoreSkills _repositoryCoreSkills, IRepositoryCoreLever _repositoryCoreLever, IRepositoryRoleContent _repositoryRoleContent, IRepositoryMapingCore _repositoryMapingCore) : base(_repositoryRole, _repositoryJob, _repositoryCoreSkills, _repositoryCoreLever, _repositoryRoleContent, _repositoryMapingCore)
        {
        }
        /// <summary>
        /// 根据角色ID查找某个角色
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public ModelRole FindRole(int roleID)
        {
            return repositoryRole.FindRole(roleID);
        }
        /// <summary>
        /// 根据职业ID查找某个职业
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        public ModelProfessional FindJob(int jobID)
        {
            return repositoryJob.FindJob(jobID);
        }
        /// <summary>
        /// 根据技能ID查询某个技能
        /// </summary>
        /// <param name="skillID"></param>
        /// <returns></returns>
        public ModelCoreSkills FindCoreSkill(int skillID)
        {
            return repositoryCoreSkills.FindCoreSkill(skillID);
        }
        /// <summary>
        /// 根据技能ID查看技能下的所有等级分类
        /// </summary>
        /// <param name="skillID"></param>
        /// <returns></returns>
        public List<ModelCoreLever> FindAllLever(int skillID)
        {
            return repositoryCoreLever.FindCoreSkillLever(skillID);
        }
        /// <summary>
        /// 更具leverID查询某个具体的等级信息
        /// </summary>
        /// <param name="leverID"></param>
        /// <returns></returns>
        public ModelCoreLever FindOneLever(int coreSkillID,int leverID)
        {
            return repositoryCoreLever.FindCoreSkillLever(coreSkillID, leverID);
        }
        /// <summary>
        /// 根据角色ID查询到该角色掌握的所有职业
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public List<ModelRoleAndJob> FindRoleAllJob(int roleID)
        {
            return repositoryRoleContent.FindRoleAllJob(roleID);
        }
        /// <summary>
        /// 根据职业ID查询该职业对应的所有技能
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        public List<ModelJobAndCoreSkill> FindJobAllCoreSkill(int jobID)
        {
            return repositoryMapingCore.FindJobAllCoreSkill(jobID);
        }
        /// <summary>
        /// 根据技能ID查询到技能对应的所有角色
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        public List<ModelJobAndCoreSkill> FindCoreSkillAllJob(int coreSkillID)
        {
            return repositoryMapingCore.FindCoreSkillAllJob(coreSkillID);
        }
        /// <summary>
        /// 字典集合查询（类似于导航）
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndCoreSkill, List<ModelCoreLever>>> FindJobAndSkillAndLeverThreeLayers(int roleID)
        {
            var jobs =  new Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndCoreSkill, List<ModelCoreLever>>>(); //dic = new Dictionary<int, string>();
            //三维数组，一维为职业，二维为技能，三维为技能等级，
            var allJob = FindRoleAllJob(roleID);
            foreach (var allJobItem in allJob)
            {
                var allCoreSkill = FindJobAllCoreSkill(allJobItem.ProfessionalID);
                var skills = new Dictionary<ModelJobAndCoreSkill, List<ModelCoreLever>>();
                foreach (var allSkillItem in allCoreSkill)
                {
                    var lever = FindAllLever(allSkillItem.CoreSkillsID);
                    var levers = new List<ModelCoreLever>();
                    foreach (var leverItem in lever)
                    {
                        levers.Add(leverItem);
                    }
                    skills.Add(allSkillItem,levers);
                }
                jobs.Add(allJobItem, skills);
            }
            return jobs;
        }
        /// <summary>
        /// 根据角色ID查询到所有的信息存储在联合三张表的ModelJobAndSkillAndLever大表中
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public List<ModelJobAndSkillAndLever> FindJobAndSkillAndLever(int roleID)
        {
            var allData = new List<ModelJobAndSkillAndLever>();
            var allJob = FindRoleAllJob(roleID);
            foreach (var allJobItem in allJob)
            {
                var allCoreSkill = FindJobAllCoreSkill(allJobItem.ProfessionalID);
                foreach (var allSkillItem in allCoreSkill)
                {
                    var lever = FindAllLever(allSkillItem.CoreSkillsID);
                    foreach (var leverItem in lever)
                    {
                        ModelJobAndSkillAndLever allDataItem = new ModelJobAndSkillAndLever();
                        UtilClass.Convert(leverItem, allDataItem);
                        UtilClass.Convert(allSkillItem, allDataItem);
                        UtilClass.Convert(allJobItem, allDataItem);
                        allData.Add(allDataItem);
                    }
                }

            }
            return allData;
        }
        /// <summary>
        /// 字典集合查询（类似于表格）
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public List<Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndCoreSkill, ModelCoreLever>>> FindJobAndSkillAndLeverThreeLayersList(int roleID)
        {
            var allData = new List<Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndCoreSkill, ModelCoreLever>>>();
            //三维数组，一维为职业，二维为技能，三维为技能等级，
            var allJob = FindRoleAllJob(roleID);
            foreach (var allJobItem in allJob)
            {
                var allCoreSkill = FindJobAllCoreSkill(allJobItem.ProfessionalID);
                foreach (var allSkillItem in allCoreSkill)
                {
                    var lever = FindAllLever(allSkillItem.CoreSkillsID);
                    foreach (var leverItem in lever)
                    {
                        var job     = new Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndCoreSkill, ModelCoreLever>>();
                        var skill   = new Dictionary<ModelJobAndCoreSkill, ModelCoreLever>();
                                    skill.Add(allSkillItem, leverItem);
                                    job.Add(allJobItem, skill);
                        allData.Add(job);
                    }
                }
            }
            return allData;
        }
    }
}