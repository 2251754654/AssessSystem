
using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class DomainUserInfo : IDomainUserInfo
    {
        private readonly IRepositoryUserInfo repositoryUserInfo;

        public DomainUserInfo(IRepositoryUserInfo _repositoryUserInfo)
        {
            this.repositoryUserInfo = _repositoryUserInfo;
        }
        /// <summary>
        /// 获得指定ID的用户信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ModelUserInfo FindUserInfo(int userID)
        {
            if (userID <= 0)
            {
                return null;
            }
            return repositoryUserInfo.FindUserInfo(userID);
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="modelUserInfo"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(ModelUserInfo modelUserInfo)
        {
            return repositoryUserInfo.Update(modelUserInfo);
        }
    }
}
