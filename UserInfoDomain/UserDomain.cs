using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Models;
using Repositorys;

namespace Domains
{
    public class UserDomain : iUserDomain
    {
        private IUserRepository iUserRepository { get; set; }
        public UserDomain(IUserRepository _iUserRepository)
        {
            this.iUserRepository = _iUserRepository;
        }
        public ModelUser LoginCheck(ModelUser userModel)
        {
            //校验数据是否符合标准
            if ("".Equals(userModel.UserName)||"".Equals(userModel.UserPassword))
            {
                userModel.UserName = "用户名或密码为空！";
                userModel.UserPassword = "失败";
                return userModel;
            }
            if (!new Regex("[0-9A-Za-z]{4,}").IsMatch(userModel.UserName))
            {
                userModel.UserName = "用户名不符合规范！";
                userModel.UserPassword = "失败";
                return userModel;
            }
            if (!new Regex("[0-9A-Za-z]{6,18}").IsMatch(userModel.UserPassword))
            {
                userModel.UserName = "密码不符合规范！";
                userModel.UserPassword = "失败";
                return userModel;
            }
            MD5 mD5 = new MD5CryptoServiceProvider();
            userModel.UserPassword = System.Text.Encoding.UTF8.GetString(mD5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userModel.UserPassword)));
            return iUserRepository.LoginCheck(userModel);
        }
    }
}