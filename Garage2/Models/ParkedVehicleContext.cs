using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class ParkedVehicleContext : DbContext
    {
        public ParkedVehicleContext() : base("DefaultConnection222")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ParkedVehicleContext>());
            return;
        }

        public DbSet<ParkedVehicle> ParkedVehicles { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}
