namespace Smartpark.Domain
{
    public class IngresoServicio
    {
        public int Id { get; set; }
        public int ingresoId { get; set; }
        public Ingreso ingreso {get; set;}
        public int servicioId { get; set; }
        public Servicio servicio {get; set;}
        
    }
}