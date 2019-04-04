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
    public class CompositoresController : Controller
    {
        private GravadoraStudiosContext db = new GravadoraStudiosContext();

        // GET: Compositores
        public ActionResult Index()
        {
            var compositors = db.Compositors.Include(c => c.Reponsavel);
            return View(compositors.ToList());
        }

        // GET: Compositores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compositor compositor = db.Compositors.Find(id);
            if (compositor == null)
            {
                return HttpNotFound();
            }
            return View(compositor);
        }

        // GET: Compositores/Create
        public ActionResult Create()
        {
            ViewBag.ResponsavelId = new SelectList(db.Responsavels, "ResponsavelId", "Nome");
            return View();
        }

        // POST: Compositores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompositorId,Nome,CPF,Idade,ResponsavelId")] Compositor compositor)
        {
            if (ModelState.IsValid)
            {
                db.Compositors.Add(compositor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResponsavelId = new SelectList(db.Responsavels, "ResponsavelId", "Nome", compositor.ResponsavelId);
            return View(compositor);
        }

        // GET: Compositores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compositor compositor = db.Compositors.Find(id);
            if (compositor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResponsavelId = new SelectList(db.Responsavels, "ResponsavelId", "Nome", compositor.ResponsavelId);
            return View(compositor);
        }

        // POST: Compositores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompositorId,Nome,CPF,Idade,ResponsavelId")] Compositor compositor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compositor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResponsavelId = new SelectList(db.Responsavels, "ResponsavelId", "Nome", compositor.ResponsavelId);
            return View(compositor);
        }

        // GET: Compositores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compositor compositor = db.Compositors.Find(id);
            if (compositor == null)
            {
                return HttpNotFound();
            }
            return View(compositor);
        }

        // POST: Compositores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compositor compositor = db.Compositors.Find(id);
            db.Compositors.Remove(compositor);
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
