namespace CustomStrategyGameBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableDetailsRefinedV2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.LoginSessions", new[] { "Login_Session_Id" });
            DropIndex("dbo.GameSessions", new[] { "Session_Id" });
            DropIndex("dbo.TempGameSessions", new[] { "temp_Id" });
            AlterColumn("dbo.LoginSessions", "Login_Session_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SessionGamers", "Session_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.GameSessions", "Session_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TempGameSessions", "temp_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TempGameSessions", "Temp_Session_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.LoginSessions", "Login_Session_Id", unique: true);
            CreateIndex("dbo.GameSessions", "Session_Id", unique: true);
            CreateIndex("dbo.TempGameSessions", "temp_Id", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.TempGameSessions", new[] { "temp_Id" });
            DropIndex("dbo.GameSessions", new[] { "Session_Id" });
            DropIndex("dbo.LoginSessions", new[] { "Login_Session_Id" });
            AlterColumn("dbo.TempGameSessions", "Temp_Session_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.TempGameSessions", "temp_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.GameSessions", "Session_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.SessionGamers", "Session_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.LoginSessions", "Login_Session_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.TempGameSessions", "temp_Id", unique: true);
            CreateIndex("dbo.GameSessions", "Session_Id", unique: true);
            CreateIndex("dbo.LoginSessions", "Login_Session_Id", unique: true);
        }
    }
}
