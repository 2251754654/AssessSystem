using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Repositorys.DataAccess.UserModule;

namespace Repositorys.DataAccess.EntityConfig
{
    public class MenuConfig : EntityTypeConfiguration<Menu>
    {
        public MenuConfig()
        {
            this.HasKey(o => o.Guid);

            this.Property(o => o.MenuName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(true);

            this.Property(o => o.Specific)
                .HasMaxLength(100)
                .IsOptional()
                .IsUnicode(true);

            this.Property(o => o.CreateTime)
                .IsRequired();

            this.Property(o => o.UpdateTime)
                .IsRequired();
        }
    }
}
