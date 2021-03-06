namespace MVCInventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActiveFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings", "IsActive");
        }
    }
}
