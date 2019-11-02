using System.Collections.Generic;
using System.Linq;
using Smartpark.Domain;
using Smartpark.Repository.Context;

namespace Smartpark.Repository.Implementacion
{
    public class ServicioRepository : IServicioRepository
    {
         private ApplicationDbContext context;

        public ServicioRepository(ApplicationDbContext context)
        {
            this.context=context;
        }
        public bool Delete(int id)
        {
           try
            {
                var servicio = context.Tarifas.Single(x => x.Id == id);
                context.Remove(servicio);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public Servicio Get(int id)
        {
            var result = new Servicio();
            try
            {
                result = context.Servicios.Single(x => x.Id== id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Servicio> GetAll()
        {
            var result = new List<Servicio>();
            try
            {
                result = context.Servicios.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Servicio entity)
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

        public bool Update(Servicio entity)
        {
             try
            {
                var servicio = context.Servicios.Single(x => x.Id== entity.Id);
                servicio.Id = entity.Id;
                servicio.Tipo_servicio = entity.Tipo_servicio;
                servicio.Descripcion = entity.Descripcion;
                servicio.Costo_servicio = entity.Costo_servicio;

                context.Update(servicio);
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