namespace CheckPoint.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameIdNullReview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Review", "GameId", "dbo.Game");
            DropIndex("dbo.Review", new[] { "GameId" });
            AlterColumn("dbo.Review", "GameId", c => c.Int());
            CreateIndex("dbo.Review", "GameId");
            AddForeignKey("dbo.Review", "GameId", "dbo.Game", "GameId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "GameId", "dbo.Game");
            DropIndex("dbo.Review", new[] { "GameId" });
            AlterColumn("dbo.Review", "GameId", c => c.Int(nullable: false));
            CreateIndex("dbo.Review", "GameId");
            AddForeignKey("dbo.Review", "GameId", "dbo.Game", "GameId", cascadeDelete: true);
        }
    }
}
