using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Data.Repositories
{
    public class SeccionRepository
    {
        private crudalumnosEntities context { get; set; }
        public SeccionRepository()
        {
            context = new crudalumnosEntities();
        }

        public List<seccion> GetAll()
        {
            try
            {
                var _secciones = context.seccion.ToList();
                return _secciones;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }
    }
}