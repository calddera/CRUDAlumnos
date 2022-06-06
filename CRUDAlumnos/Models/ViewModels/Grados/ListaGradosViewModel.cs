using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Models.ViewModels.Grados
{
    public class ListaGradosViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre(s)")]
        public string Name { get; set; }

        [Display(Name = "Profesor")]
        public string ProfesorName { get; set; }
    }
}