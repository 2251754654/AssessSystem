using Repositorys;
using System;

namespace Domains
{
    public class TeachAkillsDomain
    {
        public dynamic GetTeachSkillsByUserInfoID(int userInfoID)
        {
            TeachAkillsRespository teachAkillsRespository = new TeachAkillsRespository();
            return teachAkillsRespository.GetTeachSkillsByUserInfoID(userInfoID);
        }
    }
}