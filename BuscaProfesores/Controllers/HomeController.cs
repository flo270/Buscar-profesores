using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuscaProfesores.Models;

namespace BuscaProfesores.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ApplicationDbContext db = new ApplicationDbContext();


            var materias = db.Materias.ToList();
            return View(materias);
        }

      
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult buscarMateria(string materiaIngresada)
        {
            //materiaIngresada = "Matematica";
            ApplicationDbContext db = new ApplicationDbContext();

            var join =
                from pmm in db.ProfesorMateriaModalidades
                join materia in db.Materias
                on pmm.MateriaId equals materia.Id
                join modalidades in db.Modalidades
                on pmm.ModalidadaId equals modalidades.Id
                join user in db.Users
                on pmm.ApplicationUserId equals user.Id
                where materia.NombreMateria == materiaIngresada
                select new JoinProfesorMateriaModalida { id = pmm.Id, Materia = materia, Modalidad = modalidades, ApplicationUser = user, Precio = pmm.Precio };

            List<ContenedorProfesorMateriaModalidad> lista = new List<ContenedorProfesorMateriaModalidad>();
            foreach (var profesor in join)
            {
                if (lista == null)
                {
                    ContenedorProfesorMateriaModalidad v = new ContenedorProfesorMateriaModalidad();
                    v.AplicationUserId = profesor.ApplicationUser.Id;
                    v.Nombre = profesor.ApplicationUser.Nombre;
                    v.Apellido = profesor.ApplicationUser.Apellido;
                    v.Direccion = profesor.ApplicationUser.Direccion;
                    v.Telefono = profesor.ApplicationUser.Telefono;
                    v.Email = profesor.ApplicationUser.Email;
                    ContenedorModalidad vm = new ContenedorModalidad(profesor.Modalidad.TiposDeModalidad, profesor.Precio);
                    v.ContenedorDeModalidades.Add(vm);
                    lista.Add(v);
                }

                bool profesorAgregado = false;
                foreach (var x in lista)
                {
                    if (profesor.ApplicationUser.Id == x.AplicationUserId)
                    {
                        ContenedorModalidad m = new ContenedorModalidad(profesor.Modalidad.TiposDeModalidad, profesor.Precio);
                        x.ContenedorDeModalidades.Add(m);
                        profesorAgregado = true;
                        break;
                    }

                }

                if (!profesorAgregado)
                {
                    ContenedorProfesorMateriaModalidad z = new ContenedorProfesorMateriaModalidad();
                    z.AplicationUserId = profesor.ApplicationUser.Id;
                    z.Nombre = profesor.ApplicationUser.Nombre;
                    z.Apellido = profesor.ApplicationUser.Apellido;
                    z.Direccion = profesor.ApplicationUser.Direccion;
                    z.Telefono = profesor.ApplicationUser.Telefono;
                    z.Email = profesor.ApplicationUser.Email;
                    ContenedorModalidad zm = new ContenedorModalidad(profesor.Modalidad.TiposDeModalidad, profesor.Precio);
                    z.ContenedorDeModalidades.Add(zm);
                    lista.Add(z);
                }

            }


            if (materiaIngresada == null)
            {
                ViewBag.error = "No se ingreso materia";
                return View("Error");
            }
            else
            {
                ViewBag.materia = materiaIngresada.ToUpper();
                return View(lista);
            }
            
        }

    }
}