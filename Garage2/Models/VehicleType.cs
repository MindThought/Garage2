using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garage2.Content;

namespace Garage2.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public Types Type { get; set; }
        public virtual ICollection<ParkedVehicle> VehiclesOfType { get; set; }
    }
}