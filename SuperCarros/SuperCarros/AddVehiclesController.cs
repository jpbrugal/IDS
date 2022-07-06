using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SuperCarros
{
    public class AddVehiclesController : Controller
    {
        private db db = new db();

        // GET: AddVehicles
        public ActionResult Index()
        {
            return View(db.AddVehicles.ToList());
        }

        // GET: AddVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddVehicle addVehicle = db.AddVehicles.Find(id);
            if (addVehicle == null)
            {
                return HttpNotFound();
            }
            return View(addVehicle);
        }

        // GET: AddVehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,Year,Brand,Model,Engine,Transmission,Color,Description,Location,Seller_Name,Phone_Number,Picture")] AddVehicle addVehicle)
        {
            if (ModelState.IsValid)
            {
                db.AddVehicles.Add(addVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addVehicle);
        }

        // GET: AddVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddVehicle addVehicle = db.AddVehicles.Find(id);
            if (addVehicle == null)
            {
                return HttpNotFound();
            }
            return View(addVehicle);
        }

        // POST: AddVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Year,Brand,Model,Engine,Transmission,Color,Description,Location,Seller_Name,Phone_Number,Picture")] AddVehicle addVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addVehicle);
        }

        // GET: AddVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddVehicle addVehicle = db.AddVehicles.Find(id);
            if (addVehicle == null)
            {
                return HttpNotFound();
            }
            return View(addVehicle);
        }

        // POST: AddVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddVehicle addVehicle = db.AddVehicles.Find(id);
            db.AddVehicles.Remove(addVehicle);
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
