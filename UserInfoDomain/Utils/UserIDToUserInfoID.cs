using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorys.DataAccess;

namespace Domains.Utils
{
    class UserIDToUserInfoID
    {
        public static int ToUserInfoID(int userID)
        {
            DB_StaffEvaluationEntities dB_StaffEvaluationEntities = new DB_StaffEvaluationEntities();
            var query = from userInfo in dB_StaffEvaluationEntities.TB_UserInfo
                        where userID == userInfo.UserID
                        select userInfo.UserInfoID;
            return query.First();
        }
    }
}
