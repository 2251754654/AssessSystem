
using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using ProjectUtils;
namespace Domains
{
    public class DomainUserTeachSkills : AbstractDomainUserSkills, IDomainUserTeachSkills
    {
        public DomainUserTeachSkills(IRepositoryRole repositoryRole, IRepositoryJob repositoryJob, IRepositoryRoleContent repositoryRoleContent, IRepositoryMapingTeach repositoryMapingTeach, IRepositoryTeachSkills repositoryTeachSkills, IRepositoryTeachLever repositoryTeachLever) : base(repositoryRole, repositoryJob, repositoryRoleContent, repositoryMapingTeach, repositoryTeachSkills, repositoryTeachLever)
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
        public ModelTechSkills FindTeachSkill(int skillID)
        {
            return repositoryTeachSkills.FindTechSkill(skillID);
        }
        /// <summary>
        /// 根据技能ID查看技能下的所有等级分类
        /// </summary>
        /// <param name="skillID"></param>
        /// <returns></returns>
        public List<ModelTeachLever> FindAllLever(int skillID)
        {
            return repositoryTeachLever.FindTechSkillLever(skillID);
        }
        /// <summary>
        /// 更具leverID查询某个具体的等级信息
        /// </summary>
        /// <param name="leverID"></param>
        /// <returns></returns>
        public ModelTeachLever FindOneLever(int teachSkillID,int leverID)
        {
            return repositoryTeachLever.FindTechSkillLever(teachSkillID,leverID);
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
        public List<ModelJobAndTeachSkill> FindJobAllTeachSkill(int jobID)
        {
            return repositoryMapingTeach.FindJobAllTeachSkill(jobID);
        }
        /// <summary>
        /// 根据技能ID查询到技能对应的所有角色
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        public List<ModelJobAndTeachSkill> FindTeachSkillAllJob(int TeachSkillID)
        {
            return repositoryMapingTeach.FindTeachSkillAllJob(TeachSkillID);
        }
        /// <summary>
        /// 字典集合查询（类似于导航）
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndTeachSkill, List<ModelTeachLever>>> FindJobAndSkillAndLeverThreeLayers(int roleID)
        {
            var jobs = new Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndTeachSkill, List<ModelTeachLever>>>(); //dic = new Dictionary<int, string>();
            //三维数组，一维为职业，二维为技能，三维为技能等级，
            var allJob = FindRoleAllJob(roleID);
            foreach (var allJobItem in allJob)
            {
                var allCoreSkill = FindJobAllTeachSkill(allJobItem.ProfessionalID);
                var skills = new Dictionary<ModelJobAndTeachSkill, List<ModelTeachLever>>();
                foreach (var allSkillItem in allCoreSkill)
                {
                    var lever = FindAllLever(allSkillItem.TeachSkillsID);
                    var levers = new List<ModelTeachLever>();
                    foreach (var leverItem in lever)
                    {
                        levers.Add(leverItem);
                    }
                    skills.Add(allSkillItem, levers);
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
        public List<ModelJobAndTeachSkillAndLever> FindJobAndSkillAndLever(int roleID)
        {
            var allData = new List<ModelJobAndTeachSkillAndLever>();
            var allJob = FindRoleAllJob(roleID);
            foreach (var allJobItem in allJob)
            {
                var allCoreSkill = FindJobAllTeachSkill(allJobItem.ProfessionalID);
                foreach (var allSkillItem in allCoreSkill)
                {
                    var lever = FindAllLever(allSkillItem.TeachSkillsID);
                    foreach (var leverItem in lever)
                    {
                        var allDataItem = new ModelJobAndTeachSkillAndLever();
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
        public List<Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndTeachSkill, ModelTeachLever>>> FindJobAndSkillAndLeverThreeLayersList(int roleID)
        {
            var allData = new List<Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndTeachSkill, ModelTeachLever>>>();
            //三维数组，一维为职业，二维为技能，三维为技能等级，
            var allJob = FindRoleAllJob(roleID);
            foreach (var allJobItem in allJob)
            {
                var allCoreSkill = FindJobAllTeachSkill(allJobItem.ProfessionalID);
                foreach (var allSkillItem in allCoreSkill)
                {
                    var lever = FindAllLever(allSkillItem.TeachSkillsID);
                    foreach (var leverItem in lever)
                    {
                        var job = new Dictionary<ModelRoleAndJob, Dictionary<ModelJobAndTeachSkill, ModelTeachLever>>();
                        var skill = new Dictionary<ModelJobAndTeachSkill, ModelTeachLever>();
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