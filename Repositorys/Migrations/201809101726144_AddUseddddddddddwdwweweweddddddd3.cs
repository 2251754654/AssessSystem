namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUseddddddddddwdwweweweddddddd3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_Professional", "ProfessionalDelete", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_Professional", "ProfessionalDelete");
        }
    }
}
