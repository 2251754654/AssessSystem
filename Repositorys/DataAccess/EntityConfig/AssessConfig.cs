using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Repositorys.DataAccess.AssessModule;

namespace Repositorys.DataAccess.EntityConfig
{
    public class AssessConfig : EntityTypeConfiguration<Assess>
    {
        public AssessConfig()
        {
            this.HasKey(o=>o.Guid);

            this.Property(o => o.AssessUserGuid)
                .IsRequired();

            this.Property(o => o.ByAssessUserGuid)
                .IsRequired();

            this.Property(o => o.CreateTime)
                .IsRequired();

            this.Property(o => o.UpdateTime)
                .IsRequired();

            this.Property(o => o.AssessDigest)
                .HasMaxLength(50)
                .IsOptional()
                .IsUnicode();

            this.HasMany(o => o.AssessInfos)
                .WithRequired(o=>o.Assess)
                .HasForeignKey(o => o.AssessGuid)
                .WillCascadeOnDelete(false);
        }
    }
}
