using Domains.Utils;
using Models.ReferenceModels;
using Repositorys;
using System;
using System.Collections.Generic;

namespace Domains
{
    public class UserCoreSkillsDomain
    {
        public UserCoreSkillsDomain()
        {
        }
        //查询核心技能信息
        public List<UserCoreSkillModel> GetCoreSkillsByUserID(int userID)
        {
            int userInfoID = UserIDToUserInfoID.ToUserInfoID(userID);
            UserCoreSkillsRepository userCoreSkillsRepository = new UserCoreSkillsRepository();
            return userCoreSkillsRepository.GetCoreSkillsByUserID(userInfoID);
        }
    }
}