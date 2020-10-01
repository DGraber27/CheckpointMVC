namespace CheckPoint.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Platform", "Game_GameId", "dbo.Game");
            DropForeignKey("dbo.Game", "Platform_PlatformId1", "dbo.Platform");
            DropIndex("dbo.Game", new[] { "Platform_PlatformId1" });
            DropIndex("dbo.Platform", new[] { "Game_GameId" });
            DropColumn("dbo.Game", "PlatformId");
            DropColumn("dbo.Game", "Platform_PlatformId1");
            DropColumn("dbo.Platform", "Game_GameId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Platform", "Game_GameId", c => c.Int());
            AddColumn("dbo.Game", "Platform_PlatformId1", c => c.Int());
            AddColumn("dbo.Game", "PlatformId", c => c.Int(nullable: false));
            CreateIndex("dbo.Platform", "Game_GameId");
            CreateIndex("dbo.Game", "Platform_PlatformId1");
            AddForeignKey("dbo.Game", "Platform_PlatformId1", "dbo.Platform", "PlatformId");
            AddForeignKey("dbo.Platform", "Game_GameId", "dbo.Game", "GameId");
        }
    }
}
