
//Tarea: Semana 11

using System;
using System.Collections.Generic;

//CLASE: Traductor
//Encapsula el diccionario y las operaciones de traducción / actualización.
class Traductor
{
    //Campo privado que almacena el diccionario Español -> Inglés.
    private Dictionary<string, string> diccionario;

    //CONSTRUCTOR: inicializa el diccionario con palabras base.
    public Traductor()
    {
        //Inicializa el diccionario con algunas palabras comunes (ESPAÑOL → INGLÉS)
        diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            //Clave: palabra en español / Valor: traducción en inglés
            {"tiempo", "time"},
            {"persona", "person"},
            {"año", "year"},
            {"camino", "way"},
            {"día", "day"},
            {"cosa", "thing"},
            {"hombre", "man"},
            {"mundo", "world"},
            {"vida", "life"},
            {"mano", "hand"},
            {"parte", "part"},
            {"niño", "child"},
            {"ojo", "eye"},
            {"mujer", "woman"},
            {"lugar", "place"},
            {"trabajo", "work"},
            {"semana", "week"},
            {"caso", "case"},
            {"punto", "point"},
            {"gobierno", "government"},
            {"empresa", "company"}
        };
    }

    //MÉTODO: TraducirFrase
    //Recibe una frase en español y traduce palabra por palabra al inglés
    public string TraducirFrase(string frase)
    {
        //Divide la frase en palabras separadas por espacios
        string[] palabras = frase.Split(' ');

        for (int i = 0; i < palabras.Length; i++)
        {
            //Elimina signos de puntuación alrededor de la palabra
            string palabraLimpia = palabras[i].Trim(',', '.', ';', ':', '!', '?');

            //Busca la palabra limpia en el diccionario
            if (diccionario.ContainsKey(palabraLimpia.ToLower()))
            {
                //Reemplaza solo la palabra, pero conserva la puntuación original
                palabras[i] = palabras[i].Replace(palabraLimpia, diccionario[palabraLimpia.ToLower()]);
            }
        }

        //Une las palabras traducidas en una sola cadena
        return string.Join(" ", palabras);
    }

    //MÉTODO: AgregarPalabra
    //Agrega una nueva palabra al diccionario Español → Inglés
    public void AgregarPalabra(string origen, string traduccion)
    {
        if (!diccionario.ContainsKey(origen.ToLower()))
        {
            diccionario.Add(origen.ToLower(), traduccion.ToLower());
            Console.WriteLine("Palabra agregada exitosamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}

//CLASE PRINCIPAL
class Program
{
    static void Main()
    {
        Traductor traductor = new Traductor();
        int opcion;

        do
        {
            Console.WriteLine("\nMENÚ");
            Console.WriteLine("1. Traducir una frase (ES → EN)");
            Console.WriteLine("2. Agregar palabras al diccionario (ES → EN)");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (!int.TryParse(input, out opcion))
            {
                Console.WriteLine("Entrada inválida. Intente nuevamente.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("\nIngrese una frase en español: ");
                    string? frase = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(frase))
                    {
                        Console.WriteLine("Traducción al inglés: " + traductor.TraducirFrase(frase));
                    }
                    else
                    {
                        Console.WriteLine("No ingresó ninguna frase.");
                    }
                    break;

                case 2:
                    Console.Write("Ingrese la palabra en español: ");
                    string? origen = Console.ReadLine();
                    Console.Write("Ingrese la traducción al inglés: ");
                    string? traduccion = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(origen) && !string.IsNullOrWhiteSpace(traduccion))
                    {
                        traductor.AgregarPalabra(origen, traduccion);
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar palabra y traducción válidas.");
                    }
                    break;

                case 0:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0); //Se repite hasta que el usuario elige 0.
    }
}
