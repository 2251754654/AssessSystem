using System;
using System.Collections.Generic;
using Models;
using Repositorys;

namespace Domains
{
    public abstract class AbstractDomainUserSkills
    {
        /// <summary>
        /// 角色
        /// </summary>
        protected readonly IRepositoryRole repositoryRole;
        /// <summary>
        /// 职业
        /// </summary>
        protected readonly IRepositoryJob repositoryJob;
        /// <summary>
        /// 核心技能
        /// </summary>
        protected readonly IRepositoryCoreSkills repositoryCoreSkills;
        /// <summary>
        /// 技能等级
        /// </summary>
        protected readonly IRepositoryCoreLever repositoryCoreLever;
        /// <summary>
        /// 角色对应的职业
        /// </summary>
        protected readonly IRepositoryRoleContent repositoryRoleContent;
        /// <summary>
        /// 职业对应的技能
        /// </summary>
        protected readonly IRepositoryMapingCore repositoryMapingCore;
        /// <summary>
        /// 职业对应的专业技能
        /// </summary>
        protected readonly IRepositoryMapingTeach repositoryMapingTeach;
        /// <summary>
        /// 专业技能
        /// </summary>
        protected readonly IRepositoryTeachSkills repositoryTeachSkills;
        /// <summary>
        /// 专业技能等级
        /// </summary>
        protected readonly IRepositoryTeachLever repositoryTeachLever;

        public AbstractDomainUserSkills(IRepositoryRole _repositoryRole
            , IRepositoryJob _repositoryJob
            , IRepositoryCoreSkills _repositoryCoreSkills
            , IRepositoryCoreLever _repositoryCoreLever
            , IRepositoryRoleContent _repositoryRoleContent
            , IRepositoryMapingCore _repositoryMapingCore)
        {
            this.repositoryRole = _repositoryRole ?? throw new ArgumentNullException(nameof(repositoryRole));
            this.repositoryJob = _repositoryJob ?? throw new ArgumentNullException(nameof(repositoryJob));
            this.repositoryCoreSkills = _repositoryCoreSkills ?? throw new ArgumentNullException(nameof(repositoryCoreSkills));
            this.repositoryCoreLever = _repositoryCoreLever ?? throw new ArgumentNullException(nameof(repositoryCoreLever));
            this.repositoryRoleContent = _repositoryRoleContent ?? throw new ArgumentNullException(nameof(repositoryRoleContent));
            this.repositoryMapingCore = _repositoryMapingCore ?? throw new ArgumentNullException(nameof(repositoryMapingCore));
        }

        protected AbstractDomainUserSkills(IRepositoryRole repositoryRole, IRepositoryJob repositoryJob, IRepositoryRoleContent repositoryRoleContent, IRepositoryMapingTeach repositoryMapingTeach, IRepositoryTeachSkills repositoryTeachSkills, IRepositoryTeachLever repositoryTeachLever)
        {
            this.repositoryRole = repositoryRole ?? throw new ArgumentNullException(nameof(repositoryRole));
            this.repositoryJob = repositoryJob ?? throw new ArgumentNullException(nameof(repositoryJob));
            this.repositoryRoleContent = repositoryRoleContent ?? throw new ArgumentNullException(nameof(repositoryRoleContent));
            this.repositoryMapingTeach = repositoryMapingTeach ?? throw new ArgumentNullException(nameof(repositoryMapingTeach));
            this.repositoryTeachSkills = repositoryTeachSkills ?? throw new ArgumentNullException(nameof(repositoryTeachSkills));
            this.repositoryTeachLever = repositoryTeachLever ?? throw new ArgumentNullException(nameof(repositoryTeachLever));
        }
    }
}