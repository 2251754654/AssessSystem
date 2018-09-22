using Models;
using Repositorys;
using System;
using System.Collections.Generic;

namespace Domains
{
    public class DomainOtherAssess : IDomainOtherAssess
    {

        private readonly IRepositroyAssess repositroyAssess;
        public DomainOtherAssess(IRepositroyAssess _repositroyAssess)
        {
            this.repositroyAssess = _repositroyAssess ?? throw new ArgumentNullException(nameof(repositroyAssess));
        }

        /// <summary>
        /// 根据userid获取他人对自己的评论
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<ModelAssessDetails> FindOtherAssessToOneself(int userID)
        {
            return repositroyAssess.FindByAssess(userID);
        }
        /// <summary>
        /// 所有人的评论
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<ModelAssessDetails> FindAllAssess()
        {
            return repositroyAssess.FindAllAssess();
        }
        /// <summary>
        /// 所有未删除评论
        /// </summary>
        /// <returns></returns>
        public List<ModelAssessDetails> FindAllNotDeleteAssess()
        {
            return repositroyAssess.FindAllNotDeleteAssess();
        }
        /// <summary>
        /// 所有已删除评论
        /// </summary>
        /// <returns></returns>
        public List<ModelAssessDetails> FindAllDeleteAssess()
        {
            return repositroyAssess.FindAllDeleteAssess();
        }
        /// <summary>
        /// 对核心技能评论的详情
        /// </summary>
        /// <param name="assessID"></param>
        /// <returns></returns>
        public List<ModelAssessDetails> FindCoreSkillAssessDetails(int assessID)
        {
            return repositroyAssess.FindAssessCoreDetails(assessID);
        }
        /// <summary>
        /// 对专业技能评论的详情
        /// </summary>
        /// <param name="assessID"></param>
        /// <returns></returns>
        public List<ModelAssessDetails> FindTeachSkillAssessDetails(int assessID)
        {
            return repositroyAssess.FindAssessTeachDetails(assessID);
        }
    }
}
 