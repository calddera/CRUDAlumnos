using CRUDAlumnos.Models.ViewModels.Alumnos;
using CRUDAlumnos.Models.ViewModels.Grados;
using CRUDAlumnos.Models.ViewModels.Seccion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Models.ViewModels.AlumnoGrado
{
    public class AlumnoGradoViewModel
    {
        public AlumnoGradoViewModel()
        {
            lstAlumnos = new List<AlumnoViewModel>();
            lstGrados = new List<GradoViewModel>();
            lstAlumnos = new List<AlumnoViewModel>();
        }

        public int Id { get; set; }
        [Display(Name = "Alumno")]
        public int AlumnoId { get; set; }
        public List<AlumnoViewModel> lstAlumnos { get; set; }
        [Display(Name = "Grado")]
        public int GradoId { get; set; }
        public List<GradoViewModel> lstGrados { get; set; }
        [Display(Name = "Sección")]
        public int SeccionId { get; set; }
        public List<SeccionViewModel> lstSecciones { get; set; }
    }
}