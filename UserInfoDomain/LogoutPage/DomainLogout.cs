using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Models;
using ProjectUtils;
using Repositorys;

namespace Domains
{
    public class DomainLogout : IDomainLogout
    {
        private readonly IRepositoryUser repositoryUser;

        public DomainLogout(IRepositoryUser _repositoryUser)
        {
            this.repositoryUser = _repositoryUser;
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="modelUser"></param>
        /// <returns></returns>
        public bool Logout(int userID)
        {
            if (userID <= 0)
            {
                return false;
            }
            return repositoryUser.Logout(userID);
        }
    }
}