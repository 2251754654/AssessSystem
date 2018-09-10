using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorys.DataAccess;
using ProjectUtilsns;

namespace Repositorys
{
    public class RepositoryUser : IRepositoryUser
    {
        private  readonly DBContext dbContext = new DBContext();

        /// <summary>
        /// 登陆验证
        /// 如果账号已经登陆返回为null
        /// </summary>
        /// <param name="modelUser"></param>
        /// <returns></returns>
        public ModelUser Login(ModelUser modelUser)
        {
            //根据用户名和密码来查询用户
            var user = new ModelUser();
            var result = dbContext.TB_User.Where(o=>o.UserName == modelUser.UserName && o.UserPassword == modelUser.UserPassword).FirstOrDefault();
            if (result != null)
            {
                result.Login = 1;
                if (dbContext.SaveChanges() > 0)
                {
                    UtilClass.Convert(result, user);
                    return user;
                }
                return null;
            }
            return null;
        }
        /// <summary>
        /// 退出系统
        /// 如果账号已经登陆返回为null
        /// </summary>
        /// <param name="modelUser"></param>
        /// <returns></returns>
        public bool Logout(int id)
        {
            //根据用户名和密码来查询用户
            var result = dbContext.TB_User.Find(id);
            if(result.Login != 0)
            {
                result.Login = 0;
                try
                {
                    dbContext.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
                 
            }
            return true;
        }
        /// <summary>
        /// 获得所有已登陆用户1登陆，0未登录
        /// </summary>
        /// <returns></returns>
        public List<ModelUser> FindLoginUser()
        {

            var result = dbContext.TB_User.Where(o => o.Login == 1).ToList(); ;
            //转换目标
            List<ModelUser> userList = new List<ModelUser>();
            //转换
            foreach (var tB_User in result)
            {
                var userModel = new ModelUser();
                UtilClass.Convert(tB_User,userModel);
                userList.Add(userModel);
            }
            return userList;
        }
        /// <summary>
        /// 获得系统中所有用户
        /// </summary>
        /// <returns></returns>
        public List<ModelUser> FindAllUser()
        {
            var result = dbContext.TB_User.ToList();
            //转换目标
            List<ModelUser> userList = new List<ModelUser>();
            //转换
            foreach (var tB_User in result)
            {
                var userModel = new ModelUser();
                UtilClass.Convert(tB_User, userModel);
                userList.Add(userModel);
            }
            return userList;
        }
        /// <summary>
        /// 获得所有未登录用户
        /// </summary>
        /// <returns></returns>
        public List<ModelUser> FindLogoutUser()
        {
            var result = dbContext.TB_User.Where(o => o.Login == 0).ToList(); ;
            //转换目标
            List<ModelUser> userList = new List<ModelUser>();
            //转换
            foreach (var tB_User in result)
            {
                var userModel = new ModelUser();
                UtilClass.Convert(tB_User, userModel);
                userList.Add(userModel);
            }
            return userList;
        }
        /// <summary>
        /// 获得系统中有没有此账号或者ID
        /// </summary>
        /// <param name="modelUser"></param>
        /// <returns></returns>
        public bool FingUserNameOrID(ModelUser modelUser)
        {
            var result = dbContext.TB_User.Where(o=>o.UserName == modelUser.UserName || o.UserID == modelUser.UserID);
            if (result != null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 添加系统用户
        /// </summary>
        /// <param name="modelUser"></param>
        /// <returns></returns>
        public bool Regist(ModelUser modelUser)
        {
            var tB_User = new TB_User();
            UtilClass.Convert(modelUser,tB_User);
            var result = dbContext.TB_User.Add(tB_User);
            if (dbContext.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 更新系统用户
        /// </summary>
        /// <param name="modelUser"></param>
        /// <returns></returns>
        public bool Update(ModelUser modelUser)
        {
            var result = dbContext.TB_User.Find(modelUser.UserID);
            if (result != null)
            {
                UtilClass.Convert(modelUser, result);
                if (dbContext.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// 逻辑删除系统用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FakeDelete(int id)
        {
            var result = dbContext.TB_User.Find(id);
            if (result.UserDelete!=0)
            {
                result.UserDelete = 0;
                dbContext.SaveChanges();
            }
            return true;
        }
        /// <summary>
        /// 物理删除系统用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RealDelete(int id)
        {
            var result = dbContext.TB_User.Include("TB_UserInfo").Where(o=>o.UserID == id).FirstOrDefault();
            if (result != null)
            {
                dbContext.TB_User.Remove(result);
                if (dbContext.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}