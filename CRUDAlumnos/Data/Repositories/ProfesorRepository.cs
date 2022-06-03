using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Data.Repositories
{
    public class ProfesorRepository
    {
        private crudalumnosEntities context { get; set; }
        public ProfesorRepository()
        {
            context = new crudalumnosEntities();
        }
        public profesor Create(profesor profesor)
        {
            try
            {
                context.profesor.Add(profesor);
                context.SaveChanges();
                return profesor;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }
        public profesor Get(int id)
        {
            try
            {
                var _profesor = context.profesor.Find(id);
                return _profesor;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }
        public profesor Update(int id, profesor profesor)
        {
            try
            {
                var _profesor = context.profesor.Find(id);
                _profesor.Nombre = profesor.Nombre;
                _profesor.Apellidos = profesor.Apellidos;
                _profesor.GeneroId = profesor.GeneroId;

                context.SaveChanges();
                return _profesor;

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
                var _profesor = context.profesor.Find(id);
                context.profesor.Remove(_profesor);
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