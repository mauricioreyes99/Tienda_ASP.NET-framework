using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarketingR.Context;
using MarketingR.Models;

namespace MarketingR.Controllers
{
    [Authorize]
    public class OrdenesController : Controller
    {
        private MarketingContext db = new MarketingContext();

        // GET: Ordenes
        public ActionResult Index()
        {
            var ordenes = db.Ordenes.Include(o => o.Cliente);
            return View(ordenes.ToList());
        }

        // GET: Ordenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Ordenes.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // GET: Ordenes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombre_Cliente");
            return View();
        }

        // POST: Ordenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,Fecha_Orden,Descripcion,ClienteID")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Ordenes.Add(orden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombre_Cliente", orden.ClienteID);
            return View(orden);
        }

        // GET: Ordenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Ordenes.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombre_Cliente", orden.ClienteID);
            return View(orden);
        }

        // POST: Ordenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,Fecha_Orden,Descripcion,ClienteID")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombre_Cliente", orden.ClienteID);
            return View(orden);
        }

        // GET: Ordenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Ordenes.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // POST: Ordenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orden orden = db.Ordenes.Find(id);
            db.Ordenes.Remove(orden);
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
