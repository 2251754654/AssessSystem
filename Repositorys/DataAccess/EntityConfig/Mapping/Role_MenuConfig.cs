using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Repositorys.DataAccess.MappingModule;

namespace Repositorys.DataAccess.EntityConfig.Mapping
{
    public class Role_MenuConfig : EntityTypeConfiguration<Role_Menu>
    {
       public Role_MenuConfig()
        {
            this.HasKey(o=>o.Guid);

            this.HasRequired(o => o.Role)
               .WithMany(o => o.Role_Menus)
               .HasForeignKey(o => o.RoleGuid)
               .WillCascadeOnDelete(false);

            this.HasRequired(o => o.Menu)
                .WithMany(o => o.RoleMenus)
                .HasForeignKey(o => o.MenuGuid)
                .WillCascadeOnDelete(false);
        }
    }
}
