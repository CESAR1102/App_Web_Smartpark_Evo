using System.Collections.Generic;
using Smartpark.Domain;
using Smartpark.Repository;

namespace Smartpark.Service.Implementacion
{
    public class ServicioService : IServicioService
    {
         private IServicioRepository servicioRepository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            this.servicioRepository =servicioRepository;
        }
        public bool Delete(int id)
        {
             return servicioRepository.Delete(id);
        }

        public Servicio Get(int id)
        {
            return servicioRepository.Get(id);
        }

        public IEnumerable<Servicio> GetAll()
        {
           return servicioRepository.GetAll();
        }

        public bool Save(Servicio entity)
        {
            return servicioRepository.Save(entity);
        }

        public bool Update(Servicio entity)
        {
            return servicioRepository.Update(entity);
        }
    }
}