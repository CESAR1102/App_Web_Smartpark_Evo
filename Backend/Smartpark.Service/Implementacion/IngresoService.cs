using System.Collections.Generic;
using Smartpark.Domain;
using Smartpark.Repository;

namespace Smartpark.Service.Implementacion
{
    public class IngresoService : IIngresoService
    {
        private IIngresoRepository ingresorepository;
        public IngresoService(IIngresoRepository ingresoRepository){
            this.ingresorepository=ingresoRepository;
        }
        public bool Delete(int id)
        {
            return ingresorepository.Delete(id);
        }

        public Ingreso Get(int id)
        {
            return ingresorepository.Get(id);
        }

        public IEnumerable<Ingreso> GetAll()
        {
            return ingresorepository.GetAll();
        }

        public bool Save(Ingreso entity)
        {
            return ingresorepository.Save(entity);
        }

        public bool Update(Ingreso entity)
        {
            return ingresorepository.Update(entity);
        }
    }
}