using System;

namespace Smartpark.Domain
{
    public class Comprobante
    {
        public int Id {get; set;}
        public int cod_ingreso {get; set;}
        public Ingreso Ingreso {get; set;}
        public DateTime horaIni {get; set;}
        public DateTime horaFin {get; set;}
        public double monto {get; set;}

    }
}