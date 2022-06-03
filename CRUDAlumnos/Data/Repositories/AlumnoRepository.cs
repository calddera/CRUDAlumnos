using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUDAlumnos.Data.Repositories
{
    public class AlumnoRepository
    {
        private crudalumnosEntities context { get; set; }
        public AlumnoRepository()
        {
            context = new crudalumnosEntities();
        }
        public alumno Create(alumno alumno)
        {
            try
            {
                context.alumno.Add(alumno);
                context.SaveChanges();
                return alumno;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }

        public alumno Get(int id)
        {
            try
            {
                var _alumno = context.alumno.Include(x => x.genero).FirstOrDefault(x=>x.Id == id);
                return _alumno;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }

        public List<alumno> GetAll()
        {
            try
            {
                var _alumnos = context.alumno.Include(x => x.genero).ToList();
                return _alumnos;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }

        public alumno Update(int id, alumno alumno)
        {
            try
            {
                var _alumno = context.alumno.Find(id);
                _alumno.Nombre = alumno.Nombre;
                _alumno.Apellidos = alumno.Apellidos;
                _alumno.FechaNac = alumno.FechaNac;
                _alumno.GeneroId = alumno.GeneroId;
                
                context.SaveChanges();
                return _alumno;

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
                var _alumno = context.alumno.Find(id);
                context.alumno.Remove(_alumno);
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