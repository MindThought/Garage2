namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2.Models.ParkedVehicleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage2.Models.ParkedVehicleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ParkedVehicles.AddOrUpdate(
                p => p.Type,
                new Models.ParkedVehicle { Type = Models.Types.Car, RegistrationNumber = "abc123", Color = "red", Brand = "volvo", Model = "s80", NumberOfWheels=4,TimeParked= DateTime.Today},
                new Models.ParkedVehicle { Type = Models.Types.Bike, RegistrationNumber = "XYZ777", Color = "red", Brand = "ROYAL ENFIELD", Model = "500", NumberOfWheels = 2, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Plane, RegistrationNumber = "SAS666", Color = "red", Brand = "boeing", Model = "747", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Boat, RegistrationNumber = "fin1111", Color = "red", Brand = "crescent", Model = "540", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Truck, RegistrationNumber = "usa999", Color = "red", Brand = "mack", Model = "400", NumberOfWheels = 8, TimeParked = DateTime.Today },

                new Models.ParkedVehicle { Type = Models.Types.Car, RegistrationNumber = "abc456", Color = "blue", Brand = "volvo", Model = "s80", NumberOfWheels = 4, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Bike, RegistrationNumber = "XYZ111", Color = "blue", Brand = "ROYAL ENFIELD", Model = "500", NumberOfWheels = 2, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Plane, RegistrationNumber = "SAS999", Color = "blue", Brand = "boeing", Model = "747", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Boat, RegistrationNumber = "fin1171", Color = "blue", Brand = "crescent", Model = "540", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Truck, RegistrationNumber = "usa222", Color = "blue", Brand = "mack", Model = "400", NumberOfWheels = 8, TimeParked = DateTime.Today },

                new Models.ParkedVehicle { Type = Models.Types.Car, RegistrationNumber = "abc129", Color = "green", Brand = "volvo", Model = "s80", NumberOfWheels = 4, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Bike, RegistrationNumber = "XYZ779", Color = "green", Brand = "ROYAL ENFIELD", Model = "500", NumberOfWheels = 2, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Plane, RegistrationNumber = "SAS669", Color = "green", Brand = "boeing", Model = "747", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Boat, RegistrationNumber = "fin1119", Color = "green", Brand = "crescent", Model = "540", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Truck, RegistrationNumber = "usa999999", Color = "green", Brand = "mack", Model = "400", NumberOfWheels = 8, TimeParked = DateTime.Today },

                new Models.ParkedVehicle { Type = Models.Types.Car, RegistrationNumber = "abc123", Color = "yellow", Brand = "fiat", Model = "uno", NumberOfWheels = 4, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Bike, RegistrationNumber = "XYZ777", Color = "yellow", Brand = "suzuki", Model = "900", NumberOfWheels = 2, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Plane, RegistrationNumber = "SAS666", Color = "yellow", Brand = "boeing", Model = "777", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Boat, RegistrationNumber = "fin1111", Color = "yellow", Brand = "crescent", Model = "740", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Truck, RegistrationNumber = "usa999", Color = "yellow", Brand = "mack", Model = "4000", NumberOfWheels = 16, TimeParked = DateTime.Today },

                new Models.ParkedVehicle { Type = Models.Types.Car, RegistrationNumber = "hej444", Color = "black", Brand = "volvo", Model = "s80", NumberOfWheels = 4, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Bike, RegistrationNumber = "XYZ888", Color = "black", Brand = "ROYAL ENFIELD", Model = "500", NumberOfWheels = 2, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Plane, RegistrationNumber = "SAS000", Color = "black", Brand = "boeing", Model = "747", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Boat, RegistrationNumber = "fin000", Color = "black", Brand = "crescent", Model = "540", NumberOfWheels = 0, TimeParked = DateTime.Today },
                new Models.ParkedVehicle { Type = Models.Types.Truck, RegistrationNumber = "usa987", Color = "black", Brand = "mack", Model = "400", NumberOfWheels = 8, TimeParked = DateTime.Today });

        }
    }
}
