using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.Models;

namespace Garage2.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private ParkedVehicleContext db = new ParkedVehicleContext();

        // GET: ParkedVehicles
        public ActionResult Index()
        {
            //            return View(db.Employees.ToList());
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
        public ActionResult Search(string RegistrationNumber)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Where(p => p.RegistrationNumber == RegistrationNumber).FirstOrDefault();
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

        public ActionResult Park([Bind(Include = "Id,Type,RegistrationNumber,Color,Brand,Model,NumberOfWheels,TimeParked")] ParkedVehicle parkedVehicle)
        //public ActionResult Park([Bind(Include = "Id,Type,RegistrationNumber,Color,Brand,Model,NumberOfWheels,DateTime.Now")] ParkedVehicle parkedVehicle)

        {
            if (ModelState.IsValid)
            {
                //TimeParked = DateTime.Now;
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges(); //Kraschar, FIXA datetime.now
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
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

        //// GET: ParkedVehicles/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
        //    if (parkedVehicle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(parkedVehicle);
        //}

        //// POST: ParkedVehicles/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Type,RegistrationNumber,Color,Brand,Model,NumberOfWheels,TimeParked")] ParkedVehicle parkedVehicle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(parkedVehicle).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(parkedVehicle);
        //}

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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult RetrieveConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            db.ParkedVehicles.Remove(parkedVehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
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
