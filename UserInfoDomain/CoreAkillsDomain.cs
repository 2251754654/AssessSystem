using Repositorys;
using System;

namespace Domains
{
    public class CoreAkillsDomain
    {
        public CoreAkillsDomain()
        {
        }

        public dynamic GetCoreSkillsByUserInfoID(int userInfoID)
        {
            CoreAkillsRespository coreAkillsRespository = new CoreAkillsRespository();
            return coreAkillsRespository.GetGetCoreSkillsByUserInfoID(userInfoID);
        }
    }
}