using Domains.Utils;
using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class UserInfoDomain
    {
        public UserInfoModel GetUserInfoModelsByID(int userID)
        {
            //通过UserID查询UserInfoID
            UserInfoRepository userInfoRepository = new UserInfoRepository();
            return userInfoRepository.GetUserInfoModelsByID(UserIDToUserInfoID.ToUserInfoID(userID));
        }
    }
}
