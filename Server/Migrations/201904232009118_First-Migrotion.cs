namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigrotion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GroupMessages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                        MessageSource = c.String(nullable: false, maxLength: 1000),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 30),
                        PasswordHash = c.String(nullable: false, maxLength: 200),
                        DCreate = c.DateTime(nullable: false),
                        LastActivity = c.DateTime(nullable: false),
                        Blocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserInGroups",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        Muted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.GroupID })
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.GroupID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupMessages", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserInGroups", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserInGroups", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.UserInGroups", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.GroupMessages", "GroupID", "dbo.Groups");
            DropIndex("dbo.UserInGroups", new[] { "RoleID" });
            DropIndex("dbo.UserInGroups", new[] { "GroupID" });
            DropIndex("dbo.UserInGroups", new[] { "UserID" });
            DropIndex("dbo.GroupMessages", new[] { "GroupID" });
            DropIndex("dbo.GroupMessages", new[] { "UserID" });
            DropTable("dbo.Roles");
            DropTable("dbo.UserInGroups");
            DropTable("dbo.Users");
            DropTable("dbo.GroupMessages");
            DropTable("dbo.Groups");
        }
    }
}
