using CRUDAlumnos.Models.Services;
using CRUDAlumnos.Models.ViewModels.Alumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDAlumnos.Controllers
{
    public class AlumnosController : Controller
    {
        private AlumnoService _alumnoService { get; set; }
        private GeneroService _generoService { get; set; }
        public AlumnosController()
        {
            _alumnoService = new AlumnoService();
            _generoService = new GeneroService();
        }
        // GET: Alumnos
        public ActionResult Index()
        {
            var data = _alumnoService.GetAll();
            return View(data);
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            var alumno = new AlumnoViewModel();
            alumno.lstGeneros = _generoService.GetAll();
            return View(alumno);
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(AlumnoViewModel alumno)
        {
            try
            {
                _alumnoService.Create(alumno);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int id)
        {
            AlumnoViewModel alumno =  _alumnoService.Get(id);
            alumno.lstGeneros = _generoService.GetAll();
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AlumnoViewModel alumno)
        {
            try
            {
                _alumnoService.Update(id, alumno);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int id)
        {
            var alumno = _alumnoService.Get(id);
            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AlumnoViewModel alumno)
        {
            try
            {
                _alumnoService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
