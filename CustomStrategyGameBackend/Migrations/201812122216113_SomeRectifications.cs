namespace CustomStrategyGameBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeRectifications : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gamers", "Password", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gamers", "Password", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
