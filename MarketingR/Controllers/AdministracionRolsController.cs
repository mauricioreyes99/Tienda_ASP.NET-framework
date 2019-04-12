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
    public class AdministracionRolsController : Controller
    {
        private MarketingContext db = new MarketingContext();

        // GET: AdministracionRols
        public ActionResult Index()
        {
            var administracionRols = db.AdministracionRols.Include(a => a.Empleado).Include(a => a.Rol);
            return View(administracionRols.ToList());
        }

        // GET: AdministracionRols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministracionRol administracionRol = db.AdministracionRols.Find(id);
            if (administracionRol == null)
            {
                return HttpNotFound();
            }
            return View(administracionRol);
        }

        // GET: AdministracionRols/Create
        public ActionResult Create()
        {
            ViewBag.Id_empleado = new SelectList(db.Empleados, "Id_empleado", "Nombres");
            ViewBag.RolID = new SelectList(db.Roles, "RolID", "RolName");
            return View();
        }

        // POST: AdministracionRols/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "AdminRolID,Id_empleado,RolID")] AdministracionRol administracionRol)
        {
            var query = (from e in db.AdministracionRols
                         where (e.Id_empleado == administracionRol.Id_empleado)
                         select e).ToList();
            if (ModelState.IsValid)
            {
                if (query != null)
                {
                    ViewBag.Id_empleado = new SelectList(db.Empleados, "Id_empleado", "Nombres", administracionRol.Id_empleado);
                    ViewBag.RolID = new SelectList(db.Roles, "RolID", "RolName", administracionRol.RolID);
                    return Json(administracionRol, JsonRequestBehavior.AllowGet);
                }
                db.AdministracionRols.Add(administracionRol);
                db.SaveChanges();
                return Json(new { success= true}, JsonRequestBehavior.AllowGet);
            }

            ViewBag.Id_empleado = new SelectList(db.Empleados, "Id_empleado", "Nombres", administracionRol.Id_empleado);
            ViewBag.RolID = new SelectList(db.Roles, "RolID", "RolName", administracionRol.RolID);
            return Json(new { success= false}, JsonRequestBehavior.AllowGet);
        }

        // GET: AdministracionRols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministracionRol administracionRol = db.AdministracionRols.Find(id);
            if (administracionRol == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_empleado = new SelectList(db.Empleados, "Id_empleado", "Nombres", administracionRol.Id_empleado);
            ViewBag.RolID = new SelectList(db.Roles, "RolID", "RolName", administracionRol.RolID);
            return View(administracionRol);
        }

        // POST: AdministracionRols/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminRolID,Id_empleado,RolID")] AdministracionRol administracionRol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administracionRol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_empleado = new SelectList(db.Empleados, "Id_empleado", "Nombres", administracionRol.Id_empleado);
            ViewBag.RolID = new SelectList(db.Roles, "RolID", "RolName", administracionRol.RolID);
            return View(administracionRol);
        }

        // GET: AdministracionRols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministracionRol administracionRol = db.AdministracionRols.Find(id);
            if (administracionRol == null)
            {
                return HttpNotFound();
            }
            return View(administracionRol);
        }

        // POST: AdministracionRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdministracionRol administracionRol = db.AdministracionRols.Find(id);
            db.AdministracionRols.Remove(administracionRol);
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
