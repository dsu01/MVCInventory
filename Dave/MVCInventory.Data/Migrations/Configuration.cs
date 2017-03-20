namespace MVCInventory.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using MVCInventory.Domain;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCInventory.Data.InventoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVCInventory.Data.InventoryContext";
        }

        protected override void Seed(MVCInventory.Data.InventoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //The purpose of the Seed method is to enable you to insert or update test data after Code First 
            //context.Buildings.AddOrUpdate(
            //      p => p.BuildingName,
            //      new Building {
            //          BuildingName = "11",
            //          Property = "Bethesda",
            //          IsActive = true
            //      },
            //      new Building {
            //          BuildingName = "12",
            //          Property = "Bethesda",
            //          IsActive = true
            //      },
            //      new Building {
            //          BuildingName = "13",
            //          Property = "Bethesda",
            //          IsActive = true
            //      }
            //    );

            //base.Seed(context);


            //or use the follwing:
            var buildings = new List<Building>
            {
                  new Building {
                      BuildingName = "11",
                      Property = "Bethesda",
                      IsActive = true
                  },
                  new Building {
                      BuildingName = "12",
                      Property = "Bethesda",
                      IsActive = true
                  },
                  new Building {
                      BuildingName = "13",
                      Property = "Bethesda",
                      IsActive = true
                  }
            };

            buildings.ForEach(s => context.Buildings.AddOrUpdate(p => p.BuildingName, s));
            context.SaveChanges();

        }
    }
}
