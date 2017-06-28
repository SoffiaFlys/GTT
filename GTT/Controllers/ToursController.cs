using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GTT.Entities;
using GTT.Views.Models;

namespace GTT.Controllers
{
    public class ToursController : Controller
    {
        private TourContext db = new TourContext();

        // GET: Tours
        public ActionResult Index()
        {
            var tour = db.Tour.Include(t => t.Day_Connection1).Include(t => t.FoodType).Include(t => t.Route_Connection1);
            return View(tour.ToList());
        }

        // GET: Tours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Tours/Create
        public ActionResult Create()
        {
            ViewBag.ProgramFirstDayID = new SelectList(db.Day_Connection, "Id", "Id");
            ViewBag.FoodTypeID = new SelectList(db.FoodType, "Id", "Description");
            ViewBag.StartConnectionID = new SelectList(db.Route_Connection, "ID", "ID");
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,PriceUSD,StartConnectionID,ProgramFirstDayID,Description,FoodTypeID")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Tour.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramFirstDayID = new SelectList(db.Day_Connection, "Id", "Id", tour.ProgramFirstDayID);
            ViewBag.FoodTypeID = new SelectList(db.FoodType, "Id", "Description", tour.FoodTypeID);
            ViewBag.StartConnectionID = new SelectList(db.Route_Connection, "ID", "ID", tour.StartConnectionID);
            return View(tour);
        }

        // GET: Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramFirstDayID = new SelectList(db.Day_Connection, "Id", "Id", tour.ProgramFirstDayID);
            ViewBag.FoodTypeID = new SelectList(db.FoodType, "Id", "Description", tour.FoodTypeID);
            ViewBag.StartConnectionID = new SelectList(db.Route_Connection, "ID", "ID", tour.StartConnectionID);
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,PriceUSD,StartConnectionID,ProgramFirstDayID,Description,FoodTypeID")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramFirstDayID = new SelectList(db.Day_Connection, "Id", "Id", tour.ProgramFirstDayID);
            ViewBag.FoodTypeID = new SelectList(db.FoodType, "Id", "Description", tour.FoodTypeID);
            ViewBag.StartConnectionID = new SelectList(db.Route_Connection, "ID", "ID", tour.StartConnectionID);
            return View(tour);
        }

        // GET: Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = db.Tour.Find(id);
            db.Tour.Remove(tour);
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
