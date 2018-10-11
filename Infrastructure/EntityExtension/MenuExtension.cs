using Infrastructure.DtoExtension;
using Repositorys.DataAccess.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityExtension
{
    public static class MenuExtension
    {
        public static MenuDto ToDto(this Menu menu)
        {
            return new MenuDto() {


            };
        }

        public static Menu ToInsertEntity(this Menu  menu)
        {
            return null;
        }

        public static Menu ToUpdateEntity(this Menu role, Menu newRole)
        {
            return null;
        }
    }
}
