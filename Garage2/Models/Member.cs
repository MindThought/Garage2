﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        virtual public List<ParkedVehicle> VehiclesParked { get; set; }
    }
}