using CRUDAlumnos.Data.Repositories;
using CRUDAlumnos.Models.ViewModels.Grados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Models.Services
{
    public class GradoService
    {
        private GradoRepository _gradoRepo { get; set; }
        public GradoService()
        {
            _gradoRepo = new GradoRepository();
        }

        public List<ListaGradosViewModel> GetAll()
        {
            List<ListaGradosViewModel> response = new List<ListaGradosViewModel>();
            var data = _gradoRepo.GetAll();

            if (data != null && data.Any())
            {
                data.ForEach(e =>
                {
                    response.Add(new ListaGradosViewModel()
                    {
                        Id = e.Id,
                        Name = e.Nombre,
                        ProfesorName = $"{e.profesor.Nombre} {e.profesor.Apellidos}"
                    });
                });
            }
            return response;
        }

        internal void Create(GradoViewModel grado)
        {
            try
            {
                _gradoRepo.Create(new Data.grado()
                {
                    Nombre = grado.Name,
                    ProfesorId = grado.ProfesorId
                });
            }
            catch (Exception)
            {
                // Registrar la excepción
            }
        }

        internal void Update(int id, GradoViewModel grado)
        {
            try
            {
                _gradoRepo.Update(id, new Data.grado()
                {
                    Nombre = grado.Name,
                    ProfesorId = grado.ProfesorId
                });
            }
            catch (Exception)
            {
                // Registrar la excepción
            }
        }

        internal GradoViewModel Get(int id)
        {
            try
            {
                GradoViewModel response = new GradoViewModel();
                var data = _gradoRepo.Get(id);

                if (data != null)
                {
                    response.Id = data.Id;
                    response.Name = data.Nombre;
                    response.ProfesorId = data.ProfesorId;

                    return response;
                }
            }
            catch (Exception)
            {
                // Registrar la excepción
            }
            return new GradoViewModel();
        }

        internal void Delete(int id)
        {
            try
            {
                _gradoRepo.Delete(id);
            }
            catch (Exception ex)
            {
                // Registrar la excepción
            }
        }
    }
}