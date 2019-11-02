using System;

namespace Smartpark.Domain
{
    public class Ingreso
    {
        public int Id {get;set;}
        public int TarifaId {get; set;}
        public Tarifa Tarifa {get; set;}
        public int CajeroId {get; set;}
        public Cajero Cajero{get;set;}
        public string Placa{get;set;}
        public  DateTime HInicio{get;set;}
        public int EspacioId {get; set;}
        Espacio Espacio {get; set;}
    }
}