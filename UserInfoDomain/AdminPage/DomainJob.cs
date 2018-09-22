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
    public class DomainJob : IDomainJob
    {
        private readonly IRepositoryJob repositoryJob;
        private readonly IRepositoryMapingCore repositoryMapingCore;
        private readonly IRepositoryMapingTeach repositoryMapingTeach;

        public DomainJob(IRepositoryJob repositoryJob, IRepositoryMapingCore repositoryMapingCore, IRepositoryMapingTeach repositoryMapingTeach)
        {
            this.repositoryJob = repositoryJob ?? throw new ArgumentNullException(nameof(repositoryJob));
            this.repositoryMapingCore = repositoryMapingCore ?? throw new ArgumentNullException(nameof(repositoryMapingCore));
            this.repositoryMapingTeach = repositoryMapingTeach ?? throw new ArgumentNullException(nameof(repositoryMapingTeach));
        }


        /// <summary>
        /// 更新职业
        /// </summary>
        /// <param name="modelProfessional"></param>
        /// <returns></returns>
        public bool UpdateJob(ModelProfessional modelProfessional)
        {
            return repositoryJob.Update(modelProfessional);
        }
        /// <summary>
        /// 删除某个职业
        /// </summary>
        /// <param name="modelProfessional"></param>
        /// <returns></returns>
        public bool DeleteJob(int jobID)
        {
            return repositoryJob.ReallyDelete(jobID);
        }
        /// <summary>
        /// 查询所有职业
        /// </summary>
        /// <param name="modelProfessional"></param>
        /// <returns></returns>
        public List<ModelProfessional> FindAllJob()
        {
            return repositoryJob.FindAllJob();
        }
        /// <summary>
        /// 查询某个职业
        /// </summary>
        /// <param name="modelProfessional"></param>
        /// <returns></returns>
        public ModelProfessional FindJob(int jobID)
        {
            return repositoryJob.FindJob(jobID);
        }
        /// <summary>
        /// 插入新职业
        /// </summary>
        /// <param name="modelProfessional"></param>
        /// <returns></returns>
        public bool InsertJob(ModelProfessional modelProfessional)
        {
            return repositoryJob.Insert(modelProfessional);
        }
        /// <summary>
        /// 分配核心技能
        /// </summary>
        /// <param name="professionalID"></param>
        /// <param name="coreSkillsID"></param>
        /// <returns></returns>
        public bool InsertProfessionalCoreSkills(int professionalID, int coreSkillsID)
        {
            return repositoryMapingCore.Insert(professionalID,coreSkillsID);
        }
        /// <summary>
        /// 分配专业技能
        /// </summary>
        /// <param name="professionalID"></param>
        /// <param name="teachSkillsID"></param>
        /// <returns></returns>
        public bool InsertProfessionalTeachSkills(int professionalID, int teachSkillsID)
        {
            return repositoryMapingTeach.Insert(professionalID,teachSkillsID);
        }
        /// <summary>
        /// 显示已分配
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>        
        public List<ModelProfessional> AllotedProfessional(int roleID)
        {
            return repositoryJob.AllotedProfessional(roleID);
        }
    }
}
