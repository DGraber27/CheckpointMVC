namespace CheckPoint.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameImage : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.GameImageID)
                .ForeignKey("dbo.Game", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID);
            
            DropColumn("dbo.Game", "GameImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "GameImage", c => c.Binary());
            DropForeignKey("dbo.GameImage", "GameID", "dbo.Game");
            DropIndex("dbo.GameImage", new[] { "GameID" });
            DropTable("dbo.GameImage");
        }
    }
}
