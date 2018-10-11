using Repositorys.DataAccess.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.DataAccess.MappingModule
{
    public class User_Role
    {
        public Guid Guid { get; set; }
        public Guid UserGuid { get; set; }
        public Guid RoleGuid { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
