using System.Collections.Generic;
using Models;

namespace Domains
{
    public interface IDomainRole
    {
        List<ModelRole> FindAllRole();
        ModelRole FindRole(int roleID);
        bool InsertRole(ModelRole modelRol);
        bool UpdateRole(ModelRole modelRole);
        bool DeleteRole(int roleID);
        bool InsertRoleProfessional(int roleID, int professionalID);
    }
}