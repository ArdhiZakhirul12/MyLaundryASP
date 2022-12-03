using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projectLaundry.DataContext;
using projectLaundry.Models;

namespace projectLaundry.Controllers
{
    public class custController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: cust
        public ActionResult Index()
        {
            return View(db.custobj.ToList());
        }

        // GET: cust/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            custClass custClass = db.custobj.Find(id);
            if (custClass == null)
            {
                return HttpNotFound();
            }
            return View(custClass);
        }

        // GET: cust/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cust/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cust,nama_cust,alamat_cust,no_cust")] custClass custClass)
        {
            if (ModelState.IsValid)
            {
                db.custobj.Add(custClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(custClass);
        }

        // GET: cust/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            custClass custClass = db.custobj.Find(id);
            if (custClass == null)
            {
                return HttpNotFound();
            }
            return View(custClass);
        }

        // POST: cust/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cust,nama_cust,alamat_cust,no_cust")] custClass custClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(custClass);
        }

        // GET: cust/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            custClass custClass = db.custobj.Find(id);
            if (custClass == null)
            {
                return HttpNotFound();
            }
            return View(custClass);
        }

        // POST: cust/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            custClass custClass = db.custobj.Find(id);
            db.custobj.Remove(custClass);
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
