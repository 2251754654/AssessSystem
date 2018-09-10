namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUseddddddddddwdwweweweddddddd2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_RoleContent", "RoleID", "dbo.TB_Role");
            AddForeignKey("dbo.TB_RoleContent", "RoleID", "dbo.TB_Role", "RoleID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_RoleContent", "RoleID", "dbo.TB_Role");
            AddForeignKey("dbo.TB_RoleContent", "RoleID", "dbo.TB_Role", "RoleID");
        }
    }
}
