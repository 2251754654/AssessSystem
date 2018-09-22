using Models;
using ProjectUtils;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class DomainRegist : IDomainRegist
    {

        private readonly IRepositoryUser repositoryUser;

        public DomainRegist(IRepositoryUser _repositoryUser)
        {
            this.repositoryUser = _repositoryUser;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="modelUser"></param>
        /// <returns>0 系统中有次账号</returns>
        public int Regist(ModelUser modelUser)
        {
            //校验注册信息是否符合标准

            //注册密码加密
            modelUser.UserPassword = UtilConvertMD5.MD5(modelUser.UserPassword);
            //判断系统中有没有此用户账号
            if (repositoryUser.FingUserNameOrID(modelUser) == true)
            {
                //有账号
                return 0;
            }
            if (repositoryUser.Regist(modelUser))
            {
                //注册成功
                return 1;
            }
            //注册失败
            return -1;
        }
    }
}
