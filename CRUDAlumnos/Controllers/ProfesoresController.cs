using CRUDAlumnos.Models.Services;
using CRUDAlumnos.Models.ViewModels.Profesor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDAlumnos.Controllers
{
    public class ProfesoresController : Controller
    {
        private ProfesorService _profesorService { get; set; }
        private GeneroService _generoService { get; set; }
        public ProfesoresController()
        {
            _profesorService = new ProfesorService();
            _generoService = new GeneroService();
        }
        // GET: Profesores
        public ActionResult Index()
        {
            var data = _profesorService.GetAll();
            return View(data);
        }

        // GET: Profesores/Create
        public ActionResult Create()
        {
            var grado = new ProfesorViewModel();
            grado.lstGeneros = _generoService.GetAll();
            return View(grado);
        }

        // POST: Profesores/Create
        [HttpPost]
        public ActionResult Create(ProfesorViewModel alumno)
        {
            try
            {
                _profesorService.Create(alumno);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profesores/Edit/5
        public ActionResult Edit(int id)
        {
            ProfesorViewModel profesor = _profesorService.Get(id);
            profesor.lstGeneros = _generoService.GetAll();
            return View(profesor);
        }

        // POST: Profesores/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProfesorViewModel alumno)
        {
            try
            {
                _profesorService.Update(id, alumno);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profesores/Delete/5
        public ActionResult Delete(int id)
        {
            var alumno = _profesorService.Get(id);
            return View(alumno);
        }

        // POST: Profesores/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProfesorViewModel profesor)
        {
            try
            {
                _profesorService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}