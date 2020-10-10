namespace CheckPoint.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameImageTableRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameImage", "GameID", "dbo.Game");
            DropIndex("dbo.GameImage", new[] { "GameID" });
            AddColumn("dbo.Game", "GameImage", c => c.Binary());
            DropTable("dbo.GameImage");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GameImage",
                c => new
                    {
                        GameImageID = c.Int(nullable: false, identity: true),
                        GameID = c.Int(nullable: false),
                        FileName = c.String(),
                        FileContent = c.Binary(),
                        FileType = c.String(),
                        FileSize = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.GameImageID);
            
            DropColumn("dbo.Game", "GameImage");
            CreateIndex("dbo.GameImage", "GameID");
            AddForeignKey("dbo.GameImage", "GameID", "dbo.Game", "GameId", cascadeDelete: true);
        }
    }
}
