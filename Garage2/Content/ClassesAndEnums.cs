using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garage2.Models;

namespace Garage2.Content
{
    public enum Types { Car, Bike, Plane, Boat, Truck };

    public class Reciept
    {
        public Reciept()
        {
                
        }
        public Reciept(ParkedVehicle parkedVehicle)
        {
            this.StartTime = parkedVehicle.TimeParked;
            this.EndTime = DateTime.Now;
            this.Type = parkedVehicle.Type;
            this.RegistrationNumber = parkedVehicle.RegistrationNumber;
            this.HourlyRate = 100;
        }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Types Type { get; set; }
        public string RegistrationNumber { get; set; }
        public int HourlyRate { get; set; }
    }
}