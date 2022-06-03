using CRUDAlumnos.Data.Repositories;
using CRUDAlumnos.Models.ViewModels.Alumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Models.Services
{
    public class AlumnoService
    {
        private AlumnoRepository _alumnoRepo { get; set; }
        public AlumnoService()
        {
            _alumnoRepo = new AlumnoRepository();
        }

        public List<ListaAlumnosViewModel> GetAll()
        {
            List<ListaAlumnosViewModel> response = new List<ListaAlumnosViewModel>();
            var data = _alumnoRepo.GetAll();

            if (data != null && data.Any())
            {
                data.ForEach(e =>
                {
                    response.Add(new ListaAlumnosViewModel()
                    {
                        Id = e.Id,
                        Birthday = e.FechaNac,
                        GeneroName = e.genero.Nombre,
                        Name = e.Nombre,
                        SurName = e.Apellidos
                    });
                });
            }
            return response;
        }

        internal void Create(AlumnoViewModel alumno)
        {
            try
            {
                _alumnoRepo.Create(new Data.alumno()
                {
                    Nombre = alumno.Name,
                    Apellidos = alumno.SurName,
                    FechaNac = alumno.Birthday,
                    GeneroId = alumno.GeneroId
                });
            }
            catch (Exception)
            {
                // Registrar la excepción
            }
        }

        internal void Update(int id, AlumnoViewModel alumno)
        {
            try
            {
                _alumnoRepo.Update(id, new Data.alumno()
                {
                    Nombre = alumno.Name,
                    Apellidos = alumno.SurName,
                    FechaNac = alumno.Birthday,
                    GeneroId = alumno.GeneroId
                });
            }
            catch (Exception)
            {
                // Registrar la excepción
            }
        }

        internal AlumnoViewModel Get(int id)
        {
            try
            {
                AlumnoViewModel response = new AlumnoViewModel();
                var data = _alumnoRepo.Get(id);

                if (data != null)
                {
                    response.Id = data.Id;
                    response.Birthday = data.FechaNac;
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
            return new AlumnoViewModel();
        }

        internal void Delete(int id)
        {
            try
            {
                _alumnoRepo.Delete(id);
            }
            catch (Exception ex)
            {
                // Registrar la excepción
            }
        }
    }
}