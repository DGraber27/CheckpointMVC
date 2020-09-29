namespace CheckPoint.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewGame : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Review", "PlatformId", "dbo.Platform");
            DropIndex("dbo.Review", new[] { "PlatformId" });
            RenameColumn(table: "dbo.Review", name: "PlatformId", newName: "Platform_PlatformId");
            AlterColumn("dbo.Review", "Platform_PlatformId", c => c.Int());
            CreateIndex("dbo.Review", "Platform_PlatformId");
            AddForeignKey("dbo.Review", "Platform_PlatformId", "dbo.Platform", "PlatformId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "Platform_PlatformId", "dbo.Platform");
            DropIndex("dbo.Review", new[] { "Platform_PlatformId" });
            AlterColumn("dbo.Review", "Platform_PlatformId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Review", name: "Platform_PlatformId", newName: "PlatformId");
            CreateIndex("dbo.Review", "PlatformId");
            AddForeignKey("dbo.Review", "PlatformId", "dbo.Platform", "PlatformId", cascadeDelete: true);
        }
    }
}
