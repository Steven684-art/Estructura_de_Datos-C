
//Implementación de Búsqueda en un Catálogo de Revistas

using System;
using System.Collections.Generic;

class Program
{
    //ista para almacenar las revistas
    static List<string> catalogo = new List<string>()
    {
        "National Geographic",
        "Science Today",
        "Nature",
        "Time",
        "Forbes",
        "Reader's Digest",
        "Sports Illustrated",
        "Popular Mechanics",
        "Harvard Business Review",
        "Cosmopolitan"
    };

    static void Main(string[] args)
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("\n CATÁLOGO DE REVISTAS ");
            Console.WriteLine("1. Buscar revista");
            Console.WriteLine("2. Mostrar catálogo completo");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            
            //Validamos la entrada del usuario
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Intente nuevamente.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("\nIngrese el título a buscar: ");
                    string titulo = Console.ReadLine();
                    bool encontrado = BuscarRevistaRecursivo(catalogo, titulo, 0);

                    if (encontrado)
                        Console.WriteLine("Resultado: Encontrado ");
                    else
                        Console.WriteLine("Resultado: No encontrado ");
                    break;

                case 2:
                    Console.WriteLine("\n Catálogo de Revistas");
                    foreach (var revista in catalogo)
                    {
                        Console.WriteLine("- " + revista);
                    }
                    break;

                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }

        } while (opcion != 3);
    }

    ///<summary>
    ///Búsqueda recursiva en la lista de revistas.
    ///</summary>
    ///<param name="lista">Lista de revistas</param>
    ///<param name="titulo">Título a buscar</param>
    ///<param name="indice">Índice actual</param>
    ///<returns>true si encuentra, false si no</returns>
    static bool BuscarRevistaRecursivo(List<string> lista, string titulo, int indice)
    {
        //Caso base: llegamos al final de la lista sin encontrar
        if (indice >= lista.Count)
            return false;

        //Comparación insensible a mayúsculas/minúsculas
        if (lista[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase))
            return true;

        //Llamada recursiva al siguiente índice
        return BuscarRevistaRecursivo(lista, titulo, indice + 1);
    }
}
