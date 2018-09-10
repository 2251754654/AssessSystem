namespace Repositorys.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }
        public virtual DbSet<TB_CoreLever> TB_CoreLever { get; set; }
        public virtual DbSet<TB_CoreSkills> TB_CoreSkills { get; set; }
        public virtual DbSet<TB_Evaluation> TB_Evaluation { get; set; }
        public virtual DbSet<TB_EvaluationInfo> TB_EvaluationInfo { get; set; }
        public virtual DbSet<TB_MappingCore> TB_MappingCore { get; set; }
        public virtual DbSet<TB_MappingTeach> TB_MappingTeach { get; set; }
        public virtual DbSet<TB_Professional> TB_Professional { get; set; }
        public virtual DbSet<TB_Role> TB_Role { get; set; }
        public virtual DbSet<TB_RoleContent> TB_RoleContent { get; set; }
        public virtual DbSet<TB_TeachLever> TB_TeachLever { get; set; }
        public virtual DbSet<TB_TechSkills> TB_TechSkills { get; set; }
        public virtual DbSet<TB_User> TB_User { get; set; }
        public virtual DbSet<TB_UserInfo> TB_UserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<TB_CoreSkills>()
                .Property(e => e.CoreSkillsGUID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_CoreSkills>()
                .HasMany(e => e.TB_CoreLever)
                .WithRequired(e => e.TB_CoreSkills)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_CoreSkills>()
                .HasMany(e => e.TB_MappingCore)
                .WithRequired(e => e.TB_CoreSkills)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_Evaluation>()
                .HasMany(e => e.TB_EvaluationInfoList)
                .WithRequired(e => e.TB_Evaluation)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TB_Professional>()
                .HasMany(e => e.TB_MappingCore)
                .WithRequired(e => e.TB_Professional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_Professional>()
                .HasMany(e => e.TB_MappingTeach)
                .WithRequired(e => e.TB_Professional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_Professional>()
                .HasMany(e => e.TB_RoleContent)
                .WithRequired(e => e.TB_Professional)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TB_Role>()
                .HasMany(e => e.TB_RoleContent)
                .WithRequired(e => e.TB_Role)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TB_RoleContent>()
               .HasRequired(o => o.TB_Professional)
               .WithMany(o=>o.TB_RoleContent)
               .HasForeignKey(o => o.ProfessionalID)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_TechSkills>()
                .Property(e => e.TeachAkillsGUID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TechSkills>()
                .HasMany(e => e.TB_MappingTeach)
                .WithRequired(e => e.TB_TechSkills)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_TechSkills>()
                .HasMany(e => e.TB_TeachLever)
                .WithRequired(e => e.TB_TechSkills)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_User>()
                .HasMany(e => e.TB_UserInfo)
                .WithRequired(e => e.TB_User)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TB_UserInfo>()
                .Property(e => e.UserInfoName)
                .IsUnicode(false);

      
        }
    }
}
