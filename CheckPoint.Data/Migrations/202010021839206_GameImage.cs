namespace CheckPoint.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "GameImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "GameImage");
        }
    }
}
