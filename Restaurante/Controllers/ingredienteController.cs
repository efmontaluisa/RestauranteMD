using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurante;

namespace Restaurante.Controllers
{
    public class ingredienteController : Controller
    {
        private RestauranteEntities db = new RestauranteEntities();

        // GET: ingrediente
        public ActionResult Index()
        {
            var ingredientes = db.ingredientes.Include(i => i.plato);
            return View(ingredientes.ToList());
        }

        // GET: ingrediente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingredientes ingredientes = db.ingredientes.Find(id);
            if (ingredientes == null)
            {
                return HttpNotFound();
            }
            return View(ingredientes);
        }

        // GET: ingrediente/Create
        public ActionResult Create()
        {
            ViewBag.pla_id = new SelectList(db.plato, "pla_id", "pla_nombre");
            return View();
        }

        // POST: ingrediente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ing_id,pla_id,ing_nombre,ing_cantidad")] ingredientes ingredientes)
        {
            if (ModelState.IsValid)
            {
                db.ingredientes.Add(ingredientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pla_id = new SelectList(db.plato, "pla_id", "pla_nombre", ingredientes.pla_id);
            return View(ingredientes);
        }

        // GET: ingrediente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingredientes ingredientes = db.ingredientes.Find(id);
            if (ingredientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.pla_id = new SelectList(db.plato, "pla_id", "pla_nombre", ingredientes.pla_id);
            return View(ingredientes);
        }

        // POST: ingrediente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ing_id,pla_id,ing_nombre,ing_cantidad")] ingredientes ingredientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pla_id = new SelectList(db.plato, "pla_id", "pla_nombre", ingredientes.pla_id);
            return View(ingredientes);
        }

        // GET: ingrediente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingredientes ingredientes = db.ingredientes.Find(id);
            if (ingredientes == null)
            {
                return HttpNotFound();
            }
            return View(ingredientes);
        }

        // POST: ingrediente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ingredientes ingredientes = db.ingredientes.Find(id);
            db.ingredientes.Remove(ingredientes);
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
