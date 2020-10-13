namespace CheckPoint.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OwnerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Review", "OwnerId");
        }
    }
}
