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
    public class adminController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: admin
        public ActionResult Index()
        {
            return View(db.adminobj.ToList());
        }

        // GET: admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminClass adminClass = db.adminobj.Find(id);
            if (adminClass == null)
            {
                return HttpNotFound();
            }
            return View(adminClass);
        }

        // GET: admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_admin,nama_admin,alamat_admin,no_telp,username_admin,password_admin")] adminClass adminClass)
        {
            if (ModelState.IsValid)
            {
                db.adminobj.Add(adminClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminClass);
        }

        // GET: admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminClass adminClass = db.adminobj.Find(id);
            if (adminClass == null)
            {
                return HttpNotFound();
            }
            return View(adminClass);
        }

        // POST: admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_admin,nama_admin,alamat_admin,no_telp,username_admin,password_admin")] adminClass adminClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminClass);
        }

        // GET: admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminClass adminClass = db.adminobj.Find(id);
            if (adminClass == null)
            {
                return HttpNotFound();
            }
            return View(adminClass);
        }

        // POST: admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            adminClass adminClass = db.adminobj.Find(id);
            db.adminobj.Remove(adminClass);
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
