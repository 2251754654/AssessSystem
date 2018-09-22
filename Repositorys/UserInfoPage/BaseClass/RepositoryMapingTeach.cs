using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ProjectUtils;
using Repositorys.DataAccess;

namespace Repositorys
{
    public class RepositoryMapingTeach : IRepositoryMapingTeach
    {
        private DBContext dbContext = new DBContext();

        /// <summary>
        /// 查询所有职业对应的所有专业技能
        /// </summary>
        /// <returns></returns>
        public List<ModelJobAndTeachSkill> FindJobAllTeachSkill()
        {
            var AllJob = dbContext.TB_MappingTeach.Include("ModelProfessionalItem").Include("TB_TechSkillsItem").ToList();
            var list = new List<ModelJobAndTeachSkill>();
            foreach (var item in AllJob)
            {
                var jobTeach = new ModelJobAndTeachSkill();
                UtilClass.Convert(item.TB_Professional, jobTeach);
                UtilClass.Convert(item.TB_TechSkills, jobTeach);
                list.Add(jobTeach);
            }
            return list;
        }
        /// <summary>
        /// 查询某个职业对应的所有专业技能
        /// </summary>
        /// <param name="id">职业ID</param>
        /// <returns></returns>
        public List<ModelJobAndTeachSkill> FindJobAllTeachSkill(int id)
        {
            return this.FindJobAllTeachSkill().Where(o=>o.ProfessionalID == id).ToList();
        }
        /// <summary>
        /// 查询某一技能对应的所有职业
        /// </summary>
        /// <param name="id">技能ID</param>
        /// <returns></returns>
        public List<ModelJobAndTeachSkill> FindTeachSkillAllJob(int id)
        {
            return this.FindJobAllTeachSkill().Where(o => o.TeachSkillsID == id).ToList();
        }
        /// <summary>
        /// 分配专业技能
        /// </summary>
        /// <param name="professionalID"></param>
        /// <param name="teachSkillsID"></param>
        /// <returns></returns>
        public bool Insert(int professionalID, int teachSkillsID)
        {
            dbContext.TB_MappingTeach.Add(new TB_MappingTeach() { ProfessionalID = professionalID, TeachSkillsID = teachSkillsID });
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
