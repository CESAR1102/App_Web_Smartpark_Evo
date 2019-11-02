using System.Collections.Generic;
using System.Linq;
using Smartpark.Domain;
using Smartpark.Repository.Context;

namespace Smartpark.Repository.Implementacion
{
    public class TarifaRepository : ITarifaRepository
    {
        private ApplicationDbContext context;

        public TarifaRepository(ApplicationDbContext context)
        {
            this.context=context;
        }
        public bool Delete(int id)
        {
             try
            {
                var tarifa = context.Tarifas.Single(x => x.Id == id);
                context.Remove(tarifa);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public Tarifa Get(int id)
        {
            var result = new Tarifa();
            try
            {
                result = context.Tarifas.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Tarifa> GetAll()
        {
            var result = new List<Tarifa>();
            try
            {
                result = context.Tarifas.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Tarifa entity)
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

        public bool Update(Tarifa entity)
        {
            try
            {
                var tarifa = context.Tarifas.Single(x => x.Id == entity.Id);
                tarifa.Id = entity.Id;
                tarifa.Monto = entity.Monto;
                tarifa.Tipo_vehiculo = entity.Tipo_vehiculo;

                context.Update(tarifa);
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