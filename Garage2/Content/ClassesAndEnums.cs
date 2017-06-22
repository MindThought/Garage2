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
            TimeSpan epsilon = new TimeSpan(0, 0, 0, 1);
            if (DateTime.Now - this.StartTime < epsilon)
            {
            }
            else
            {
                this.EndTime = DateTime.Now;
            }
            this.Type = parkedVehicle.Type.Type;
            this.RegistrationNumber = parkedVehicle.RegistrationNumber;
            this.HourlyRate = 100;
        }

        public int CalculateCost()
        {
            return HourlyRate * (int)Math.Ceiling((EndTime - StartTime).TotalHours);
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Types Type { get; set; }
        public string RegistrationNumber { get; set; }
        public int HourlyRate { get; set; }
    }

    public class Stats
    {
        public int CarsParked { get; set; }
        public int BikesParked { get; set; }
        public int PlanesParked { get; set; }
        public int BoatsParked { get; set; }
        public int TrucksParked { get; set; }
        public int TotalNumberOfWheels { get; set; }
        public int TotalCost { get; set; }
    }
}