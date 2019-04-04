using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GravadoraStudios.Models;

namespace GravadoraStudios.Controllers
{
    public class LetrasController : Controller
    {
        private GravadoraStudiosContext db = new GravadoraStudiosContext();

        // GET: Letras
        public ActionResult Index()
        {
            var letras = db.Letras.Include(l => l.Compositor);
            return View(letras.ToList());
        }

        // GET: Letras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Letra letra = db.Letras.Find(id);
            if (letra == null)
            {
                return HttpNotFound();
            }
            return View(letra);
        }

        // GET: Letras/Create
        public ActionResult Create()
        {
            ViewBag.CompositorId = new SelectList(db.Compositors, "CompositorId", "Nome");
            return View();
        }

        // POST: Letras/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LetraId,Titulo,Genero,Publicada,CompositorId")] Letra letra)
        {
            if (ModelState.IsValid)
            {
                db.Letras.Add(letra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompositorId = new SelectList(db.Compositors, "CompositorId", "Nome", letra.CompositorId);
            return View(letra);
        }

        // GET: Letras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Letra letra = db.Letras.Find(id);
            if (letra == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompositorId = new SelectList(db.Compositors, "CompositorId", "Nome", letra.CompositorId);
            return View(letra);
        }

        // POST: Letras/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LetraId,Titulo,Genero,Publicada,CompositorId")] Letra letra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(letra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompositorId = new SelectList(db.Compositors, "CompositorId", "Nome", letra.CompositorId);
            return View(letra);
        }

        // GET: Letras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Letra letra = db.Letras.Find(id);
            if (letra == null)
            {
                return HttpNotFound();
            }
            return View(letra);
        }

        // POST: Letras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Letra letra = db.Letras.Find(id);
            db.Letras.Remove(letra);
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
