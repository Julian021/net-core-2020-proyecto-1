# ▶ Proyecto 1 - 🚗 Concesionario 🏍 ◀

_En este primer proyecto vamos a trabajar creando una aplicación de consola que permita gestionar un concesionario de vehiculos._

_El **objetivo** de este proyecto es aplicar los conocimientos de **programación orientada a objetos** y poder subir nuestro proyecto a GitHub._

## Empezando 🆗

_Como requisitos mínimos para poder trabajar vamos a necesitar:_

* [Visual Studio Community](https://visualstudio.microsoft.com/es/vs/community/) - Nuestra IDE y suite de programación.
* [VS Code](http://www.dropwizard.io/1.0.2/docs/) - Perfecto editor en reemplazo de Visual Studio.
* [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) - Necesario para compilar nuestra aplicación.
* [git for windows](https://gitforwindows.org/) - Necesario para conectarse a Github.

## Crear solución 📋

1. Necesitaremos crear una **Solución** para nuestra aplicación, la estructura de la misma debe contener al menos un **proyecto de consola**, ya que utilizaremos a la consola como interfaz de usuario.

_*: Recorda seleccionar Console App (.NET Core) y C# como lenguaje._

2. Un ejemplo de estructura para que nuestra solución tenga una identificación clara puede ser:

- **Solución**: Concesionario.
- **Proyecto**: Consola (Proyecto de Console App .NET Core C#).
- **Proyecto**: ProgramaConcesionario (Biblioteca de Clases de .NET Standard).

![Solution](img/solution.png)

## Escribiendo las clases ✏

1. **Consola** - _Program.cs_: Constará de un procedimiento estático Main() que será nuestro punto de partida a la hora de ejecutar la aplicación.


```
static void Main(string[] args)
{
    // Inicia nuestra aplicación 
    Console.WriteLine("Aplicación Concesionaria");

    // Finaliza nuestra aplicación
}
```

_Además de este método principal, podemos escribir métodos (funciones o procedimientos) privados que nos resuelvan y encapsulen los distintos algoritmos._

```
private static void ImprimirAutos(List<Auto> autos)
{
    // Este procedimiento recorre una lista de autos, imprimiendolos por consola.

    foreach (var auto in autos)
    {
        Console.WriteLine(auto.Modelo);
    }
}
```

2. **ProgramaConcesionario** - _Auto.cs_: Constará de los atributos propios de un Auto, necesarios para que el usuario final interactúe con la aplicación.

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

## Dando **interacción** a la **Interfaz** 🤵🏻

A la hora de escribir nuestra interacción en la interfaz, podemos tener en cuenta los siguientes tips:

- Si esperamos que el usuario ingrese una acción (como por ejemplo el número de comando que desea ejecutar) deberemos validar si el valor ingresado es correcto, y sino, pedir que lo vuelva a ingresar.

```
static int EjecutarComando()
{
    int comando = 0;

    bool comandoValido = false; 

    do
    {
        string comandoIngresado = Console.ReadLine();

        comandoValido = int.TryParse(comandoIngresado, out comando);
        
        if (!comandoValido)
        {
            Console.WriteLine("El comando ingresado " + comandoIngresado + " es incorrecto.");

            Console.WriteLine("Ingrese uno nuevamente: ");
        }

    } while (!comandoValido);

    return comando;
}
```

- Podemos valernos de búcles y condicionales para controlar el flujo de interacción del usuario. 

## **JSON**: Guardando y leyendo ✏

Para almacenar nuestra lista de autos vamos a utilizar un formato de texto conocido como JSON. Se trata de una forma de representar objetos en javascript y es muy utilizado hoy día en el intercambio de datos entre clientes y APIs (lo vamos a ver más adelante).

_En la última versión de .NET Core 3.1 integraron una biblioteca de clases al framework de trabajo que permite serializar y deserializar JSON sin utilizar una biblioteca externa._

### Guardar JSON

Un JSON es una cadena de texto a partir de un objeto, por ende, guardaremos nuestro List<Auto> dentro de la misma.

```
static void GuardarJSON()
{
    List<Auto> autos = new List<Auto>();

    string jsonString = JsonConvert.SerializeObject(autos);
}
```

### Leer JSON

Para leer JSON de un archivo de texto:

```
static List<Auto> GuardarJSON()
{
    var texto = File.ReadAllText("autos.json");

    var autosLeidos = JsonConvert.DeserializeObject<List<Auto>>(texto);

    return autosLeidos;
}
```