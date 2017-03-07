namespace MVCInventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuildingName = c.String(),
                        Property = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FacilityName = c.String(),
                        FacilityGroup = c.String(),
                        BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.FacilityAttachments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Data = c.Binary(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        IsActive = c.Boolean(),
                        Title = c.String(),
                        FacilityId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facilities", t => t.FacilityId, cascadeDelete: true)
                .Index(t => t.FacilityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacilityAttachments", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.Facilities", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.FacilityAttachments", new[] { "FacilityId" });
            DropIndex("dbo.Facilities", new[] { "BuildingId" });
            DropTable("dbo.FacilityAttachments");
            DropTable("dbo.Facilities");
            DropTable("dbo.Buildings");
        }
    }
}
