using CRUDAlumnos.Data.Repositories;
using CRUDAlumnos.Models.ViewModels.Genero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Models.Services
{
    public class GeneroService
    {
        private GeneroRepository _generoRepo { get; set; }
        public GeneroService()
        {
            _generoRepo = new GeneroRepository();
        }


        public List<GeneroViewModel> GetAll()
        {
            List<GeneroViewModel> response = new List<GeneroViewModel>();
            var data = _generoRepo.GetAll();

            if (data != null && data.Any())
            {
                data.ForEach(e =>
                {
                    response.Add(new GeneroViewModel()
                    {
                        Id = e.Id,
                        Name = e.Nombre
                    });
                });
            }
            return response;

        }
    }
}