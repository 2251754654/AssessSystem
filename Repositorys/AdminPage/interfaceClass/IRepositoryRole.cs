using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositoryRole
    {
        bool FakeDelete(int id);
        List<ModelRole> FindAllDeleteRole();
        List<ModelRole> FindAllNotDeleteRole();
        List<ModelRole> FindAllRole();
        ModelRole FindRole(int id);
        bool Insert(ModelRole modelRole);
        bool ReallyDelete(int id);
        bool Update(ModelRole modelRole);
    }
}