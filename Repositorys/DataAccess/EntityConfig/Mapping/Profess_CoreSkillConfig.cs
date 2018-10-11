using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Repositorys.DataAccess.MappingModule;

namespace Repositorys.DataAccess.EntityConfig.Mapping
{
    public class Profess_CoreSkillConfig : EntityTypeConfiguration<Profess_CoreSkill>
    {
       public Profess_CoreSkillConfig()
        {
            this.HasKey(o=>o.Guid);

            this.HasRequired(o => o.Profess)
               .WithMany(o => o.Profess_CoreSkills)
               .HasForeignKey(o => o.ProfessGuid)
               .WillCascadeOnDelete(false);

            this.HasRequired(o => o.CoreSkill)
                .WithMany(o => o.Profess_CoreSkills)
                .HasForeignKey(o => o.CoreSkillGuid)
                .WillCascadeOnDelete(false);
        }
    }
}
