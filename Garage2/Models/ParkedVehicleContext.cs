using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class ParkedVehicleContext : DbContext
    {
    
        public ParkedVehicleContext() : base("DefaultConnection")
        {
            return;
        }

        public DbSet<ParkedVehicle> ParkedVehicles { get; set; }
    }
}
