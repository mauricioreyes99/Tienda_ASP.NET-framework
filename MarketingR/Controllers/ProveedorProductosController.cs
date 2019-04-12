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
    public class ProveedorProductosController : Controller
    {
        private MarketingContext db = new MarketingContext();

        // GET: ProveedorProductos
        public ActionResult Index()
        {
            var proveedorProductoes = db.ProveedorProductos.Include(p => p.Producto).Include(p => p.Proveedor);
            return View(proveedorProductoes.ToList());
        }

        // GET: ProveedorProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorProducto proveedorProducto = db.ProveedorProductos.Find(id);
            if (proveedorProducto == null)
            {
                return HttpNotFound();
            }
            return View(proveedorProducto);
        }

        // GET: ProveedorProductos/Create
        public ActionResult Create()
        {
            ViewBag.Id_producto = new SelectList(db.Productos, "Id_producto", "Nombre_producto");
            ViewBag.ProveedorID = new SelectList(db.Proveedores, "ProveedorID", "Nombre");
            return View();
        }

        // POST: ProveedorProductos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProveedorProductoID,ProveedorID,Id_producto")] ProveedorProducto proveedorProducto)
        {
            if (ModelState.IsValid)
            {
                db.ProveedorProductos.Add(proveedorProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_producto = new SelectList(db.Productos, "Id_producto", "Nombre_producto", proveedorProducto.Id_producto);
            ViewBag.ProveedorID = new SelectList(db.Proveedores, "ProveedorID", "Nombre", proveedorProducto.ProveedorID);
            return View(proveedorProducto);
        }

        // GET: ProveedorProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorProducto proveedorProducto = db.ProveedorProductos.Find(id);
            if (proveedorProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_producto = new SelectList(db.Productos, "Id_producto", "Nombre_producto", proveedorProducto.Id_producto);
            ViewBag.ProveedorID = new SelectList(db.Proveedores, "ProveedorID", "Nombre", proveedorProducto.ProveedorID);
            return View(proveedorProducto);
        }

        // POST: ProveedorProductos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProveedorProductoID,ProveedorID,Id_producto")] ProveedorProducto proveedorProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedorProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_producto = new SelectList(db.Productos, "Id_producto", "Nombre_producto", proveedorProducto.Id_producto);
            ViewBag.ProveedorID = new SelectList(db.Proveedores, "ProveedorID", "Nombre", proveedorProducto.ProveedorID);
            return View(proveedorProducto);
        }

        // GET: ProveedorProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorProducto proveedorProducto = db.ProveedorProductos.Find(id);
            if (proveedorProducto == null)
            {
                return HttpNotFound();
            }
            return View(proveedorProducto);
        }

        // POST: ProveedorProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProveedorProducto proveedorProducto = db.ProveedorProductos.Find(id);
            db.ProveedorProductos.Remove(proveedorProducto);
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
