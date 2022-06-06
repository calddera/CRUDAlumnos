using CRUDAlumnos.Models.ViewModels.Genero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Models.ViewModels.Profesor
{
    public class ProfesorViewModel
    {
        public ProfesorViewModel()
        {
            lstGeneros = new List<GeneroViewModel>();
        }

        public int Id { get; set; }

        [Display(Name = "Nombre(s)")]
        public string Name { get; set; }

        [Display(Name = "Apellidos")]
        public string SurName { get; set; }

        [Display(Name = "Género")]
        public int GeneroId { get; set; }

        public List<GeneroViewModel> lstGeneros { get; set; }
    }
}