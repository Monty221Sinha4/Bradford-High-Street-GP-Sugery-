using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GP_Project;

namespace GP_Project.Controllers.Admin
{
    public class PatientsInfoesController : Controller
    {
        private SurgreyEntities db = new SurgreyEntities();

        // GET: PatientsInfoes
        public ActionResult Index()
        {
            var patientsInfoes = db.PatientsInfoes.Include(p => p.Address).Include(p => p.Doctor);
            return View(patientsInfoes.ToList());
        }

        // GET: PatientsInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientsInfo patientsInfo = db.PatientsInfoes.Find(id);
            if (patientsInfo == null)
            {
                return HttpNotFound();
            }
            return View(patientsInfo);
        }

        // GET: PatientsInfoes/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Street");
            ViewBag.DocID = new SelectList(db.Doctors, "DoctID", "Firstname");
            return View();
        }

        // POST: PatientsInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,Firstname,Lastname,DateOfBirth,AddressID,DocID")] PatientsInfo patientsInfo)
        {
            if (ModelState.IsValid)
            {
                db.PatientsInfoes.Add(patientsInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Street", patientsInfo.AddressID);
            ViewBag.DocID = new SelectList(db.Doctors, "DoctID", "Firstname", patientsInfo.DocID);
            return View(patientsInfo);
        }

        // GET: PatientsInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientsInfo patientsInfo = db.PatientsInfoes.Find(id);
            if (patientsInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Street", patientsInfo.AddressID);
            ViewBag.DocID = new SelectList(db.Doctors, "DoctID", "Firstname", patientsInfo.DocID);
            return View(patientsInfo);
        }

        // POST: PatientsInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,Firstname,Lastname,DateOfBirth,AddressID,DocID")] PatientsInfo patientsInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientsInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Street", patientsInfo.AddressID);
            ViewBag.DocID = new SelectList(db.Doctors, "DoctID", "Firstname", patientsInfo.DocID);
            return View(patientsInfo);
        }

        // GET: PatientsInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientsInfo patientsInfo = db.PatientsInfoes.Find(id);
            if (patientsInfo == null)
            {
                return HttpNotFound();
            }
            return View(patientsInfo);
        }

        // POST: PatientsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientsInfo patientsInfo = db.PatientsInfoes.Find(id);
            db.PatientsInfoes.Remove(patientsInfo);
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
