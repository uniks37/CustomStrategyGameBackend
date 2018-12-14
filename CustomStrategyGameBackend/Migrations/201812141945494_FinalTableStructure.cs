namespace CustomStrategyGameBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalTableStructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gamers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Uname = c.String(nullable: false, maxLength: 32),
                        Email_Id = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 64),
                        IsOnline = c.Boolean(nullable: false),
                        Games_Won = c.Long(nullable: false),
                        Games_Lost = c.Long(nullable: false),
                        Games_Total = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Uname, unique: true)
                .Index(t => t.Email_Id, unique: true);
            
            CreateTable(
                "dbo.LoginSessions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login_Session_Id = c.String(nullable: false, maxLength: 128),
                        Gamer_Id = c.Long(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gamers", t => t.Gamer_Id, cascadeDelete: true)
                .Index(t => t.Login_Session_Id, unique: true)
                .Index(t => t.Gamer_Id);
            
            CreateTable(
                "dbo.SessionGamers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Session_Id = c.String(nullable: false, maxLength: 128),
                        Gamer_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gamers", t => t.Gamer_Id, cascadeDelete: true)
                .ForeignKey("dbo.GameSessions", t => t.Gamer_Id, cascadeDelete: true)
                .Index(t => t.Gamer_Id);
            
            CreateTable(
                "dbo.GameSessions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Session_Id = c.String(nullable: false, maxLength: 128),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Board_Id = c.String(maxLength: 128),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Session_Id, unique: true)
                .Index(t => t.Board_Id, unique: true);
            
            CreateTable(
                "dbo.TempGameSessions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        temp_Id = c.String(nullable: false, maxLength: 128),
                        Temp_Session_Id = c.String(nullable: false, maxLength: 128),
                        Gamer1_Id = c.Long(nullable: false),
                        Gamer2_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.temp_Id, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SessionGamers", "Gamer_Id", "dbo.GameSessions");
            DropForeignKey("dbo.SessionGamers", "Gamer_Id", "dbo.Gamers");
            DropForeignKey("dbo.LoginSessions", "Gamer_Id", "dbo.Gamers");
            DropIndex("dbo.TempGameSessions", new[] { "temp_Id" });
            DropIndex("dbo.GameSessions", new[] { "Board_Id" });
            DropIndex("dbo.GameSessions", new[] { "Session_Id" });
            DropIndex("dbo.SessionGamers", new[] { "Gamer_Id" });
            DropIndex("dbo.LoginSessions", new[] { "Gamer_Id" });
            DropIndex("dbo.LoginSessions", new[] { "Login_Session_Id" });
            DropIndex("dbo.Gamers", new[] { "Email_Id" });
            DropIndex("dbo.Gamers", new[] { "Uname" });
            DropTable("dbo.TempGameSessions");
            DropTable("dbo.GameSessions");
            DropTable("dbo.SessionGamers");
            DropTable("dbo.LoginSessions");
            DropTable("dbo.Gamers");
        }
    }
}
