namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Script : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_User", "TB_UserInfo_UserInfoID", "dbo.TB_UserInfo");
            DropForeignKey("dbo.TB_Evaluation", "UserIDBy", "dbo.TB_User");
            DropIndex("dbo.TB_User", new[] { "TB_UserInfo_UserInfoID" });
            DropIndex("dbo.TB_Evaluation", new[] { "UserIDBy" });
            AddColumn("dbo.TB_Evaluation", "TB_User_UserID", c => c.Int());
            CreateIndex("dbo.TB_Evaluation", "TB_User_UserID");
            AddForeignKey("dbo.TB_Evaluation", "TB_User_UserID", "dbo.TB_User", "UserID");
            DropColumn("dbo.TB_User", "TB_UserInfo_UserInfoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_User", "TB_UserInfo_UserInfoID", c => c.Int());
            DropForeignKey("dbo.TB_Evaluation", "TB_User_UserID", "dbo.TB_User");
            DropIndex("dbo.TB_Evaluation", new[] { "TB_User_UserID" });
            DropColumn("dbo.TB_Evaluation", "TB_User_UserID");
            CreateIndex("dbo.TB_Evaluation", "UserIDBy");
            CreateIndex("dbo.TB_User", "TB_UserInfo_UserInfoID");
            AddForeignKey("dbo.TB_Evaluation", "UserIDBy", "dbo.TB_User", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.TB_User", "TB_UserInfo_UserInfoID", "dbo.TB_UserInfo", "UserInfoID");
        }
    }
}
