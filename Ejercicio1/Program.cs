using Concesionario;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace InterfazConsola
{
    class Program
    {
        private static Vehiculo vehiculo;
        private static List<Vehiculo> vehiculosEnExposicion;
        static void Main(string[] args)
        {
            



            vehiculosEnExposicion = new List<Vehiculo>();
                var comando = 0;
            vehiculosEnExposicion = LeerVehiculosDelJason();
            do
            {
                comando = DecidirAccion();
                if (comando == 1)
                {
                    MostrarVehiculosEnExposicion();
                }
                if (comando == 2)
                {
                    AgregarVehiculo();
                }
                if (comando == 3)
                {
                    AccionVender();
                }
            } while (comando != 4);

           



        }
        private static int DecidirAccion()
        {
            Console.Clear();
            Console.Beep();
            Console.WriteLine("Bienvenido a Concesionaria 021");
            Console.WriteLine("1. Ver autos" );
            Console.WriteLine("2. Agregar autos ");
            Console.WriteLine("3. Vender ");
            Console.WriteLine("4. Cerrar el programa ");
            Console.WriteLine("Que desea hacer? ");
            int comando = 0;
            int.TryParse(Console.ReadLine(), out comando);
            return comando;




        }
        private static void AccionVender()
        {
           
            Console.Clear();
            Console.WriteLine("Que vehiculo desea vender? ");
            Console.WriteLine("0. Salir");
            for (int i = 0; i < vehiculosEnExposicion.Count; i++)
            {
                var item = vehiculosEnExposicion[i];
                Console.WriteLine($"{i+1}. {item.Marca} {item.Modelo} {item.Anio} ${item.Precio()}");
                
            }
            var comando = 0;
            int.TryParse(Console.ReadLine(), out comando);

            if (comando != 0)
            {
                RemoverAuto(comando);
                GuardarVehiculosDelJason();
            }

        }     
        private static void RemoverAuto(int comando)
        {
            if (comando <= vehiculosEnExposicion.Count)
            {
                vehiculosEnExposicion.RemoveAt(comando - 1);

            }
            else
            {
                Console.WriteLine("El auto seleccionado no existe");
            }
        }
        private static List<Vehiculo> LeerVehiculosDelJason()
        {
            string ruta = @"E:\Biblioteca\Escritorio\Json\Json Concesionaria.text";
            using (StreamReader reader = new StreamReader(ruta))
            {
                string json = reader.ReadToEnd();
                List<Vehiculo> items = JsonConvert.DeserializeObject<List<Vehiculo>>(json,new JsonSerializerSettings( ) {TypeNameHandling = TypeNameHandling.Auto });
                return items;
            }
        }
        //    using (StreamReader r = new StreamReader("file.json"))
        //    {
        //        string json = r.ReadToEnd();
        //        List<Vehiculo> items = JsonConvert.DeserializeObject<List<Vehiculo>>(json);
        //}


        static void GuardarVehiculosDelJason()
        {
            string resultado = JsonConvert.SerializeObject(vehiculosEnExposicion, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            System.IO.File.WriteAllText(@"E:\Biblioteca\Escritorio\Json\Json Concesionaria.text", resultado);
        }
        static void MostrarVehiculosEnExposicion()
        {
            Console.WriteLine("Bienvenido a Concesionaria 021");
            Console.WriteLine("Nuestros autos son: ");
            foreach (var item in vehiculosEnExposicion)
            {
                Console.WriteLine(item.Marca + " " + item.Modelo);
                //Console.WriteLine($"{item.Marca} {item.Modelo}");

            }
            Console.WriteLine("Volver al Menu");
            Console.ReadLine();

        }
        

        static void AgregarVehiculo()
        {
            string marcaAuto, modeloAuto;
            int anioFabricacionAuto, costoAuto;
            double gananciaAuto;
            // 
            Console.Write("Que marca es?: ");
            marcaAuto = Console.ReadLine();
            if (marcaAuto == "")
            {
                throw new Exception("No se puede ingresar una marca de auto vacia");
            }
            Console.Write("Que modelo es?: ");
            modeloAuto = Console.ReadLine();
            if (marcaAuto == "")
            {
                throw new Exception("No se puede ingresar un modelo de auto vacio");
            }
            Console.Write("De que año es?: ");
            int.TryParse(Console.ReadLine(),out anioFabricacionAuto );
            Console.Write("Que costo tiene?: ");
            int.TryParse( Console.ReadLine(), out costoAuto);
            Console.Write("Que ganancia tiene?: ");
            // gananciaAuto = double.Parse(Console.ReadLine());
            Double.TryParse(Console.ReadLine(), out gananciaAuto);
           // Console.WriteLine($"El precio final es {} ");







            var automovil =  new Automovil(marcaAuto,modeloAuto,anioFabricacionAuto,costoAuto,gananciaAuto);
            automovil.Precio();
            vehiculosEnExposicion.Add(automovil);
            GuardarVehiculosDelJason();
            
            

            //var comprador = new Comprador();





            
            
        }
        
    }
}
