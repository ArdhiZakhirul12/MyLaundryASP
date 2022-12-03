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
    public class transaksiController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: transaksi
        public ActionResult Index()
        {
         
            var transaksiobj = db.transaksiobj.Include(t => t.adminClass).Include(t => t.custClass).Include(t => t.paketClass);
    
            return View(transaksiobj.ToList());
        }

        // GET: transaksi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || db.transaksiobj == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transaksi = db.transaksiobj
                .Include(t => t.adminClass)
                .Include(t => t.custClass)
                .Include(t => t.paketClass)
                .FirstOrDefault(m => m.id_transaksi == id);
            //transaksiClass transaksiClass = db.transaksiobj.Find(id);
            if (transaksi == null)
            {
                return HttpNotFound();
            }
            return View(transaksi);
        }

        // GET: transaksi/Create
        public ActionResult Create()
        {
            ViewBag.admin_id = new SelectList(db.adminobj, "id_admin", "nama_admin");
            ViewBag.cust_id = new SelectList(db.custobj, "id_cust", "nama_cust");
            ViewBag.paket_id = new SelectList(db.paketobj, "id_paket", "nama_paket");
            return View();
        }

        // POST: transaksi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_transaksi,tgl_transaksi,kuantitas,paket_id,admin_id,cust_id,tgl_diambil")] transaksiClass transaksiClass)
        {
            if (ModelState.IsValid)
            {
                db.transaksiobj.Add(transaksiClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.admin_id = new SelectList(db.adminobj, "id_admin", "nama_admin", transaksiClass.admin_id);
            ViewBag.cust_id = new SelectList(db.custobj, "id_cust", "nama_cust", transaksiClass.cust_id);
            ViewBag.paket_id = new SelectList(db.paketobj, "id_paket", "nama_paket", transaksiClass.paket_id);
            return View(transaksiClass);
        }

        // GET: transaksi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaksiClass transaksiClass = db.transaksiobj.Find(id);
            if (transaksiClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.admin_id = new SelectList(db.adminobj, "id_admin", "nama_admin", transaksiClass.admin_id);
            ViewBag.cust_id = new SelectList(db.custobj, "id_cust", "nama_cust", transaksiClass.cust_id);
            ViewBag.paket_id = new SelectList(db.paketobj, "id_paket", "nama_paket", transaksiClass.paket_id);
            return View(transaksiClass);
        }

        // POST: transaksi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_transaksi,tgl_transaksi,kuantitas,paket_id,admin_id,cust_id,tgl_diambil")] transaksiClass transaksiClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaksiClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.admin_id = new SelectList(db.adminobj, "id_admin", "nama_admin", transaksiClass.admin_id);
            ViewBag.cust_id = new SelectList(db.custobj, "id_cust", "nama_cust", transaksiClass.cust_id);
            ViewBag.paket_id = new SelectList(db.paketobj, "id_paket", "nama_paket", transaksiClass.paket_id);
            return View(transaksiClass);
        }

        // GET: transaksi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaksiClass transaksiClass = db.transaksiobj.Find(id);
            if (transaksiClass == null)
            {
                return HttpNotFound();
            }
            return View(transaksiClass);
        }

        // POST: transaksi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transaksiClass transaksiClass = db.transaksiobj.Find(id);
            db.transaksiobj.Remove(transaksiClass);
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
