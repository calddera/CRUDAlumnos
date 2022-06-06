using CRUDAlumnos.Data.Repositories;
using CRUDAlumnos.Models.ViewModels.Seccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Models.Services
{
    public class SeccionService
    {
        private SeccionRepository _seccionRepo { get; set; }
        public SeccionService()
        {
            _seccionRepo = new SeccionRepository();
        }


        public List<SeccionViewModel> GetAllList()
        {
            List<SeccionViewModel> response = new List<SeccionViewModel>();
            var data = _seccionRepo.GetAll();

            if (data != null && data.Any())
            {
                data.ForEach(e =>
                {
                    response.Add(new SeccionViewModel()
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