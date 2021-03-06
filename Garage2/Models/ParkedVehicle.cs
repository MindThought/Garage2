﻿    using System;
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
        public virtual Member Owner { get; set; }
        public int MemberId { get; set; }

        public virtual VehicleType Type { get; set; }

        public int VehicleTypeId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumberOfWheels { get; set; }
        public DateTime TimeParked { get; set; }


    }
}