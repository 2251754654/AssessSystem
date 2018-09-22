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
    public class DomainTeachSkills : IDomainTeachSkills
    {
        private readonly IRepositoryTeachSkills repositoryTeachSkills;
        private readonly IRepositoryTeachLever repositoryTeachLever;

        public DomainTeachSkills(IRepositoryTeachSkills repositoryTeachSkills, IRepositoryTeachLever repositoryTeachLever)
        {
            this.repositoryTeachSkills = repositoryTeachSkills ?? throw new ArgumentNullException(nameof(repositoryTeachSkills));
            this.repositoryTeachLever = repositoryTeachLever ?? throw new ArgumentNullException(nameof(repositoryTeachLever));
        }



        /// <summary>
        /// 删除专业技能
        /// </summary>
        /// <param name="teackSkillsID"></param>
        /// <returns></returns>
        public bool DeleteTeachSkills(int teackSkillsID)
        {
            return repositoryTeachSkills.ReallyDelete(teackSkillsID);
        }

        /// <summary>
        /// 查找所有专业技能
        /// </summary>
        /// <returns></returns>
        public List<ModelTechSkills> FindAllTeachSkills()
        {
            return repositoryTeachSkills.FindAllTechSkill();
        }

        /// <summary>
        /// 插入专业技能
        /// </summary>
        /// <param name="modelTechSkills"></param>
        /// <returns></returns>
        public bool InsertTeachSkills(ModelTechSkills modelTechSkills)
        {
            modelTechSkills.TeachSkillsGUID = Guid.NewGuid().ToString();
            return repositoryTeachSkills.Insert(modelTechSkills);
        }
        /// <summary>
        /// 更新专业技能
        /// </summary>
        /// <param name="modelTechSkills"></param>
        /// <returns></returns>
        public bool UpdateTeackSkills(ModelTechSkills modelTechSkills)
        {
            return repositoryTeachSkills.Update(modelTechSkills);
        }
        /// <summary>
        /// 删除等级
        /// </summary>
        /// <param name="teachSkillsID"></param>
        /// <param name="teachLeverID"></param>
        /// <returns></returns>
        public bool DeleteLever(int teachSkillsID, int teachLeverID)
        {
            return repositoryTeachLever.ReallyDeleteOne(teachLeverID);
        }
       /// <summary>
       /// 查找等级
       /// </summary>
       /// <param name="teachSkillsID"></param>
       /// <returns></returns>
        public List<ModelTeachLever> FindAllLever(int teachSkillsID)
        {
            return repositoryTeachLever.FindTechSkillLever(teachSkillsID);
        }
        /// <summary>
        /// 插入等级
        /// </summary>
        /// <param name="modelTeachLever"></param>
        /// <returns></returns>
        public bool InsertLever(ModelTeachLever modelTeachLever)
        {
            return repositoryTeachLever.Insert(modelTeachLever);
        }
        /// <summary>
        /// 分配的专业技能
        /// </summary>
        /// <param name="professionalID"></param>
        /// <returns></returns>
        public List<ModelTechSkills> AllotTeachSkills(int professionalID)
        {
            return repositoryTeachSkills.FindTeachSkillsByProfessionalID(professionalID);
        }
    }
}
