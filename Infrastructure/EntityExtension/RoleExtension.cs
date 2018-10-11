using Infrastructure.DtoExtension;
using Infrastructure.Exception;
using Repositorys.DataAccess.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityExtension
{
    public static class RoleExtension
    {
        public static RoleDto ToDto(this Role role)
        {
            return new RoleDto() {

                Guid = role.Guid,
                RoleName = role.RoleName,
                Specific = role.Specific,
                CreateTime = role.CreateTime,
                UpdateTime = role.UpdateTime,
                State = role.State,
                VisitCount = role.VisitCount,
            };
        }

        public static Role ToInsertEntity(this Role role)
        {
            if (string.IsNullOrWhiteSpace(role.RoleName)|| role.RoleName.Length > 50)
            {
                throw new FieldIsNullOrEmptyException();
            }
            role.Guid = Guid.NewGuid();
            role.CreateTime = DateTime.Now;
            role.UpdateTime = DateTime.Now;
            role.State = 0;
            role.VisitCount = 0;
            return role;
        }

        public static Role ToUpdateEntity(this Role role,Role newRole)
        {
            role.RoleName = newRole.RoleName;
            role.Specific = newRole.Specific;
            role.UpdateTime = DateTime.Now;
            role.VisitCount = role.VisitCount + 1;
            return role;
        }
    }
}
