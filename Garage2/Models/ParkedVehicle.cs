using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Garage2.Models
{
    public enum Types { Car, Bike, Plane, Boat, Truck };

    public class ParkedVehicle
    {
        public int Id { get; set; }
        public Types Type { get; set; }
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumberOfWheels { get; set; }
        public DateTime TimeParked { get; set; }
    }
}