namespace MVCInventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemployeeindex : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(),
                        mobile_no = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
