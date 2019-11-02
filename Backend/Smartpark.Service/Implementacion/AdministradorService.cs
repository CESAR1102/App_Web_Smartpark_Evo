using System.Collections.Generic;
using Smartpark.Domain;
using Smartpark.Repository;

namespace Smartpark.Service.Implementacion
{
    public class AdministradorService : IAdministradorService
    {
        private IAdministradorRepository administradorRepository;

        public AdministradorService(IAdministradorRepository administradorRepository)
        {
            this.administradorRepository=administradorRepository;
        }
        public bool Delete(int id)
        {
            return administradorRepository.Delete(id);
        }

        public Administrador Get(int id)
        {
            return administradorRepository.Get(id);
        }

        public IEnumerable<Administrador> GetAll()
        {
            return administradorRepository.GetAll();
        }

        public bool Save(Administrador entity)
        {
            return administradorRepository.Save(entity);
        }

        public bool Update(Administrador entity)
        {
            return administradorRepository.Update(entity);
        }
    }
}