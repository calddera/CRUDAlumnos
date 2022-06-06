using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Data.Repositories
{
    public class AlumnoGradoRepository
    {
        private crudalumnosEntities context { get; set; }
        public AlumnoGradoRepository()
        {
            context = new crudalumnosEntities();
        }
        public alumno_grado Create(alumno_grado alumnogrado)
        {
            try
            {
                context.alumno_grado.Add(alumnogrado);
                context.SaveChanges();
                return alumnogrado;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }

        public alumno_grado Get(int id)
        {
            try
            {
                var _alumnogrado = context.alumno_grado.Find(id);
                return _alumnogrado;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }

        public List<alumno_grado> GetAll()
        {
            try
            {
                var _alumnosgrado = context.alumno_grado.ToList();
                return _alumnosgrado;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }

        public alumno_grado Update(int id, alumno_grado alumno)
        {
            try
            {
                var _alumnogrado = context.alumno_grado.Find(id);
                _alumnogrado.AlumnoId = alumno.AlumnoId;
                _alumnogrado.GradoId = alumno.GradoId;
                _alumnogrado.SeccionId = alumno.SeccionId;

                context.SaveChanges();
                return _alumnogrado;

            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var _alumnogrado = context.alumno_grado.Find(id);
                context.alumno_grado.Remove(_alumnogrado);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return false;
            }
        }
    }
}