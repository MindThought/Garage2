using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Content
{
    public enum Types { Car, Bike, Plane, Boat, Truck };

    public class Reciept
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Types Type { get; set; }
        public string RegistrationNumber { get; set; }
        public int HourlyRate { get; set; }
    }
}