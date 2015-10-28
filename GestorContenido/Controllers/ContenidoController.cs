using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using GestorContenido.Models;
using GestorContenido.Helpers;

namespace GestorContenido.Controllers
{
    public class ContenidoController : Controller
    {
        private EntityModel db = new EntityModel();
        private string fn = "";
        // GET: Contenido
        public ActionResult Index()
        {
            return View(db.Contenido.ToList());
        }

        // GET: Contenido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contenido contenido = db.Contenido.Find(id);
            if (contenido == null)
            {
                return HttpNotFound();
            }
            return View(contenido);
        }

        // GET: Contenido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contenido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,texto,imageDir,row,idUser,create,modified")] Contenido contenido)
        {
            if (ModelState.IsValid)
            {
                db.Contenido.Add(contenido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contenido);
        }

        // GET: Contenido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contenido contenido = db.Contenido.Find(id);
            if (contenido == null)
            {
                return HttpNotFound();
            }
            return View(contenido);
        }

        // POST: Contenido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titulo,texto,imageDir,row,idUser,create,modified")] Contenido contenido, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                if ((fileUpload != null) && (fileUpload.ContentLength > 0))
                {
                    fn = Path.GetFileName(fileUpload.FileName);
                    string SaveLocation = Server.MapPath(@"~\Content\resources") + "\\" + fn;
                    if (!System.IO.File.Exists(SaveLocation))
                    {
                        try
                        {
                            fileUpload.SaveAs(SaveLocation);
                            contenido.modified = DateTime.Now;
                            contenido.imageDir = fn;
                            db.Entry(contenido).State = EntityState.Modified;
                            db.SaveChanges();
                            ViewBag.FileExist = false;
                            return RedirectToAction("Index");
                        }
                        catch (Exception ex)
                        {
                            GlobalMensajes.globalMensajeError = "Ocurrio Un Error Al Guardar";
                        }
                    }
                    else
                    {
                        ViewBag.FileExist = true;
                        GlobalMensajes.globalMensajeError = "Ya Existe una Imagen Con Ese Nombre "+ fn;
                    }
                    
                    
                }
                
                
            }
            return View();
        }

        // GET: Contenido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contenido contenido = db.Contenido.Find(id);
            if (contenido == null)
            {
                return HttpNotFound();
            }
            return View(contenido);
        }

        // POST: Contenido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contenido contenido = db.Contenido.Find(id);
            db.Contenido.Remove(contenido);
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
