using CRUDAlumnos.Data.Repositories;
using CRUDAlumnos.Models.ViewModels.Profesor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Models.Services
{
    public class ProfesorService
    {
        private ProfesorRepository _profesorRepo { get; set; }
        public ProfesorService()
        {
            _profesorRepo = new ProfesorRepository();
        }

        public List<ListaProfesoresViewModel> GetAll()
        {
            List<ListaProfesoresViewModel> response = new List<ListaProfesoresViewModel>();
            var data = _profesorRepo.GetAll();

            if (data != null && data.Any())
            {
                data.ForEach(e =>
                {
                    response.Add(new ListaProfesoresViewModel()
                    {
                        Id = e.Id,
                        GeneroName = e.genero.Nombre,
                        Name = e.Nombre,
                        SurName = e.Apellidos
                    });
                });
            }
            return response;
        }

        public List<ProfesorViewModel> GetAllList()
        {
            List<ProfesorViewModel> response = new List<ProfesorViewModel>();
            var data = _profesorRepo.GetAll();

            if (data != null && data.Any())
            {
                data.ForEach(e =>
                {
                    response.Add(new ProfesorViewModel()
                    {
                        Id = e.Id,
                        Name = $"{e.Nombre} {e.Apellidos}"
                    });
                });
            }
            return response;

        }

        internal void Create(ProfesorViewModel alumno)
        {
            try
            {
                _profesorRepo.Create(new Data.profesor()
                {
                    Nombre = alumno.Name,
                    Apellidos = alumno.SurName,
                    GeneroId = alumno.GeneroId
                });
            }
            catch (Exception)
            {
                // Registrar la excepción
            }
        }

        internal void Update(int id, ProfesorViewModel alumno)
        {
            try
            {
                _profesorRepo.Update(id, new Data.profesor()
                {
                    Nombre = alumno.Name,
                    Apellidos = alumno.SurName,
                    GeneroId = alumno.GeneroId
                });
            }
            catch (Exception)
            {
                // Registrar la excepción
            }
        }

        internal ProfesorViewModel Get(int id)
        {
            try
            {
                ProfesorViewModel response = new ProfesorViewModel();
                var data = _profesorRepo.Get(id);

                if (data != null)
                {
                    response.Id = data.Id;
                    response.GeneroId = data.GeneroId;
                    response.Name = data.Nombre;
                    response.SurName = data.Apellidos;
                    return response;
                }
            }
            catch (Exception)
            {
                // Registrar la excepción
            }
            return new ProfesorViewModel();
        }

        internal void Delete(int id)
        {
            try
            {
                _profesorRepo.Delete(id);
            }
            catch (Exception ex)
            {
                // Registrar la excepción
            }
        }
    }
}