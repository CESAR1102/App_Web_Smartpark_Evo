
using Microsoft.EntityFrameworkCore;
using Smartpark.Domain;

namespace Smartpark.Repository.Context
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
         public DbSet<Comprobante> Comprobantes { get; set; }
         public DbSet<Cajero> Cajeros { get; set; }
         public DbSet<Ingreso> Ingresos{get;set;}
         public DbSet<Tarifa> Tarifas {get; set;}
         public DbSet<Espacio> Espacios {get; set;}
         public DbSet<IngresoServicio> IngresoServicios {get; set;}
         public DbSet<Parking> Parkings {get; set;}
         public DbSet<Servicio> Servicios {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }
        

    
    }
}