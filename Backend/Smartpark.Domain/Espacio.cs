namespace Smartpark.Domain
{
    public class Espacio
    {
        public int Id  { get; set; }
        public string Identificador {get; set;}
        public bool Disponibilidad_espacio { get; set; }
        public int id_parking { get; set; }
        public Parking parking { get; set; }
    }
}