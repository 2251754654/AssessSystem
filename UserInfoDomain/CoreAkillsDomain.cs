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
            RespositoryCoreAkills coreAkillsRespository = new RespositoryCoreAkills();
            return coreAkillsRespository.GetGetCoreSkillsByUserInfoID(userInfoID);
        }
    }
}