using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUDAlumnos.Data.Repositories
{
    public class GradoRepository
    {
        private crudalumnosEntities context { get; set; }
        public GradoRepository()
        {
            context = new crudalumnosEntities();
        }
        public grado Create(grado grado)
        {
            try
            {
                context.grado.Add(grado);
                context.SaveChanges();
                return grado;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }
        public grado Get(int id)
        {
            try
            {
                var _grado = context.grado.Include(x=>x.profesor).FirstOrDefault(x=>x.Id == id);
                return _grado;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }

        public List<grado> GetAll()
        {
            try
            {
                var _grado = context.grado.ToList();
                return _grado;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }
        public grado Update(int id, grado grado)
        {
            try
            {
                var _grado = context.grado.Find(id);
                _grado.Nombre = grado.Nombre;
                _grado.ProfesorId = grado.ProfesorId;
                context.SaveChanges();
                return _grado;

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
                var _grado = context.grado.Find(id);
                context.grado.Remove(_grado);
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