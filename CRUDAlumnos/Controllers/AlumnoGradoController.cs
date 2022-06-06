using CRUDAlumnos.Models.Services;
using CRUDAlumnos.Models.ViewModels.AlumnoGrado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDAlumnos.Controllers
{
    public class AlumnoGradoController : Controller
    {
        private AlumnoGradoService _alumnogradoService { get; set; }
        private AlumnoService _alumnoService { get; set; }
        private GradoService _gradoService { get; set; }
        private SeccionService _seccionService { get; set; }
        

        public AlumnoGradoController()
        {
            _alumnogradoService = new AlumnoGradoService();
            _alumnoService = new AlumnoService();
            _gradoService = new GradoService();
            _seccionService = new SeccionService();
        }
        // GET: Alumnos
        public ActionResult Index()
        {
            var data = _alumnogradoService.GetAll();
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
            var alumno = new AlumnoGradoViewModel();
            alumno.lstAlumnos = _alumnoService.GetAllList();
            alumno.lstGrados = _gradoService.GetAllList();
            alumno.lstSecciones = _seccionService.GetAllList();
            return View(alumno);
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(AlumnoGradoViewModel alumno)
        {
            try
            {
                _alumnogradoService.Create(alumno);
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
            AlumnoGradoViewModel alumno = _alumnogradoService.Get(id);
            alumno.lstAlumnos = _alumnoService.GetAllList();
            alumno.lstGrados = _gradoService.GetAllList();
            alumno.lstSecciones = _seccionService.GetAllList();
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AlumnoGradoViewModel alumno)
        {
            try
            {
                _alumnogradoService.Update(id, alumno);

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
            var alumno = _alumnogradoService.Get(id);
            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AlumnoGradoViewModel alumno)
        {
            try
            {
                _alumnogradoService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}