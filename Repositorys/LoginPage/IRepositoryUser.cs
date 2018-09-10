using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositoryUser
    {
        bool FakeDelete(int id);
        List<ModelUser> FindAllUser();
        List<ModelUser> FindLoginUser();
        List<ModelUser> FindLogoutUser();
        bool FingUserNameOrID(ModelUser modelUser);
        ModelUser Login(ModelUser modelUser);
        bool Logout(int id);
        bool RealDelete(int id);
        bool Regist(ModelUser modelUser);
        bool Update(ModelUser modelUser);
    }
}