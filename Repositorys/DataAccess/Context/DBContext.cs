using Repositorys.DataAccess.AssessModule;
using Repositorys.DataAccess.EntityConfig;
using Repositorys.DataAccess.EntityConfig.Mapping;
using Repositorys.DataAccess.MappingModule;
using Repositorys.DataAccess.ProfessModule;
using Repositorys.DataAccess.UserModule;
using System.Data.Entity;


namespace Repositorys.DataAccess.Context
{

    public  class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }
        //账户模块
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Role_Menu> Role_Menu { get; set; }
        public virtual DbSet<User_Role> User_Role { get; set; }
        public virtual DbSet<Role_Profess> Role_Profess { get; set; }
        //职业模块
        public virtual DbSet<Profess> Profess { get; set; }
        public virtual DbSet<CoreSkill> CoreSkill { get; set; }
        public virtual DbSet<TeachSkill> TeachSkill { get; set; }
        public virtual DbSet<CoreLever> CoreLever { get; set; }
        public virtual DbSet<TeachLever> TeachLever { get; set; }
        public virtual DbSet<Profess_CoreSkill> Profess_CoreSkill { get; set; }
        public virtual DbSet<Profess_TeachSkill> Profess_TeachSkill { get; set; }
        //评估模块
        public virtual DbSet<Assess> Assess { get; set; }
        public virtual DbSet<AssessInfo> AssessInfo { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //用户模块
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new UserInfoConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new MenuConfig());
            modelBuilder.Configurations.Add(new User_RoleConfig());
            modelBuilder.Configurations.Add(new Role_MenuConfig());
            modelBuilder.Configurations.Add(new Role_ProfessConfig());
            //职业模块
            modelBuilder.Configurations.Add(new ProfessConfig());
            modelBuilder.Configurations.Add(new CoreSkillConfig());
            modelBuilder.Configurations.Add(new CoreLeverConfig());
            modelBuilder.Configurations.Add(new TeachSkillConfig());
            modelBuilder.Configurations.Add(new TeachLeverConfig());
            modelBuilder.Configurations.Add(new Profess_CoreSkillConfig());
            modelBuilder.Configurations.Add(new Profess_TeachSkillConfig());
            //评论模块
            modelBuilder.Configurations.Add(new AssessConfig());
            modelBuilder.Configurations.Add(new AssessInfoConfig());

        }
    }
}
