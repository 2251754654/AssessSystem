namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Script : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_EvaluationInfo", "EvaluationID", "dbo.TB_Evaluation");
            DropForeignKey("dbo.TB_Evaluation", "UserIDBy", "dbo.TB_User");
            DropIndex("dbo.TB_Evaluation", new[] { "UserIDBy" });
            DropIndex("dbo.TB_EvaluationInfo", new[] { "EvaluationID" });
            CreateTable(
                "dbo.Assesses",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        AssessUserGuid = c.Guid(nullable: false),
                        ByAssessUserGuid = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        AssessDigest = c.String(maxLength: 50),
                        VisitCount = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.AssessInfoes",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        AssessGuid = c.Guid(nullable: false),
                        AssessItemGuid = c.Guid(nullable: false),
                        LeverGuid = c.Guid(nullable: false),
                        Message = c.String(maxLength: 50),
                        VisitCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Assesses", t => t.AssessGuid)
                .Index(t => t.AssessGuid);
            
            DropTable("dbo.TB_Evaluation");
            DropTable("dbo.TB_EvaluationInfo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TB_EvaluationInfo",
                c => new
                    {
                        EvaluationInfoID = c.Int(nullable: false, identity: true),
                        SkillsGUID = c.String(nullable: false, maxLength: 50),
                        Lever = c.Int(nullable: false),
                        EvaluationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluationInfoID);
            
            CreateTable(
                "dbo.TB_Evaluation",
                c => new
                    {
                        EvaluationID = c.Int(nullable: false, identity: true),
                        EvaluationDetails = c.String(nullable: false, maxLength: 100),
                        UserIDMain = c.Int(nullable: false),
                        Delete = c.Int(nullable: false),
                        UserIDBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluationID);
            
            DropForeignKey("dbo.AssessInfoes", "AssessGuid", "dbo.Assesses");
            DropIndex("dbo.AssessInfoes", new[] { "AssessGuid" });
            DropTable("dbo.AssessInfoes");
            DropTable("dbo.Assesses");
            CreateIndex("dbo.TB_EvaluationInfo", "EvaluationID");
            CreateIndex("dbo.TB_Evaluation", "UserIDBy");
            AddForeignKey("dbo.TB_Evaluation", "UserIDBy", "dbo.TB_User", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.TB_EvaluationInfo", "EvaluationID", "dbo.TB_Evaluation", "EvaluationID", cascadeDelete: true);
        }
    }
}
