using Repositorys.DataAccess.MappingModule;
using Repositorys.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.Repositroy.Specific.Mapping
{
    public class User_RoleRepositroy : GenericRepository<User_Role>,  IUser_RoleRepositroy
    {
    }
}
