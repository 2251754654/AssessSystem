using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorys.DataAccess;

namespace Repositorys
{
    public class UserInfoRepository
    {
        public UserInfoModel GetUserInfoModelsByID(int userInfoID)
        {
            DB_StaffEvaluationEntities dB_StaffEvaluationEntities = new DB_StaffEvaluationEntities();
            var query = from userInfo in dB_StaffEvaluationEntities.TB_UserInfo
                        where userInfoID == userInfo.UserInfoID
                        select new UserInfoModel() {
                            UserID = userInfo.UserID,
                            RoleID = userInfo.RoleID,
                            UserCurrentAddress = userInfo.UserCurrentAddress,
                            UserInfoAddress = userInfo.UserInfoAddress,
                            UserInfoAge = userInfo.UserInfoAge,
                            UserInfoBirthday = userInfo.UserInfoBirthday,
                            UserInfoDetails = userInfo.UserInfoDetails,
                            UserInfoEmail = userInfo.UserInfoEmail,
                            UserInfoID = userInfo.UserInfoID,
                            UserInfoName = userInfo.UserInfoName,
                            UserInfoQQ = userInfo.UserInfoQQ,
                            UserInfoWorkPhone = userInfo.UserInfoWorkPhone,
                            UserPhone = userInfo.UserPhone,
                        };
            return query.First();
        }
    }
}
