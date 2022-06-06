using CRUDAlumnos.Models.ViewModels.Profesor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Models.ViewModels.Grados
{
    public class GradoViewModel
    {
        public GradoViewModel()
        {
            lstProfesores = new List<ProfesorViewModel>();
        }

        public int Id { get; set; }

        [Display(Name = "Nombre(s)")]
        public string Name { get; set; }

        [Display(Name = "Profesor")]
        public int ProfesorId { get; set; }

        public List<ProfesorViewModel> lstProfesores { get; set; }
    }
}