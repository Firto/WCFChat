namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2Migrotion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Email");
        }
    }
}
