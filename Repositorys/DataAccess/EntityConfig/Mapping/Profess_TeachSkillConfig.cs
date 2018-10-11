using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Repositorys.DataAccess.MappingModule;

namespace Repositorys.DataAccess.EntityConfig.Mapping
{
    public class Profess_TeachSkillConfig : EntityTypeConfiguration<Profess_TeachSkill>
    {
       public Profess_TeachSkillConfig()
        {
            this.HasKey(o=>o.Guid);

            this.HasRequired(o => o.Profess)
               .WithMany(o => o.Profess_TeachSkills)
               .HasForeignKey(o => o.ProfessGuid)
               .WillCascadeOnDelete(false);

            this.HasRequired(o => o.TeachSkill)
                .WithMany(o => o.Profess_TeachSkills)
                .HasForeignKey(o => o.TeachSkillGuid)
                .WillCascadeOnDelete(false);
        }
    }
}
