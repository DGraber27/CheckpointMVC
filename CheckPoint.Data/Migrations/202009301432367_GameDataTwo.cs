namespace CheckPoint.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameDataTwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "AverageStarRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "AverageStarRating");
        }
    }
}
