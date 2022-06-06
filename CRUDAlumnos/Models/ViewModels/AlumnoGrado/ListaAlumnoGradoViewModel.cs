using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Models.ViewModels.AlumnoGrado
{
    public class ListaAlumnoGradoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Alumno")]
        public string AlumnoName { get; set; }
        [Display(Name = "Grado")]
        public string GradoName { get; set; }
        [Display(Name = "Sección")]
        public string SeccionName { get; set; }
    }
}