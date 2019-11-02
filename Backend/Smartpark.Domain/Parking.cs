namespace Smartpark.Domain
{
    public class Parking
    {
        public int Id { get; set; }

        public string Nombre_estacionamiento { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
        public string Pais { get; set; }
        public int Telefono { get; set; }
        public string Localizacion { get; set; }
        public int administradorId { get; set; }
        public Administrador administrador {get; set;}
    }
}