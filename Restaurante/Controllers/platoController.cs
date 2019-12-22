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
    public class platoController : Controller
    {
        private RestauranteEntities db = new RestauranteEntities();

        // GET: plato
        public ActionResult Index()
        {
            return View(db.plato.ToList());
        }

        // GET: plato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plato plato = db.plato.Find(id);
            if (plato == null)
            {
                return HttpNotFound();
            }
            return View(plato);
        }

        // GET: plato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: plato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pla_id,pla_nombre,pla_precio_venta")] plato plato)
        {
            if (ModelState.IsValid)
            {
                db.plato.Add(plato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plato);
        }

        // GET: plato/CreatePlatoCompleto
        public ActionResult CreatePlatoCompleto()
        {
            return View();
        }

        // POST: plato/CreatePlatoCompleto
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePlatoCompleto( plato plato)
        {
            if (ModelState.IsValid)
            {
                db.plato.Add(plato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plato);
        }

        // GET: plato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plato plato = db.plato.Find(id);
            if (plato == null)
            {
                return HttpNotFound();
            }
            return View(plato);
        }

        // POST: plato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pla_id,pla_nombre,pla_precio_venta")] plato plato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plato);
        }

        // GET: plato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plato plato = db.plato.Find(id);
            if (plato == null)
            {
                return HttpNotFound();
            }
            return View(plato);
        }

        // POST: plato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            plato plato = db.plato.Find(id);
            db.plato.Remove(plato);
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
