using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Garage2.Content;

namespace Garage2.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        public Member Owner { get; set; }
        public VehicleType Type { get; set; }
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumberOfWheels { get; set; }
        public DateTime TimeParked { get; set; }
    }
}