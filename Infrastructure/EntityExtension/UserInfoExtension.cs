using Infrastructure.DtoExtension;
using Repositorys.DataAccess.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityExtension
{
    public static class UserInfoExtension
    {
        public static UserInfoDto ToDto(this UserInfo userInfo)
        {
            return new UserInfoDto() { };
        }

        public static UserInfo ToEntityUpdate(this UserInfo userInfo)
        {
            return new UserInfo() { };
        }
    }
}
