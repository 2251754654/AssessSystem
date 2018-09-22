using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorys.DataAccess;
using ProjectUtils;

namespace Repositorys
{
    public class RepositoryUserInfo : IRepositoryUserInfo
    {
        private readonly DBContext dbContext = new DBContext();

        /// <summary>
        /// 根据用户ID获得用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ModelUserInfo FindUserInfo(int id)
        {
            var tBUserInfo = dbContext.TB_UserInfo.Where(o=>o.UserID == id).FirstOrDefault();
            var modelUserInfo = new ModelUserInfo();
            if (UtilClass.Convert(tBUserInfo, modelUserInfo))
            {
                return modelUserInfo;
            }
            return null;
        }
        /// <summary>
        /// 获得所有用户信息
        /// </summary>
        /// <returns></returns>
        public List<ModelUserInfo> FindAllUserInfo()
        {
            var tBUserInfo = dbContext.TB_UserInfo.ToList();
            var UserInfoList = new List<ModelUserInfo>();
            if (tBUserInfo != null)
            {
                foreach (var tBUserInfoItem in tBUserInfo)
                {
                    var UserInfoListItem = new ModelUserInfo();
                    UtilClass.Convert(tBUserInfoItem, UserInfoListItem);
                    UserInfoList.Add(UserInfoListItem);
                }
                return UserInfoList;
            }
            return null;
        }
        /// <summary>
        /// 获得所有已经删除用户信息
        /// </summary>
        /// <returns></returns>
        public List<ModelUserInfo> FindAllDeleteUserInfo()
        {
            var tBUserInfo = dbContext.TB_UserInfo.Where(o=>o.UserInfoDelete == 0).ToList();
            var UserInfoList = new List<ModelUserInfo>();
            if (tBUserInfo != null)
            {
                foreach (var tBUserInfoItem in tBUserInfo)
                {
                    var UserInfoListItem = new ModelUserInfo();
                    UtilClass.Convert(tBUserInfoItem, UserInfoListItem);
                    UserInfoList.Add(UserInfoListItem);
                }
                return UserInfoList;
            }
            return null;
        }
        /// <summary>
        /// 获得所有未删除用户信息
        /// </summary>
        /// <returns></returns>
        public List<ModelUserInfo> FindAllNotDeleteUserInfo()
        {
            var tBUserInfo = dbContext.TB_UserInfo.Where(o => o.UserInfoDelete == 1).ToList();
            var UserInfoList = new List<ModelUserInfo>();
            if (tBUserInfo != null)
            {
                foreach (var tBUserInfoItem in tBUserInfo)
                {
                    var UserInfoListItem = new ModelUserInfo();
                    UtilClass.Convert(tBUserInfoItem, UserInfoListItem);
                    UserInfoList.Add(UserInfoListItem);
                }
                return UserInfoList;
            }
            return null;
        }
        /// <summary>
        /// 插入用户信息
        /// </summary>
        /// <param name="UserInfo"></param>
        /// <returns></returns>
        public bool Insert(ModelUserInfo UserInfo)
        {
            var tBUserInfo = new TB_UserInfo();
            UtilClass.Convert(UserInfo, tBUserInfo);
            dbContext.TB_UserInfo.Add(tBUserInfo);
            
            if (dbContext.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 更具UserID更新用户信息
        /// </summary>
        /// <param name="UserInfo"></param>
        /// <returns></returns>
        public bool Update(ModelUserInfo UserInfo)
        {
            var tBUserInfo = dbContext.TB_UserInfo.Where(o => o.UserID == UserInfo.UserID).FirstOrDefault();
            UtilClass.Convert(UserInfo, tBUserInfo);

            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 逻辑删除
        /// 根据用户信息表ID删除用户信息
        /// </summary>
        /// <param name="UserInfo"></param>
        /// <returns></returns>
        public bool FakeDelete(int id)
        {
            var tBUserInfo = dbContext.TB_UserInfo.Find(id);
            if (tBUserInfo != null)
            {
                if (tBUserInfo.UserInfoDelete != 0)
                {
                    tBUserInfo.UserInfoDelete = 0;
                    try
                    {
                        dbContext.SaveChanges();
                    }
                    catch
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }
        /// <summary>
        /// 物理删除
        /// 根据用户信息表ID删除用户信息
        /// </summary>
        /// <param name="UserInfo"></param>
        /// <returns></returns>
        public bool ReallyDelete(int id)
        {
            var tBUserInfo = dbContext.TB_UserInfo.Find(id);
            if (tBUserInfo != null)
            {
                dbContext.TB_UserInfo.Remove(tBUserInfo);
                if (dbContext.SaveChanges()>0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }

    }
}
