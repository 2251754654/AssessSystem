using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Models;
using ProjectUtils;
using Repositorys;

namespace Domains
{
    public class DomainLogin : IDomainLogin
    {
        private readonly IRepositoryUser repositoryUser;

        public DomainLogin(IRepositoryUser _repositoryUser)
        {
            this.repositoryUser = _repositoryUser;
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="modelUser"></param>
        /// <returns></returns>
        public ModelUser Login(ModelUser modelUser)
        {
            //校验数据是否符合标准
            //if ("".Equals(modelUser.UserName)||"".Equals(modelUser.UserPassword))
            //{
            //    modelUser.UserName = "用户名或密码为空！";
            //    modelUser.UserPassword = "0";
            //    return modelUser;
            //}
            //if (!new Regex("[0-9A-Za-z]{4,}").IsMatch(modelUser.UserName))
            //{
            //    modelUser.UserName = "用户名不符合规范！";
            //    modelUser.UserPassword = "0";
            //    return modelUser;
            //}
            //if (!new Regex("[0-9A-Za-z]{6,18}").IsMatch(modelUser.UserPassword))
            //{
            //    modelUser.UserName = "密码不符合规范！";
            //    modelUser.UserPassword = "0";
            //    return modelUser;
            //}
           modelUser.UserPassword = UtilConvertMD5.MD5(modelUser.UserPassword);
            return repositoryUser.Login(modelUser);
        }
    }
}