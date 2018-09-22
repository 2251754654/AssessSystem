using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domains
{
    public class DomainOneselfAssess : IDomainOneselfAssess
    {

        private readonly IRepositroyAssess repositroyAssess;
        public DomainOneselfAssess(IRepositroyAssess _repositroyAssess)
        {
            this.repositroyAssess = _repositroyAssess ?? throw new ArgumentNullException(nameof(repositroyAssess));
        }

        /// <summary>
        /// 根据userid获取自己对自己的评论
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<ModelAssessDetails> FindOneselfAssessToOneself(int userID)
        {
            return repositroyAssess.FindMainAssessToOneself(userID);
        }
        /// <summary>
        /// 根据userid获取自己对自己某条的评论详细情况
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<ModelAssessDetails> FindOneselfAssessToOneselfDetails(int assessID)
        {
            var assessDetails = repositroyAssess.FindAssessCoreDetails(assessID);
            return assessDetails.ToList();
        }
        /// <summary>
        /// 自己对他人的评论
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<ModelAssessDetails> FindOneselfAssessToOthers(int userID)
        {
            return repositroyAssess.FindMainAssess(userID);
        }
    }
}