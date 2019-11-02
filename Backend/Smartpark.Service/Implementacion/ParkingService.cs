using System.Collections.Generic;
using Smartpark.Domain;
using Smartpark.Repository;

namespace Smartpark.Service.Implementacion
{
    public class ParkingService : IParkingService
    {
         private IParkingRepository parkingRepository;

        public ParkingService(IParkingRepository parkingRepository)
        {
            this.parkingRepository =parkingRepository;
        }

        public bool Delete(int id)
        {
             return parkingRepository.Delete(id);
        }

        public Parking Get(int id)
        {
             return parkingRepository.Get(id);
        }

        public IEnumerable<Parking> GetAll()
        {
            return parkingRepository.GetAll();
        }

        public bool Save(Parking entity)
        {
            return parkingRepository.Save(entity);
        }

        public bool Update(Parking entity)
        {
            return parkingRepository.Update(entity);
        }
    }
}