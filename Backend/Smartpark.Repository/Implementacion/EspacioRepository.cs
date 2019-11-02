using System.Collections.Generic;
using System.Linq;
using Smartpark.Domain;
using Smartpark.Repository.Context;

namespace Smartpark.Repository.Implementacion
{
    public class EspacioRepository : IEspacioRepository
    {
         private ApplicationDbContext context;

        public EspacioRepository(ApplicationDbContext context)
        {
            this.context=context;
        }
        public bool Delete(int id)
        {
            try
            {
                var result = context.Espacios.Single(x => x.Nro_espacio == id);
                context.Remove(result);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public Espacio Get(int id)
        {
            var result = new Espacio();
            try
            {
                result = context.Espacios.Single(x => x.Nro_espacio == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Espacio> GetAll()
        {
            var result = new List<Espacio>();
            try
            {
                result = context.Espacios.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Espacio entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool Update(Espacio entity)
        {
            try
            {
                 var espacio = context.Espacios.Single(
                     x => x.Nro_espacio == entity.Nro_espacio
                 );

                espacio.Nro_espacio = entity.Nro_espacio;
                espacio.id_parking = entity.id_parking;
                espacio.Identificador = entity.Identificador;
                espacio.Disponibilidad_espacio=entity.Disponibilidad_espacio;

                 context.Update(espacio);
                 context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }
    }
}