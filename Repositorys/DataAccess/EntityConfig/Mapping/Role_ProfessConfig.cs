using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Repositorys.DataAccess.MappingModule;

namespace Repositorys.DataAccess.EntityConfig.Mapping
{
    public class Role_ProfessConfig : EntityTypeConfiguration<Role_Profess>
    {
       public Role_ProfessConfig()
        {
            this.HasKey(o=>o.Guid);

            this.HasRequired(o => o.Role)
               .WithMany(o => o.Role_Professs)
               .HasForeignKey(o => o.RoleGuid)
               .WillCascadeOnDelete(false);

            this.HasRequired(o => o.Profess)
                .WithMany(o => o.Role_Professs)
                .HasForeignKey(o => o.ProfessGuid)
                .WillCascadeOnDelete(false);
        }
    }
}
