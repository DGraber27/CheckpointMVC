namespace CheckPoint.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameDataFive : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Game", "AverageStarRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "AverageStarRating", c => c.Double(nullable: false));
        }
    }
}
