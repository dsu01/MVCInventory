using MVCInventory.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInventory.Data
{
    public class InventoryContext: DbContext
    {
        public InventoryContext() : base("InventoryContextConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<FacilityAttachment> FacilityAttachments { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
