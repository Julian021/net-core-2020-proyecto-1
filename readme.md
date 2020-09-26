# ▶ Proyecto 1 - 🚗 Concesionario 🏍 ◀

_En este primer proyecto vamos a trabajar creando una aplicación de consola que permita gestionar un concesionario de vehiculos._

_El **objetivo** de este proyecto es aplicar los conocimientos de **programación orientada a objetos** y poder subir nuestro proyecto a GitHub._

## Empezando 🆗

_Como requisitos mínimos para poder trabajar vamos a necesitar:_

* [Visual Studio Community](https://visualstudio.microsoft.com/es/vs/community/) - Nuestra IDE y suite de programación.
* [VS Code](http://www.dropwizard.io/1.0.2/docs/) - Perfecto editor en reemplazo de Visual Studio.
* [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) - Necesario para compilar nuestra aplicación.
* [git for windows](https://gitforwindows.org/) - Necesario para conectarse a Github.

### Crear solución 📋

1. Necesitaremos crear una **Solución** para nuestra aplicación, la estructura de la misma debe contener al menos un **proyecto de consola**, ya que utilizaremos a la consola como interfaz de usuario.

_*: Recorda seleccionar Console App (.NET Core) y C# como lenguaje._

2. Un ejemplo de estructura para que nuestra solución tenga una identificación clara puede ser:

- **Solución**: Concesionario.
- **Proyecto**: Consola (Proyecto de Console App .NET Core C#).
- **Proyecto**: ProgramaConcesionario (Biblioteca de Clases de .NET Standard).

![Solution](img/solution.png)

### Escribiendo las clases ✏

1. **Consola** - _Program.cs_: Constará de un procedimiento estático Main() que será nuestro punto de partida a la hora de ejecutar la aplicación.


```
static void Main(string[] args)
    {
        // Inicia nuestra aplicación 
        Console.WriteLine("Aplicación Concesionaria");

        // Finaliza nuestra aplicación
    }
```

2. *ProgramaConcesionario* - _Auto.cs_: Constará de los atributos propios de un Auto, necesarios para que el usuario final interactúe con la aplicación.

```
public class Auto
    {
        public int Modelo { get; private set; }
        public string Nombre { get; private set; }
        public string Marca { get; private set; }
        public int Precio { get; set; }
        public int Ganancia { get; set; }
    }
```
