using MVCInventory.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Facility>()
        //            .Property(e => e.FacilityGroup).HasColumnAnnotation(IndexAnnotation.AnnotationName,
        //            new IndexAnnotation(new IndexAttribute()));
        //}
    }
}
