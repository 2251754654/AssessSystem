using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorys.DataAccess;

namespace Repositorys
{
    public class UserRepository : IUserRepository
    {
        public UserModel LoginCheck(UserModel userModel)
        {
            //根据用户名和密码来查询用户照顾好
            DB_StaffEvaluationEntities dB_StaffEvaluationEntities = new DB_StaffEvaluationEntities();
            var query = from user in dB_StaffEvaluationEntities.TB_User
                        where user.UserName == userModel.UserName && user.UserPassword == userModel.UserPassword
                        select new UserModel() {
                            UserID = user.UserID,
                            UserConfirm = user.UserConfirm,
                            UserLastDate = user.UserLastDate,
                            UserLever = user.UserLever,
                            UserName = user.UserName,
                            UserPassword = user.UserPassword,
                        };
            return query.FirstOrDefault();
        }

        public static void Main(String []args)
        {
            
            Console.Write(new UserRepository().LoginCheck(new UserModel() {  UserName="fubowen", UserPassword= "123"}).UserID+"::::");
            Console.ReadKey();
        }
    }
}