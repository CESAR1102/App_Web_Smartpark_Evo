using System.Collections.Generic;
using System.Linq;
using Smartpark.Domain;
using Smartpark.Repository.Context;

namespace Smartpark.Repository.Implementacion
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private ApplicationDbContext context;

        public AdministradorRepository(ApplicationDbContext context) {

            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var administrador= context.Administradores.Single(x => x.Id == id);
                context.Remove(administrador);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Administrador Get(int id)
        {
            var result = new Administrador();
            try
            {
                result = context.Administradores.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Administrador> GetAll()
        {
            var result = new List<Administrador>();
            try
            {
                result = context.Administradores.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Administrador entity)
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

        public bool Update(Administrador entity)
        {
             try
            {
                var administrador = context.Administradores.Single(x => x.Id == entity.Id);

                administrador.Id = entity.Id;
                administrador.Contraseña = entity.Contraseña;
                administrador.Nombre_adm = entity.Nombre_adm;

                administrador.Apellido_adm = entity.Apellido_adm;

                context.Update(administrador);
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