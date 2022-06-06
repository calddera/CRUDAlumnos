using CRUDAlumnos.Models.Services;
using CRUDAlumnos.Models.ViewModels.Grados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDAlumnos.Controllers
{
    public class GradosController : Controller
    {
        private GradoService _gradoService { get; set; }
        private ProfesorService _profesorService { get; set; }

        public GradosController()
        {
            _gradoService = new GradoService();
            _profesorService = new ProfesorService();
        }
        // GET: Alumnos
        public ActionResult Index()
        {
            var data = _gradoService.GetAll();
            return View(data);
        }

        // GET: Grados/Create
        public ActionResult Create()
        {
            var grado = new GradoViewModel();
            grado.lstProfesores = _profesorService.GetAllList();
            return View(grado);
        }

        // POST: Gradoes/Create
        [HttpPost]
        public ActionResult Create(GradoViewModel grado)
        {
            try
            {
                _gradoService.Create(grado);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gradoes/Edit/5
        public ActionResult Edit(int id)
        {
            GradoViewModel Grado = _gradoService.Get(id);
            Grado.lstProfesores = _profesorService.GetAllList();
            return View(Grado);
        }

        // POST: Gradoes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GradoViewModel grado)
        {
            try
            {
                _gradoService.Update(id, grado);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gradoes/Delete/5
        public ActionResult Delete(int id)
        {
            var alumno = _gradoService.Get(id);
            return View(alumno);
        }

        // POST: Gradoes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GradoViewModel Grado)
        {
            try
            {
                _gradoService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}