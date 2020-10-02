using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Concesionario
{
    public class Automovil : Vehiculo
    {
        //Funcion Constructora
        public Automovil(string marcaAuto,string modeloAuto, int anioFabricacionAuto,int costoAuto, double gananciaAuto = 0)
        {
            Marca = marcaAuto  ;
            Modelo = modeloAuto;
            Anio = anioFabricacionAuto;
            Costo =costoAuto;
            Ganancia= gananciaAuto;



        }
        public string Modelo { get; set; }
        public int IdAutomovil { get; set; }
        public string Marca { get; set; }
        public int Anio { get; set; }
        public string Patente { get; set; }
        public int Costo { get; set; }
        public bool FueVendido { get; private set; }
        public double Ganancia { get; set; }
        const double gananciaFija = 0.20;


        public double Precio()
        {
            double calculoPrecio = 0;
            if (Ganancia==0)
            {
                calculoPrecio = Costo * gananciaFija;
            }
            else
            {
                calculoPrecio = Costo * Ganancia;
            }
            
         

                

            



            // Implementar algoritmo que en base al costo del vehiculo
            // mas una ganancia devuelva el precio.
            return Costo + calculoPrecio;
        }

        public void Vender(Comprador comprador)
        {
            // Implementar algoritmo que modifique una propiedad privada de vehiculo vendido.
            if(comprador == null)
            {
                throw new NullReferenceException("No se puede vender un vehículo sin comprador.");
            } else
            {
                FueVendido = true;
            }
        }
    }
}