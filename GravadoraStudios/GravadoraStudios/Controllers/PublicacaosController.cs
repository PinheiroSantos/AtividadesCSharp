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
    public class PublicacaosController : Controller
    {
        private GravadoraStudiosContext db = new GravadoraStudiosContext();

        // GET: Publicacaos
        public ActionResult Index()
        {
            var publicacaos = db.Publicacaos.Include(p => p.Letra);
            return View(publicacaos.ToList());
        }

        // GET: Publicacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacao publicacao = db.Publicacaos.Find(id);
            if (publicacao == null)
            {
                return HttpNotFound();
            }
            return View(publicacao);
        }

        // GET: Publicacaos/Create
        public ActionResult Create()
        {
            ViewBag.LetraId = new SelectList(db.Letras, "LetraId", "Titulo");
            return View();
        }

        // POST: Publicacaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PublicacaoId,Data,LetraId")] Publicacao publicacao)
        {
            if (ModelState.IsValid)
            {
                Letra letra = db.Letras.Find(publicacao.LetraId);
                publicacao.Letra = letra;
                if (publicacao.VerificarPublicaco())
                {
                    db.Publicacaos.Add(publicacao);
                    db.SaveChanges();
                    letra.Publicada = true;
                    db.Entry(letra).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }

            ViewBag.LetraId = new SelectList(db.Letras, "LetraId", "Titulo", publicacao.LetraId);
            return View(publicacao);
        }

        // GET: Publicacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacao publicacao = db.Publicacaos.Find(id);
            if (publicacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.LetraId = new SelectList(db.Letras, "LetraId", "Titulo", publicacao.LetraId);
            return View(publicacao);
        }

        // POST: Publicacaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PublicacaoId,Data,LetraId")] Publicacao publicacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LetraId = new SelectList(db.Letras, "LetraId", "Titulo", publicacao.LetraId);
            return View(publicacao);
        }

        // GET: Publicacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacao publicacao = db.Publicacaos.Find(id);
            if (publicacao == null)
            {
                return HttpNotFound();
            }
            return View(publicacao);
        }

        // POST: Publicacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicacao publicacao = db.Publicacaos.Find(id);
            db.Publicacaos.Remove(publicacao);
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
