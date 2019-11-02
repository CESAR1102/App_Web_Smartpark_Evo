using System;

namespace Smartpark.Domain
{
    public class Cajero
    {
        public int Id { get; set; }
        public string Contraseña {get; set;}
        public string Nombre_Cajero { get; set; }
        public string Apellido_Cajero { get; set; }
        public DateTime Fecha_ingreso { get; set; }
        public string Turno_Cajero { get; set; }
        
    }
}