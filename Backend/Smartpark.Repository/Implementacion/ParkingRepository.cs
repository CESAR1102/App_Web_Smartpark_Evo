using System.Collections.Generic;
using System.Linq;
using Smartpark.Domain;
using Smartpark.Repository.Context;

namespace Smartpark.Repository.Implementacion
{
    public class ParkingRepository : IParkingRepository
    {
        private ApplicationDbContext context;
        public ParkingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Parking Get(int id)
        {
            var result = new Parking();
            try
            {
                result = context.Parkings.Single(x => x.Id == id);
                
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Parking> GetAll()
        {
            var result = new List<Parking>();
            try
            {
                result = context.Parkings.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Parking entity)
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

        public bool Update(Parking entity)
        {
            try
            {
                 var estacionamientoOrigina = context.Parkings.Single(
                     x => x.Id == entity.Id
                 );

                 estacionamientoOrigina.Id=entity.Id;
                 estacionamientoOrigina.Nombre_estacionamiento=entity.Nombre_estacionamiento;
                 estacionamientoOrigina.Direccion=entity.Direccion;
                 estacionamientoOrigina.Descripcion=entity.Descripcion;
                 estacionamientoOrigina.Pais=entity.Pais;
                 estacionamientoOrigina.Telefono=entity.Telefono;
                 estacionamientoOrigina.Localizacion=entity.Localizacion;
                 estacionamientoOrigina.administradorId=entity.administradorId;
                 context.Update(estacionamientoOrigina);
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