namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Friend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInGroups", "FriendID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInGroups", "FriendID");
        }
    }
}
