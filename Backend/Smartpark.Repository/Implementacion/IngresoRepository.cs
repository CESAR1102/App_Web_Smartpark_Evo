using System.Collections.Generic;
using System.Linq;
using Smartpark.Domain;
using Smartpark.Repository.Context;

namespace Smartpark.Repository.Implementacion
{
    public class IngresoRepository : IIngresoRepository
    {
        private ApplicationDbContext context;
        public IngresoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
             var rpta=false;
            
           try
           {
             var aux=context.Ingresos.Single(x=>x.Id==id);
             context.Ingresos.Remove(aux);
             context.SaveChanges();   
           }
           catch (System.Exception)
           {
               
               throw;
           }
           return rpta;
        }

        public Ingreso Get(int id)
        {
            var result= new Ingreso();
            try
            {
                result=context.Ingresos.Single(x=>x.Id==id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Ingreso> GetAll()
        {
            var result=new List<Ingreso>();
            try
            {
                result= context.Ingresos.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Ingreso entity)
        {
            var rpta=false;
            
           try
           {
            
             context.Ingresos.Remove(entity);
             context.SaveChanges();   
           }
           catch (System.Exception)
           {
               
               throw;
           }
           return rpta;
        }

        public bool Update(Ingreso entity)
        {
            var rpta=false;
            
           try
           {
            var IngresoAux=context.Ingresos.Single(x=>x.Id==entity.Id);
            IngresoAux.Id=entity.Id;
            IngresoAux.Placa=entity.Placa;
            IngresoAux.HInicio=entity.HInicio;
            IngresoAux.CajeroId=entity.CajeroId;
            IngresoAux.EspacioId=entity.EspacioId;
            IngresoAux.TarifaId=entity.TarifaId;

             context.Ingresos.Update(IngresoAux);
             context.SaveChanges();   
           }
           catch (System.Exception)
           {
               
               throw;
           }
           return rpta;
        }
    }
}