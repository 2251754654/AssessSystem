using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Repositorys.DataAccess.UserModule;

namespace Repositorys.DataAccess.EntityConfig
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            this.HasKey(o => o.Guid);

            this.Property(o => o.UserName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(true);
                
            this.Property(o => o.Password)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(true);

            this.Property(o => o.ReigstTime)
                .IsRequired();

            this.Property(o => o.LoginTime)
                .IsRequired();

            this.HasOptional(o => o.UserInfo)
                .WithRequired(o => o.User)
                .WillCascadeOnDelete(false);
        }
    }
}
