using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositoryUserInfo
    {
        bool FakeDelete(int id);
        List<ModelUserInfo> FindAllDeleteUserInfo();
        List<ModelUserInfo> FindAllNotDeleteUserInfo();
        List<ModelUserInfo> FindAllUserInfo();
        ModelUserInfo FindUserInfo(int id);
        bool Insert(ModelUserInfo UserInfo);
        bool ReallyDelete(int id);
        bool Update(ModelUserInfo UserInfo);
    }
}