using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Repositorys.DataAccess.MappingModule;

namespace Repositorys.DataAccess.EntityConfig.Mapping
{
    public class User_RoleConfig : EntityTypeConfiguration<User_Role>
    {
        public User_RoleConfig()
        {
            this.HasKey(o=>o.Guid);

            this.HasRequired(o => o.User)
                .WithMany(o => o.User_Roles)
                .HasForeignKey(o => o.UserGuid)
                .WillCascadeOnDelete(false);

            this.HasRequired(o => o.Role)
                .WithMany(o => o.User_Roles)
                .HasForeignKey(o => o.RoleGuid)
                .WillCascadeOnDelete(false);
        }
    }
}
