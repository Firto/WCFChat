namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3Migrtiooon : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "PasswordHash", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PasswordHash", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
