namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Script1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_CoreLever", "CoreSkillsID", "dbo.TB_CoreSkills");
            DropForeignKey("dbo.TB_MappingCore", "ProfessionalID", "dbo.TB_Professional");
            DropForeignKey("dbo.TB_MappingTeach", "TeachSkillsID", "dbo.TB_TechSkills");
            DropForeignKey("dbo.TB_TeachLever", "TeachSkillsID", "dbo.TB_TechSkills");
            DropForeignKey("dbo.TB_MappingTeach", "ProfessionalID", "dbo.TB_Professional");
            DropForeignKey("dbo.TB_RoleContent", "RoleID", "dbo.TB_Role");
            DropForeignKey("dbo.TB_RoleContent", "ProfessionalID", "dbo.TB_Professional");
            DropForeignKey("dbo.TB_MappingCore", "CoreSkillsID", "dbo.TB_CoreSkills");
            DropIndex("dbo.TB_CoreLever", new[] { "CoreSkillsID" });
            DropIndex("dbo.TB_MappingCore", new[] { "ProfessionalID" });
            DropIndex("dbo.TB_MappingCore", new[] { "CoreSkillsID" });
            DropIndex("dbo.TB_MappingTeach", new[] { "ProfessionalID" });
            DropIndex("dbo.TB_MappingTeach", new[] { "TeachSkillsID" });
            DropIndex("dbo.TB_TeachLever", new[] { "TeachSkillsID" });
            DropIndex("dbo.TB_RoleContent", new[] { "RoleID" });
            DropIndex("dbo.TB_RoleContent", new[] { "ProfessionalID" });
            CreateTable(
                "dbo.CoreLevers",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CoreLeverName = c.String(nullable: false, maxLength: 50),
                        LeverNumber = c.Int(nullable: false),
                        Specific = c.String(maxLength: 100),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        VisitCount = c.Int(nullable: false),
                        CoreSkillGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.CoreSkills", t => t.CoreSkillGuid)
                .Index(t => t.CoreSkillGuid);
            
            CreateTable(
                "dbo.CoreSkills",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CoreSkillName = c.String(nullable: false, maxLength: 50),
                        Specific = c.String(maxLength: 100),
                        State = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        VisitCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Profess_CoreSkill",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        ProfessGuid = c.Guid(nullable: false),
                        CoreSkillGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.CoreSkills", t => t.CoreSkillGuid)
                .ForeignKey("dbo.Professes", t => t.ProfessGuid)
                .Index(t => t.ProfessGuid)
                .Index(t => t.CoreSkillGuid);
            
            CreateTable(
                "dbo.Professes",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        ProfessionalName = c.String(nullable: false, maxLength: 50),
                        Specific = c.String(maxLength: 100),
                        State = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        VisitCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Profess_TeachSkill",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        ProfessGuid = c.Guid(nullable: false),
                        TeachSkillGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Professes", t => t.ProfessGuid)
                .ForeignKey("dbo.TeachSkills", t => t.TeachSkillGuid)
                .Index(t => t.ProfessGuid)
                .Index(t => t.TeachSkillGuid);
            
            CreateTable(
                "dbo.TeachSkills",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        TeachSkillName = c.String(nullable: false, maxLength: 50),
                        Specific = c.String(maxLength: 100),
                        State = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        VisitCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.TeachLevers",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        TeachLeverName = c.String(nullable: false, maxLength: 50),
                        Specific = c.String(maxLength: 100),
                        LeverNumber = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        VisitCount = c.Int(nullable: false),
                        TeachSkillGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.TeachSkills", t => t.TeachSkillGuid)
                .Index(t => t.TeachSkillGuid);
            
            CreateTable(
                "dbo.Role_Profess",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        RoleGuid = c.Guid(nullable: false),
                        ProfessGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Professes", t => t.ProfessGuid)
                .ForeignKey("dbo.Roles", t => t.RoleGuid)
                .Index(t => t.RoleGuid)
                .Index(t => t.ProfessGuid);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        Specific = c.String(maxLength: 100),
                        State = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        VisitCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Role_Menu",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        RoleGuid = c.Guid(nullable: false),
                        MenuGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Menus", t => t.MenuGuid)
                .ForeignKey("dbo.Roles", t => t.RoleGuid)
                .Index(t => t.RoleGuid)
                .Index(t => t.MenuGuid);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        MenuName = c.String(nullable: false, maxLength: 50),
                        Specific = c.String(maxLength: 100),
                        State = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        VisitCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.User_Role",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        RoleGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Roles", t => t.RoleGuid)
                .ForeignKey("dbo.Users", t => t.UserGuid)
                .Index(t => t.UserGuid)
                .Index(t => t.RoleGuid);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        ReigstTime = c.DateTime(nullable: false),
                        LoginTime = c.DateTime(nullable: false),
                        IsActivate = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        VisitCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50),
                        Sex = c.Int(nullable: false),
                        Address = c.String(maxLength: 50),
                        CurrentAddress = c.String(maxLength: 50),
                        Birthday = c.DateTime(),
                        Phone = c.String(maxLength: 20),
                        WorkPhone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        QQ = c.String(maxLength: 20),
                        PersonalProfile = c.String(maxLength: 100),
                        UserGuid = c.Guid(nullable: false),
                        VisitCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Users", t => t.Guid)
                .Index(t => t.Guid);
            
            DropTable("dbo.TB_CoreLever");
            DropTable("dbo.TB_CoreSkills");
            DropTable("dbo.TB_MappingCore");
            DropTable("dbo.TB_Professional");
            DropTable("dbo.TB_MappingTeach");
            DropTable("dbo.TB_TechSkills");
            DropTable("dbo.TB_TeachLever");
            DropTable("dbo.TB_RoleContent");
            DropTable("dbo.TB_Role");
            DropTable("dbo.TB_User");
            DropTable("dbo.TB_UserInfo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TB_UserInfo",
                c => new
                    {
                        UserInfoID = c.Int(nullable: false, identity: true),
                        UserInfoName = c.String(nullable: false, maxLength: 50, unicode: false),
                        UserInfoAge = c.Int(nullable: false),
                        UserInfoAddress = c.String(nullable: false, maxLength: 50),
                        UserInfoBirthday = c.String(nullable: false, maxLength: 50),
                        UserPhone = c.String(nullable: false, maxLength: 50),
                        UserInfoEmail = c.String(nullable: false, maxLength: 50),
                        UserInfoWorkPhone = c.String(nullable: false, maxLength: 50),
                        UserCurrentAddress = c.String(nullable: false, maxLength: 50),
                        UserInfoQQ = c.String(maxLength: 50),
                        UserInfoDetails = c.String(maxLength: 200),
                        UserInfoDelete = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserInfoID);
            
            CreateTable(
                "dbo.TB_User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        UserPassword = c.String(nullable: false, maxLength: 50),
                        UserLastDate = c.String(nullable: false, maxLength: 50),
                        UserLever = c.Int(nullable: false),
                        UserConfirm = c.Int(nullable: false),
                        Login = c.Int(nullable: false),
                        UserDelete = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.TB_Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        RoleDetails = c.String(nullable: false, maxLength: 100),
                        RoleDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.TB_RoleContent",
                c => new
                    {
                        RoleContentID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        ProfessionalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleContentID);
            
            CreateTable(
                "dbo.TB_TeachLever",
                c => new
                    {
                        TeachLeverID = c.Int(nullable: false, identity: true),
                        TeachLeverNum = c.Int(nullable: false),
                        TeachLeverDetails = c.String(nullable: false, maxLength: 100),
                        TeachSkillsID = c.Int(nullable: false),
                        TeachLeverDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeachLeverID);
            
            CreateTable(
                "dbo.TB_TechSkills",
                c => new
                    {
                        TeachSkillsID = c.Int(nullable: false, identity: true),
                        TeachSkillsName = c.String(nullable: false, maxLength: 50),
                        TeachSkillsDetails = c.String(nullable: false, maxLength: 100),
                        TeachSkillsGUID = c.String(nullable: false, maxLength: 50, unicode: false),
                        TeachSkillDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeachSkillsID);
            
            CreateTable(
                "dbo.TB_MappingTeach",
                c => new
                    {
                        MappingID = c.Int(nullable: false, identity: true),
                        ProfessionalID = c.Int(nullable: false),
                        TeachSkillsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MappingID);
            
            CreateTable(
                "dbo.TB_Professional",
                c => new
                    {
                        ProfessionalID = c.Int(nullable: false, identity: true),
                        ProfessionalName = c.String(nullable: false, maxLength: 50),
                        ProfessionalDetails = c.String(maxLength: 200),
                        ProfessionalDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfessionalID);
            
            CreateTable(
                "dbo.TB_MappingCore",
                c => new
                    {
                        MappingID = c.Int(nullable: false, identity: true),
                        ProfessionalID = c.Int(nullable: false),
                        CoreSkillsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MappingID);
            
            CreateTable(
                "dbo.TB_CoreSkills",
                c => new
                    {
                        CoreSkillsID = c.Int(nullable: false, identity: true),
                        CoreSkillsName = c.String(nullable: false, maxLength: 50),
                        CoreSkillsDetails = c.String(nullable: false, maxLength: 100),
                        CoreSkillsGUID = c.String(nullable: false, maxLength: 50, unicode: false),
                        CoreSkillsDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CoreSkillsID);
            
            CreateTable(
                "dbo.TB_CoreLever",
                c => new
                    {
                        CoreLeverID = c.Int(nullable: false, identity: true),
                        CoreLeverNum = c.Int(nullable: false),
                        CoreLeverDetails = c.String(nullable: false, maxLength: 100),
                        CoreSkillsID = c.Int(nullable: false),
                        CoreLeverDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CoreLeverID);
            
            DropForeignKey("dbo.Profess_CoreSkill", "ProfessGuid", "dbo.Professes");
            DropForeignKey("dbo.Role_Profess", "RoleGuid", "dbo.Roles");
            DropForeignKey("dbo.User_Role", "UserGuid", "dbo.Users");
            DropForeignKey("dbo.UserInfoes", "Guid", "dbo.Users");
            DropForeignKey("dbo.User_Role", "RoleGuid", "dbo.Roles");
            DropForeignKey("dbo.Role_Menu", "RoleGuid", "dbo.Roles");
            DropForeignKey("dbo.Role_Menu", "MenuGuid", "dbo.Menus");
            DropForeignKey("dbo.Role_Profess", "ProfessGuid", "dbo.Professes");
            DropForeignKey("dbo.Profess_TeachSkill", "TeachSkillGuid", "dbo.TeachSkills");
            DropForeignKey("dbo.TeachLevers", "TeachSkillGuid", "dbo.TeachSkills");
            DropForeignKey("dbo.Profess_TeachSkill", "ProfessGuid", "dbo.Professes");
            DropForeignKey("dbo.Profess_CoreSkill", "CoreSkillGuid", "dbo.CoreSkills");
            DropForeignKey("dbo.CoreLevers", "CoreSkillGuid", "dbo.CoreSkills");
            DropIndex("dbo.UserInfoes", new[] { "Guid" });
            DropIndex("dbo.User_Role", new[] { "RoleGuid" });
            DropIndex("dbo.User_Role", new[] { "UserGuid" });
            DropIndex("dbo.Role_Menu", new[] { "MenuGuid" });
            DropIndex("dbo.Role_Menu", new[] { "RoleGuid" });
            DropIndex("dbo.Role_Profess", new[] { "ProfessGuid" });
            DropIndex("dbo.Role_Profess", new[] { "RoleGuid" });
            DropIndex("dbo.TeachLevers", new[] { "TeachSkillGuid" });
            DropIndex("dbo.Profess_TeachSkill", new[] { "TeachSkillGuid" });
            DropIndex("dbo.Profess_TeachSkill", new[] { "ProfessGuid" });
            DropIndex("dbo.Profess_CoreSkill", new[] { "CoreSkillGuid" });
            DropIndex("dbo.Profess_CoreSkill", new[] { "ProfessGuid" });
            DropIndex("dbo.CoreLevers", new[] { "CoreSkillGuid" });
            DropTable("dbo.UserInfoes");
            DropTable("dbo.Users");
            DropTable("dbo.User_Role");
            DropTable("dbo.Menus");
            DropTable("dbo.Role_Menu");
            DropTable("dbo.Roles");
            DropTable("dbo.Role_Profess");
            DropTable("dbo.TeachLevers");
            DropTable("dbo.TeachSkills");
            DropTable("dbo.Profess_TeachSkill");
            DropTable("dbo.Professes");
            DropTable("dbo.Profess_CoreSkill");
            DropTable("dbo.CoreSkills");
            DropTable("dbo.CoreLevers");
            CreateIndex("dbo.TB_RoleContent", "ProfessionalID");
            CreateIndex("dbo.TB_RoleContent", "RoleID");
            CreateIndex("dbo.TB_TeachLever", "TeachSkillsID");
            CreateIndex("dbo.TB_MappingTeach", "TeachSkillsID");
            CreateIndex("dbo.TB_MappingTeach", "ProfessionalID");
            CreateIndex("dbo.TB_MappingCore", "CoreSkillsID");
            CreateIndex("dbo.TB_MappingCore", "ProfessionalID");
            CreateIndex("dbo.TB_CoreLever", "CoreSkillsID");
            AddForeignKey("dbo.TB_MappingCore", "CoreSkillsID", "dbo.TB_CoreSkills", "CoreSkillsID");
            AddForeignKey("dbo.TB_RoleContent", "ProfessionalID", "dbo.TB_Professional", "ProfessionalID");
            AddForeignKey("dbo.TB_RoleContent", "RoleID", "dbo.TB_Role", "RoleID", cascadeDelete: true);
            AddForeignKey("dbo.TB_MappingTeach", "ProfessionalID", "dbo.TB_Professional", "ProfessionalID");
            AddForeignKey("dbo.TB_TeachLever", "TeachSkillsID", "dbo.TB_TechSkills", "TeachSkillsID");
            AddForeignKey("dbo.TB_MappingTeach", "TeachSkillsID", "dbo.TB_TechSkills", "TeachSkillsID");
            AddForeignKey("dbo.TB_MappingCore", "ProfessionalID", "dbo.TB_Professional", "ProfessionalID", cascadeDelete: true);
            AddForeignKey("dbo.TB_CoreLever", "CoreSkillsID", "dbo.TB_CoreSkills", "CoreSkillsID");
        }
    }
}
