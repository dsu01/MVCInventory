namespace MVCInventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                     "dbo.Employees",
                     c => new
                     {
                         Id = c.Int(nullable: false, identity: true),
                         Name = c.String(maxLength: 200),
                         Email = c.String(),
                         Mobile_no = c.String(),
                     })
                     .PrimaryKey(t => t.Id)
                     .Index(t => t.Id);


        }

        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "Id" });
            DropTable("dbo.Employees");
        }
    }
}
