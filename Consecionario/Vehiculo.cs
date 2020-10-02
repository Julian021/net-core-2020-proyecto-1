using System;

namespace Concesionario
{
    public interface Vehiculo
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Patente { get;  set; }
        public int Anio { get; set; }



        // Añadir más propiedades de un vehiculo en venta como lo requiere la logica de negocio.

        public int Costo { get; set; }
        public bool FueVendido { get; }

        double Precio();


        void Vender(Comprador comprador);

    }
}