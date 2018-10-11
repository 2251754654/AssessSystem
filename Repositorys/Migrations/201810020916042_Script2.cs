namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Script2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Professes", "ProfessName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Professes", "ProfessionalName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Professes", "ProfessionalName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Professes", "ProfessName");
        }
    }
}
