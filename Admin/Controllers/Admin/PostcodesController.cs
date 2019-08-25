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
    public class PostcodesController : Controller
    {
        private SurgreyEntities db = new SurgreyEntities();

        // GET: Postcodes
        public ActionResult Index()
        {
            return View(db.Postcodes1.ToList());
        }

        // GET: Postcodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postcodes postcodes = db.Postcodes1.Find(id);
            if (postcodes == null)
            {
                return HttpNotFound();
            }
            return View(postcodes);
        }

        // GET: Postcodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Postcodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostcodeID,Postcode")] Postcodes postcodes)
        {
            if (ModelState.IsValid)
            {
                db.Postcodes1.Add(postcodes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postcodes);
        }

        // GET: Postcodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postcodes postcodes = db.Postcodes1.Find(id);
            if (postcodes == null)
            {
                return HttpNotFound();
            }
            return View(postcodes);
        }

        // POST: Postcodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostcodeID,Postcode")] Postcodes postcodes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postcodes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postcodes);
        }

        // GET: Postcodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postcodes postcodes = db.Postcodes1.Find(id);
            if (postcodes == null)
            {
                return HttpNotFound();
            }
            return View(postcodes);
        }

        // POST: Postcodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Postcodes postcodes = db.Postcodes1.Find(id);
            db.Postcodes1.Remove(postcodes);
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
