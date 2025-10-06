//APE 4 - Vuelos Baratos

using System;
using System.Collections.Generic;
using System.Linq;

namespace VuelosBaratos
{
    //Clase que representa un vuelo individual
    class Vuelo
    {
        // Propiedades de cada vuelo
        public string Origen { get; set; }
        public string Destino { get; set; }
        public double Precio { get; set; }

        //Constructor: inicializa los valores de un vuelo
        public Vuelo(string origen, string destino, double precio)
        {
            Origen = origen;
            Destino = destino;
            Precio = precio;
        }

        //Método para mostrar el vuelo como texto legible
        public override string ToString()
        {
            return $"{Origen} → {Destino} | Precio: ${Precio}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Base de datos simulada de vuelos (una lista con objetos Vuelo)
            List<Vuelo> vuelos = new List<Vuelo>
            {
                new Vuelo("Quito", "Guayaquil", 120),
                new Vuelo("Quito", "Cuenca", 90),
                new Vuelo("Guayaquil", "Cuenca", 70),
                new Vuelo("Cuenca", "Loja", 50),
                new Vuelo("Quito", "Loja", 150),
                new Vuelo("Guayaquil", "Manta", 60)
            };

            Console.WriteLine("SISTEMA DE VUELOS BARATOS\n");
            int opcion;

            //Menú interactivo que se repetirá hasta que el usuario decida salir
            do
            {
                Console.WriteLine("1. Ver todos los vuelos");
                Console.WriteLine("2. Buscar vuelos por origen");
                Console.WriteLine("3. Encontrar vuelo más barato entre dos ciudades");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                //Lectura de la opción ingresada
                opcion = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Control de opciones con un switch
                switch (opcion)
                {
                    case 1:
                        //Mostrar todos los vuelos registrados
                        MostrarVuelos(vuelos);
                        break;

                    case 2:
                        //Buscar vuelos según la ciudad de origen
                        BuscarPorOrigen(vuelos);
                        break;

                    case 3:
                        //Encontrar el vuelo más barato entre dos ciudades
                        BuscarMasBarato(vuelos);
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.\n");
                        break;
                }

            } while (opcion != 4); //El ciclo continúa hasta elegir "Salir"
        }

        //Función para mostrar todos los vuelos (reportería general)
        static void MostrarVuelos(List<Vuelo> vuelos)
        {
            Console.WriteLine("LISTA DE VUELOS");
            foreach (var v in vuelos)
                Console.WriteLine(v); //Llama al método ToString() de la clase Vuelo
            Console.WriteLine();
        }

        //Función para buscar vuelos por ciudad de origen
        static void BuscarPorOrigen(List<Vuelo> vuelos)
        {
            Console.Write("Ingrese la ciudad de origen: ");
            string origen = Console.ReadLine();

            //Se filtran los vuelos que coincidan con el origen ingresado
            var resultados = vuelos
                .Where(v => v.Origen.Equals(origen, StringComparison.OrdinalIgnoreCase))
                .ToList();

            //Si hay resultados, se muestran
            if (resultados.Count > 0)
            {
                Console.WriteLine($"\nVuelos desde {origen}:");
                foreach (var v in resultados)
                    Console.WriteLine(v);
            }
            else
            {
                Console.WriteLine("No se encontraron vuelos desde esa ciudad.");
            }
            Console.WriteLine();
        }

        //Función para encontrar el vuelo más barato entre dos ciudades
        static void BuscarMasBarato(List<Vuelo> vuelos)
        {
            Console.Write("Ciudad de origen: ");
            string origen = Console.ReadLine();
            Console.Write("Ciudad de destino: ");
            string destino = Console.ReadLine();

            //Busca vuelos que coincidan con origen y destino
            //y ordena los resultados por precio (menor a mayor)
            var vuelo = vuelos
                .Where(v => v.Origen.Equals(origen, StringComparison.OrdinalIgnoreCase) &&
                            v.Destino.Equals(destino, StringComparison.OrdinalIgnoreCase))
                .OrderBy(v => v.Precio)
                .FirstOrDefault(); //Toma el primer (más barato)

            if (vuelo != null)
            {
                Console.WriteLine($"\nEl vuelo más barato entre {origen} y {destino} es:");
                Console.WriteLine(vuelo);
            }
            else
            {
                Console.WriteLine("No se encontraron vuelos entre esas ciudades.");
            }
            Console.WriteLine();
        }
    }
}


