using Repositorys.DataAccess.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Repositorys.DataAccess.MappingModule
{
    public class Role_Menu
    {
        public Guid Guid { get; set; }
        public Guid RoleGuid { get; set; }
        public Guid MenuGuid { get; set; }

        public virtual Role Role { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
