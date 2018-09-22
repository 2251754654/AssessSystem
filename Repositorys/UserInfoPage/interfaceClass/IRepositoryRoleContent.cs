using System.Collections.Generic;
using Models;

namespace Repositorys
{
    public interface IRepositoryRoleContent
    {
        List<ModelRoleAndJob> FindJobAllRole(int id);
        List<ModelRoleAndJob> FindRoleAllJob();
        List<ModelRoleAndJob> FindRoleAllJob(int id);
        bool Insert(int roleID, int professionalID);
    }
}