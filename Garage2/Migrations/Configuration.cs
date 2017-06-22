namespace Garage2.Migrations
{
    using System.Data.Entity.Migrations;
    using Garage2.Content;
    using Garage2.Models;
    using System;

    internal sealed class Configuration : DbMigrationsConfiguration<ParkedVehicleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ParkedVehicleContext context)
        {
            //Initialize types
            context.VehicleTypes.AddOrUpdate(
                p => p.Type,
                new VehicleType { Type = Types.Car },
                new VehicleType { Type = Types.Boat },
                new VehicleType { Type = Types.Bike },
                new VehicleType { Type = Types.Plane },
                new VehicleType { Type = Types.Truck }
                );
            context.SaveChanges();
            //Initialize members
            context.Members.AddOrUpdate(
                p => p.Name,
                new Member { Name = "Stefan" },
                new Member { Name = "Gregor" },
                new Member { Name = "Albin" },
                new Member { Name = "Niklas" },
                new Member { Name = "Edvard" },
                new Member { Name = "Elen" },
                new Member { Name = "Lena" },
                new Member { Name = "Mirjam" },
                new Member { Name = "Emma" }
                );
            context.SaveChanges();
            //Initialize vehicles
            context.ParkedVehicles.AddOrUpdate(
                p => p.Type,
                new ParkedVehicle { RegistrationNumber = "abc123", Color = "red", Brand = "volvo", Model = "s80", NumberOfWheels = 4, TimeParked = DateTime.Today, MemberId = 1, VehicleTypeId = 1 },
                new ParkedVehicle { RegistrationNumber = "BAC432", Color = "Blue", Brand = "SAAB", Model = "9000", NumberOfWheels = 4, TimeParked = DateTime.Today, MemberId = 7, VehicleTypeId = 1 }
                );
            context.SaveChanges();
            /*
            context.ParkedVehicles.AddOrUpdate(
                p => p.Type,
                new Models.ParkedVehicle { Type = VehicleType.Car, RegistrationNumber = "abc123", Color = "red", Brand = "volvo", Model = "s80", NumberOfWheels=4,TimeParked= DateTime.Today},
                new Models.ParkedVehicle { Type = Types.Bike, RegistrationNumber = "XYZ777", Color = "red", Brand = "ROYAL ENFIELD", Model = "500", NumberOfWheels = 2, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Plane, RegistrationNumber = "SAS666", Color = "red", Brand = "boeing", Model = "747", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Boat, RegistrationNumber = "fin1111", Color = "red", Brand = "crescent", Model = "540", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Truck, RegistrationNumber = "usa999", Color = "red", Brand = "mack", Model = "400", NumberOfWheels = 8, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Car, RegistrationNumber = "abc456", Color = "blue", Brand = "volvo", Model = "s80", NumberOfWheels = 4, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Bike, RegistrationNumber = "XYZ111", Color = "blue", Brand = "ROYAL ENFIELD", Model = "500", NumberOfWheels = 2, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Plane, RegistrationNumber = "SAS999", Color = "blue", Brand = "boeing", Model = "747", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Boat, RegistrationNumber = "fin1171", Color = "blue", Brand = "crescent", Model = "540", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Truck, RegistrationNumber = "usa222", Color = "blue", Brand = "mack", Model = "400", NumberOfWheels = 8, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Car, RegistrationNumber = "abc129", Color = "green", Brand = "volvo", Model = "s80", NumberOfWheels = 4, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Bike, RegistrationNumber = "XYZ779", Color = "green", Brand = "ROYAL ENFIELD", Model = "500", NumberOfWheels = 2, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Plane, RegistrationNumber = "SAS669", Color = "green", Brand = "boeing", Model = "747", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Boat, RegistrationNumber = "fin1119", Color = "green", Brand = "crescent", Model = "540", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Truck, RegistrationNumber = "usa999999", Color = "green", Brand = "mack", Model = "400", NumberOfWheels = 8, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Car, RegistrationNumber = "abc123", Color = "yellow", Brand = "fiat", Model = "uno", NumberOfWheels = 4, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Bike, RegistrationNumber = "XYZ777", Color = "yellow", Brand = "suzuki", Model = "900", NumberOfWheels = 2, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Plane, RegistrationNumber = "SAS666", Color = "yellow", Brand = "boeing", Model = "777", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Boat, RegistrationNumber = "fin1111", Color = "yellow", Brand = "crescent", Model = "740", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Truck, RegistrationNumber = "usa999", Color = "yellow", Brand = "mack", Model = "4000", NumberOfWheels = 16, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Car, RegistrationNumber = "hej444", Color = "black", Brand = "volvo", Model = "s80", NumberOfWheels = 4, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Bike, RegistrationNumber = "XYZ888", Color = "black", Brand = "ROYAL ENFIELD", Model = "500", NumberOfWheels = 2, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Plane, RegistrationNumber = "SAS000", Color = "black", Brand = "boeing", Model = "747", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Boat, RegistrationNumber = "fin000", Color = "black", Brand = "crescent", Model = "540", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Types.Truck, RegistrationNumber = "usa987", Color = "black", Brand = "mack", Model = "400", NumberOfWheels = 8, TimeParked = DateTime.Today });
                */
        }
    }
}