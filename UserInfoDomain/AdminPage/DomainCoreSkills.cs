using Domains;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorys;

namespace Domains
{
    public class DomainCoreSkills : IDomainCoreSkills
    {
        private readonly IRepositoryCoreSkills repositoryCoreSkills;
        private readonly IRepositoryCoreLever repositoryCoreLever;

        public DomainCoreSkills(IRepositoryCoreSkills repositoryCoreSkills, IRepositoryCoreLever repositoryCoreLever)
        {
            this.repositoryCoreSkills = repositoryCoreSkills ?? throw new ArgumentNullException(nameof(repositoryCoreSkills));
            this.repositoryCoreLever = repositoryCoreLever ?? throw new ArgumentNullException(nameof(repositoryCoreLever));
        }

        /// <summary>
        /// 删除核心技能
        /// </summary>
        /// <param name="coreSkillsID"></param>
        /// <returns></returns>
        public bool DeleteCoreSkills(int coreSkillsID)
        {
            return repositoryCoreSkills.ReallyDelete(coreSkillsID);
        }

        /// <summary>
        /// 查找所有技能
        /// </summary>
        /// <returns></returns>
        public List<ModelCoreSkills> FindAllCoreSkills()
        {
            return repositoryCoreSkills.FindAllCoreSkill();
        }

        /// <summary>
        /// 插入技能
        /// </summary>
        /// <param name="modelCoreSkills"></param>
        /// <returns></returns>
        public bool InsertCoreSkills(ModelCoreSkills modelCoreSkills)
        {
            modelCoreSkills.CoreSkillsGUID = Guid.NewGuid().ToString();
            return repositoryCoreSkills.Insert(modelCoreSkills);
        }

        /// <summary>
        /// 更新技能
        /// </summary>
        /// <param name="modelCoreSkills"></param>
        /// <returns></returns>
        public bool UpdateCoreSkills(ModelCoreSkills modelCoreSkills)
        {
            return repositoryCoreSkills.Update(modelCoreSkills);
        }

        /// <summary>
        /// 查询等级
        /// </summary>
        /// <returns></returns>
        public List<ModelCoreLever> FindAllLever(int coreSkillsID)
        {
            return repositoryCoreLever.FindCoreSkillLever(coreSkillsID);
        }
        /// <summary>
        /// 删除等级
        /// </summary>
        /// <param name="coreSkillsID"></param>
        /// <param name="coreLeverID"></param>
        /// <returns></returns>
        public bool DeleteLever(int coreSkillsID, int coreLeverID)
        {
            return repositoryCoreLever.ReallyDeleteOne(coreLeverID);
        }
        /// <summary>
        /// 插入等级
        /// </summary>
        /// <param name="modelCoreLever"></param>
        /// <returns></returns>
        public bool InsertLever(ModelCoreLever modelCoreLever)
        {
            return repositoryCoreLever.Insert(modelCoreLever);
        }
        /// <summary>
        /// 查询分配的
        /// </summary>
        /// <param name="professionalID"></param>
        /// <returns></returns>
        public List<ModelCoreSkills> AllotCoreSkills(int professionalID)
        {
            return repositoryCoreSkills.FindCoreSkillByProfessionalID(professionalID);
        }
    }
}
