using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAlumnos.Data.Repositories
{
    public class GeneroRepository
    {
        private crudalumnosEntities context { get; set; }
        public GeneroRepository()
        {
            context = new crudalumnosEntities();
        }

        public List<genero> GetAll()
        {
            try
            {
                var _generos = context.genero.ToList();
                return _generos;
            }
            catch (Exception ex)
            {
                // Registrar la excepción en algún log o DB
                return null;
            }
        }
    }
}