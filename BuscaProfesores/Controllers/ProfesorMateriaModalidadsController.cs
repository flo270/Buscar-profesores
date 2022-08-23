using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BuscaProfesores.Models;
using Microsoft.AspNet.Identity;

namespace BuscaProfesores.Controllers
{
    [Authorize]
    public class ProfesorMateriaModalidadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProfesorMateriaModalidads
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();

            var profesorMateriaModalidads = db.ProfesorMateriaModalidades.Where(x => x.ApplicationUserId == userId)
                .Include(p => p.ApplicationUsers)
                .Include(p => p.Materias)
                .Include(p => p.Modalidades);


            //var join =
            //    from pmm in db.ProfesorMateriaModalidades
            //    join materia in db.Materias
            //    on pmm.MateriaId equals materia.Id
            //    join modalidades in db.Modalidades
            //    on pmm.ModalidadaId equals modalidades.Id
            //    join user in db.Users
            //    on pmm.ApplicationUserId equals user.Id
            //    where pmm.ApplicationUserId == userId
            //    select new JoinProfesorMateriaModalida {id=pmm.Id, Materia = materia, Modalidad = modalidades, ApplicationUser = user, Precio = pmm.Precio };





            return View(profesorMateriaModalidads.ToList());
        }

        // GET: ProfesorMateriaModalidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesorMateriaModalidad profesorMateriaModalidad = db.ProfesorMateriaModalidades.Find(id);
            if (profesorMateriaModalidad == null)
            {
                return HttpNotFound();
            }
            return View(profesorMateriaModalidad);
        }

        // GET: ProfesorMateriaModalidads/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = User.Identity.GetUserId();
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "NombreMateria");
            ViewBag.ModalidadaId = new SelectList(db.Modalidades, "Id", "TiposDeModalidad");
            return View();
        }

        // POST: ProfesorMateriaModalidads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MateriaId,ApplicationUserId,ModalidadaId,Precio")] ProfesorMateriaModalidad profesorMateriaModalidad)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                if (!db.ProfesorMateriaModalidades.Where(x => x.ApplicationUserId == userId).Any(x => x.ModalidadaId == profesorMateriaModalidad.ModalidadaId && x.MateriaId == profesorMateriaModalidad.MateriaId))
                {
                    db.ProfesorMateriaModalidades.Add(profesorMateriaModalidad);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                { 
                    ViewBag.mensaje = "Modalidad ya existente";
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ApplicationUserId = User.Identity.GetUserId();
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "NombreMateria", profesorMateriaModalidad.MateriaId);
            ViewBag.ModalidadaId = new SelectList(db.Modalidades, "Id", "TiposDeModalidad", profesorMateriaModalidad.ModalidadaId);
            return View(profesorMateriaModalidad);
        }

        // GET: ProfesorMateriaModalidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesorMateriaModalidad profesorMateriaModalidad = db.ProfesorMateriaModalidades.Find(id);
            if (profesorMateriaModalidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = User.Identity.GetUserId();
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "NombreMateria", profesorMateriaModalidad.MateriaId);
            ViewBag.ModalidadaId = new SelectList(db.Modalidades, "Id", "TiposDeModalidad", profesorMateriaModalidad.ModalidadaId);
            return View(profesorMateriaModalidad);
        }

        // POST: ProfesorMateriaModalidads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MateriaId,ApplicationUserId,ModalidadaId,Precio")] ProfesorMateriaModalidad profesorMateriaModalidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesorMateriaModalidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = User.Identity.GetUserId();
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "NombreMateria", profesorMateriaModalidad.MateriaId);
            ViewBag.ModalidadaId = new SelectList(db.Modalidades, "Id", "TiposDeModalidad", profesorMateriaModalidad.ModalidadaId);
            return View(profesorMateriaModalidad);
        }

        // GET: ProfesorMateriaModalidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesorMateriaModalidad profesorMateriaModalidad = db.ProfesorMateriaModalidades.Find(id);
            if (profesorMateriaModalidad == null)
            {
                return HttpNotFound();
            }
            return View(profesorMateriaModalidad);
        }

        // POST: ProfesorMateriaModalidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfesorMateriaModalidad profesorMateriaModalidad = db.ProfesorMateriaModalidades.Find(id);
            db.ProfesorMateriaModalidades.Remove(profesorMateriaModalidad);
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
