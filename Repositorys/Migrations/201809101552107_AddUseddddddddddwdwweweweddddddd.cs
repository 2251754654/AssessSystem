namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUseddddddddddwdwweweweddddddd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_Evaluation", "UserIDMain", "dbo.TB_UserInfo");
            DropForeignKey("dbo.TB_Evaluation", "UserIDBy", "dbo.TB_UserInfo");
            DropIndex("dbo.TB_Evaluation", new[] { "UserIDBy" });
            DropIndex("dbo.TB_Evaluation", new[] { "UserIDMain" });
            AddColumn("dbo.TB_Evaluation", "TB_UserInfo_UserInfoID", c => c.Int());
            AddColumn("dbo.TB_Evaluation", "TB_UserInfo_UserInfoID1", c => c.Int());
            AddColumn("dbo.TB_Evaluation", "TB_UserInfoByItem_UserInfoID", c => c.Int());
            AddColumn("dbo.TB_Evaluation", "TB_UserInfoMainItem_UserInfoID", c => c.Int());
            CreateIndex("dbo.TB_Evaluation", "TB_UserInfo_UserInfoID");
            CreateIndex("dbo.TB_Evaluation", "TB_UserInfo_UserInfoID1");
            CreateIndex("dbo.TB_Evaluation", "TB_UserInfoByItem_UserInfoID");
            CreateIndex("dbo.TB_Evaluation", "TB_UserInfoMainItem_UserInfoID");
            CreateIndex("dbo.TB_UserInfo", "RoleID");
            AddForeignKey("dbo.TB_UserInfo", "RoleID", "dbo.TB_Role", "RoleID", cascadeDelete: true);
            AddForeignKey("dbo.TB_Evaluation", "TB_UserInfoByItem_UserInfoID", "dbo.TB_UserInfo", "UserInfoID");
            AddForeignKey("dbo.TB_Evaluation", "TB_UserInfoMainItem_UserInfoID", "dbo.TB_UserInfo", "UserInfoID");
            AddForeignKey("dbo.TB_Evaluation", "TB_UserInfo_UserInfoID", "dbo.TB_UserInfo", "UserInfoID");
            AddForeignKey("dbo.TB_Evaluation", "TB_UserInfo_UserInfoID1", "dbo.TB_UserInfo", "UserInfoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_Evaluation", "TB_UserInfo_UserInfoID1", "dbo.TB_UserInfo");
            DropForeignKey("dbo.TB_Evaluation", "TB_UserInfo_UserInfoID", "dbo.TB_UserInfo");
            DropForeignKey("dbo.TB_Evaluation", "TB_UserInfoMainItem_UserInfoID", "dbo.TB_UserInfo");
            DropForeignKey("dbo.TB_Evaluation", "TB_UserInfoByItem_UserInfoID", "dbo.TB_UserInfo");
            DropForeignKey("dbo.TB_UserInfo", "RoleID", "dbo.TB_Role");
            DropIndex("dbo.TB_UserInfo", new[] { "RoleID" });
            DropIndex("dbo.TB_Evaluation", new[] { "TB_UserInfoMainItem_UserInfoID" });
            DropIndex("dbo.TB_Evaluation", new[] { "TB_UserInfoByItem_UserInfoID" });
            DropIndex("dbo.TB_Evaluation", new[] { "TB_UserInfo_UserInfoID1" });
            DropIndex("dbo.TB_Evaluation", new[] { "TB_UserInfo_UserInfoID" });
            DropColumn("dbo.TB_Evaluation", "TB_UserInfoMainItem_UserInfoID");
            DropColumn("dbo.TB_Evaluation", "TB_UserInfoByItem_UserInfoID");
            DropColumn("dbo.TB_Evaluation", "TB_UserInfo_UserInfoID1");
            DropColumn("dbo.TB_Evaluation", "TB_UserInfo_UserInfoID");
            CreateIndex("dbo.TB_Evaluation", "UserIDMain");
            CreateIndex("dbo.TB_Evaluation", "UserIDBy");
            AddForeignKey("dbo.TB_Evaluation", "UserIDBy", "dbo.TB_UserInfo", "UserInfoID");
            AddForeignKey("dbo.TB_Evaluation", "UserIDMain", "dbo.TB_UserInfo", "UserInfoID");
        }
    }
}
