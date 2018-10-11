using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Repositorys.DataAccess.UserModule;

namespace Repositorys.DataAccess.EntityConfig
{
    public class UserInfoConfig:EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfig()
        {
            this.HasKey(o => o.Guid);

            this.Property(o => o.Name)
                .HasMaxLength(50)
                .IsOptional()
                .IsUnicode();

            this.Property(o => o.Birthday)
               .IsOptional();

            this.Property(o => o.Address)
               .HasMaxLength(50)
               .IsOptional()
               .IsUnicode();

            this.Property(o => o.CurrentAddress)
               .HasMaxLength(50)
               .IsOptional()
               .IsUnicode();

            this.Property(o => o.Email)
               .HasMaxLength(50)
               .IsOptional()
               .IsUnicode();

            this.Property(o => o.PersonalProfile)
               .HasMaxLength(100)
               .IsOptional()
               .IsUnicode();

            this.Property(o => o.Phone)
              .HasMaxLength(20)
              .IsOptional()
              .IsUnicode();

            this.Property(o => o.QQ)
              .HasMaxLength(20)
              .IsOptional()
              .IsUnicode();

            this.Property(o => o.WorkPhone)
             .HasMaxLength(20)
             .IsOptional()
             .IsUnicode();
        }
    }
}
