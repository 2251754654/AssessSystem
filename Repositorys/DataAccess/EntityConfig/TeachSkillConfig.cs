﻿
using Repositorys.DataAccess.ProfessModule;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.DataAccess.EntityConfig
{
    public class TeachSkillConfig : EntityTypeConfiguration<TeachSkill>
    {
        public TeachSkillConfig()
        {
            this.HasKey(o=>o.Guid);

            this.Property(o => o.TeachSkillName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(true);

            this.Property(o => o.Specific)
                .HasMaxLength(100)
                .IsOptional()
                .IsUnicode(true);

            this.Property(o => o.UpdateTime)
                .IsRequired();

            this.Property(o => o.CreateTime)
                .IsRequired();

            this.HasMany(o => o.TeachLevers)
                .WithRequired(o => o.TeachSkill)
                .HasForeignKey(o => o.TeachSkillGuid)
                .WillCascadeOnDelete(false);
        }
    }
}
