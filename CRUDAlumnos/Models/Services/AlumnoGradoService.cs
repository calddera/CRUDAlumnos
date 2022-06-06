using CRUDAlumnos.Data.Repositories;
using CRUDAlumnos.Models.ViewModels.AlumnoGrado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Models.Services
{
    public class AlumnoGradoService
    {
        private AlumnoGradoRepository _alumnogradoRepo { get; set; }
        public AlumnoGradoService()
        {
            _alumnogradoRepo = new AlumnoGradoRepository();
        }

        public List<ListaAlumnoGradoViewModel> GetAll()
        {
            List<ListaAlumnoGradoViewModel> response = new List<ListaAlumnoGradoViewModel>();
            var data = _alumnogradoRepo.GetAll();

            if (data != null && data.Any())
            {
                data.ForEach(e =>
                {
                    response.Add(new ListaAlumnoGradoViewModel()
                    {
                        Id = e.Id,
                        AlumnoName = $"{e.alumno.Nombre} {e.alumno.Apellidos}",
                        GradoName = e.grado.Nombre,
                        SeccionName = e.seccion.Nombre
                    });
                });
            }
            return response;                                
        }

        internal void Create(AlumnoGradoViewModel alumnogrado)
        {
            try
            {
                _alumnogradoRepo.Create(new Data.alumno_grado()
                {
                    AlumnoId = alumnogrado.AlumnoId,
                    GradoId = alumnogrado.GradoId,
                    SeccionId = alumnogrado.SeccionId
                });
            }
            catch (Exception)
            {
                // Registrar la excepción
            }
        }

        internal void Update(int id, AlumnoGradoViewModel alumnogrado)
        {
            try
            {
                _alumnogradoRepo.Update(id, new Data.alumno_grado()
                {
                    AlumnoId = alumnogrado.AlumnoId,
                    GradoId = alumnogrado.GradoId,
                    SeccionId = alumnogrado.SeccionId
                });
            }
            catch (Exception)
            {
                // Registrar la excepción
            }
        }

        internal AlumnoGradoViewModel Get(int id)
        {
            try
            {
                AlumnoGradoViewModel response = new AlumnoGradoViewModel();
                var data = _alumnogradoRepo.Get(id);

                if (data != null)
                {
                    response.Id = data.Id;
                    response.AlumnoId = data.AlumnoId;
                    response.GradoId = data.GradoId;
                    response.SeccionId = data.SeccionId;
                    return response;
                }
            }
            catch (Exception)
            {
                // Registrar la excepción
            }
            return new AlumnoGradoViewModel();
        }

        internal void Delete(int id)
        {
            try
            {
                _alumnogradoRepo.Delete(id);
            }
            catch (Exception ex)
            {
                // Registrar la excepción
            }
        }
    }
}