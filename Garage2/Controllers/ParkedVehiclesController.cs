using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.Models;
using Garage2.Content;

namespace Garage2.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private ParkedVehicleContext db = new ParkedVehicleContext();

        // GET: ParkedVehicles
        public ActionResult Index()
        {
            return View();
        }

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: Search the Garage
        public ActionResult Search(string RegistrationNumber, string Color, string Brand, string Model)
        {
            if (String.IsNullOrWhiteSpace(RegistrationNumber) && String.IsNullOrWhiteSpace(Color) && String.IsNullOrWhiteSpace(Brand) &&
    string.IsNullOrWhiteSpace(Model))
            {
                ViewBag.Message = "Please fill in att least one search field";
                List<ParkedVehicle> b = new List<ParkedVehicle>();
                return View(b);

            }

            var result = (from p8 in db.ParkedVehicles
                          where
                          (p8.Color == Color || p8.RegistrationNumber == RegistrationNumber ||
                          p8.Model == Model || p8.Brand == Brand)
                          select p8).Cast<ParkedVehicle>().ToList().Cast<ParkedVehicle>();
            return View(result);

        }

        // GET: ParkedVehicles/Create
        public ActionResult Park()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Id");
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park([Bind(Include = "Id,Type,RegistrationNumber,Color,Brand,Model,NumberOfWheels,MemberId")] ParkedVehicle parkedVehicle)
        {
            if (String.IsNullOrWhiteSpace(parkedVehicle.RegistrationNumber) || String.IsNullOrWhiteSpace(parkedVehicle.Color) || String.IsNullOrWhiteSpace(parkedVehicle.Brand) ||
                String.IsNullOrWhiteSpace(parkedVehicle.Model))
            {
                ViewBag.Message = "Please fill in all fields.";
                return View("Park");
            }
            if (parkedVehicle.RegistrationNumber.Length < 6 && parkedVehicle.RegistrationNumber.Length > 8)
            {
                ViewBag.Message = "Please keep the Registration Number between 6 and 8 characters.";
                return View("Park");
            }
            if (parkedVehicle.NumberOfWheels < 0)
            {
                ViewBag.Message = "Please give your vehicle a non-negative number of wheels.";
                return View("Park");
            }          
            parkedVehicle.TimeParked = DateTime.Now;
            if (ModelState.IsValid)
            {
                Reciept reciept = new Reciept(parkedVehicle);
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Reciept", reciept);
            }

            return View(parkedVehicle);
        }

        //GET: ParkedVehicles/Receipt
        public ActionResult Reciept(Reciept reciept)
        {
            if (reciept!=null)
            {
                return View(reciept);
            }
            return View("Index");         
        }

        public ActionResult Statistics() {

            var vehicles = db.ParkedVehicles.ToList();
            Stats stats = new Stats();
            var cars = (from pt in vehicles
                        where pt.Type.Type == Types.Car
                        select pt);
            stats.CarsParked = cars.Count();
            var bikes = (from pt in vehicles
                        where pt.Type.Type == Types.Bike
                        select pt);
            stats.BikesParked = bikes.Count();
            var planes = (from pt in vehicles
                         where pt.Type.Type == Types.Plane
                         select pt);
            stats.PlanesParked = planes.Count();
            var boats = (from pt in vehicles
                         where pt.Type.Type == Types.Boat
                         select pt);
            stats.BoatsParked = boats.Count();
            var trucks = (from pt in vehicles
                         where pt.Type.Type == Types.Truck
                         select pt);
            stats.TrucksParked = trucks.Count();
            int totalWheels = 0;
            int totalCost = 0;
            foreach (var item in vehicles)
            {
                totalWheels += item.NumberOfWheels;
                totalCost += 100 * (int)Math.Ceiling((DateTime.Now - item.TimeParked).TotalHours);
            }
            stats.TotalNumberOfWheels = totalWheels;
            stats.TotalCost = totalCost;
            return View(stats);
        }

        //GET: ParkedVehicles/List
        public ActionResult List()
        {
            try
            {
                return View(db.ParkedVehicles.ToList());
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View("Index");
            }
        }

        //GET: ParkedVehicles/DetailedList
        public ActionResult DetailedList(string Reg, Types? VehicleTypeId)
        {
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Type");
            var result = db.ParkedVehicles.ToList();
            if (!String.IsNullOrWhiteSpace(Reg))
            {
                result = (from d8 in result
                          where d8.RegistrationNumber.Contains(Reg)
                          select d8).ToList();
            }
            if (VehicleTypeId!=null)
            {
                result = (from d8 in result
                          where d8.Type.Type == VehicleTypeId
                          select d8).ToList();
            }
            return View(result);
        }


        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,RegistrationNumber,Color,Brand,Model,NumberOfWheels,TimeParked")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
        }

       // GET: ParkedVehicles/Delete/5
        public ActionResult Retrieve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        // public ActionResult RetrieveConfirmed(int id)
        [HttpPost, ActionName("Retrieve")]
        [ValidateAntiForgeryToken]
        public ActionResult RetrieveConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            Reciept receipt = new Reciept(parkedVehicle);
            db.ParkedVehicles.Remove(parkedVehicle);
            db.SaveChanges();
            return View("Reciept", receipt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
