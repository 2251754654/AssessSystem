using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Repositorys.DataAccess.AssessModule;

namespace Repositorys.DataAccess.EntityConfig
{
    public class AssessInfoConfig : EntityTypeConfiguration<AssessInfo>
    {
        public AssessInfoConfig()
        {
            this.HasKey(o=>o.Guid);

            this.Property(o => o.AssessItemGuid)
                .IsRequired();

            this.Property(o => o.LeverGuid)
                .IsRequired();

            this.Property(o => o.Message)
                .HasMaxLength(50)
                .IsOptional()
                .IsUnicode();
        }
    }
}
