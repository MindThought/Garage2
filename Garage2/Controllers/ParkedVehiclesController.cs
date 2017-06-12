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

        // GET: ParkedVehicles/Create
        public ActionResult Park()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park([Bind(Include = "Id,Type,RegistrationNumber,Color,Brand,Model,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
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

        //GET: 
        public ActionResult Reciept(Reciept reciept)
        {
            if (reciept!=null)
            {
                return View(reciept);
            }
            return View("Index");
        }

        public ActionResult List()
        {
            try
            {
                return View(db.ParkedVehicles.ToList());
            }
            catch (Exception)
            {
                return View("Index");
            }
            
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Retrieve(int id)
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
