using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositoryUser
    {
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool FakeDelete(int id);
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        List<ModelUser> FindAllUser();
        /// <summary>
        /// 查询登陆用户
        /// </summary>
        /// <returns></returns>
        List<ModelUser> FindLoginUser();
        /// <summary>
        /// 查询未登录用户
        /// </summary>
        /// <returns></returns>
        List<ModelUser> FindLogoutUser();
        bool FingUserNameOrID(ModelUser modelUser);
        ModelUser Login(ModelUser modelUser);
        bool Logout(int id);
        bool RealDelete(int id);
        bool Regist(ModelUser modelUser);
        bool Update(ModelUser modelUser);
    }
}