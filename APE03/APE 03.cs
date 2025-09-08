// APE 03: Sistema de registro de libros en una biblioteca
// Utiliza un diccionario (MAPA) para almacenar libros por ISBN

using System;
using System.Collections.Generic;

namespace BibliotecaApp
{
    class Program
    {
        //Diccionario (MAPA): clave = ISBN, valor = datos del libro
        //Permite búsquedas rápidas por ISBN
        static Dictionary<string, (string Titulo, string Autor, int Anio)> libros
            = new Dictionary<string, (string, string, int)>();

        //Conjunto (SET): almacena categorías únicas
        static HashSet<string> categorias = new HashSet<string>();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("SISTEMA DE REGISTRO DE LIBROS");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Consultar libro por ISBN");
                Console.WriteLine("3. Ver todos los libros");
                Console.WriteLine("4. Ver categorías");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                //Lee la opción elegida
                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        RegistrarLibro();
                        break;
                    case 2:
                        ConsultarLibro();
                        break;
                    case 3:
                        ListarLibros();
                        break;
                    case 4:
                        ListarCategorias();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }

        //Método para registrar un libro
        static void RegistrarLibro()
        {
            Console.Clear();
            Console.WriteLine("REGISTRAR LIBRO");

            Console.Write("Ingrese ISBN: ");
            string isbn = Console.ReadLine() ?? "";

            //Validamos que no exista el mismo ISBN
            if (libros.ContainsKey(isbn))
            {
                Console.WriteLine("El ISBN ya está registrado.");
                return;
            }

            Console.Write("Ingrese título: ");
            string titulo = Console.ReadLine() ?? "";

            Console.Write("Ingrese autor: ");
            string autor = Console.ReadLine() ?? "";

            Console.Write("Ingrese año de publicación: ");
            if (!int.TryParse(Console.ReadLine(), out int anio))
            {
                Console.WriteLine("⚠ Año inválido, se guardará como 0.");
                anio = 0;
            }

            Console.Write("Ingrese categoría: ");
            string categoria = Console.ReadLine() ?? "";

            //Agregamos libro al diccionario (MAPA)
            libros[isbn] = (titulo, autor, anio);

            //Agregamos categoría al conjunto (SET)
            categorias.Add(categoria);

            Console.WriteLine("Libro registrado correctamente.");
        }

        //Método para consultar libro por ISBN
        static void ConsultarLibro()
        {
            Console.Clear();
            Console.WriteLine("CONSULTAR LIBRO");

            Console.Write("Ingrese ISBN: ");
            string isbn = Console.ReadLine() ?? "";

            //Buscamos en el diccionario
            if (libros.TryGetValue(isbn, out var libro))
            {
                Console.WriteLine($"ISBN: {isbn}");
                Console.WriteLine($"Título: {libro.Titulo}");
                Console.WriteLine($"Autor: {libro.Autor}");
                Console.WriteLine($"Año: {libro.Anio}");
            }
            else
            {
                Console.WriteLine("No se encontró un libro con ese ISBN.");
            }
        }

        //Método para listar todos los libros
        static void ListarLibros()
        {
            Console.Clear();
            Console.WriteLine("LISTA DE LIBROS");

            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            foreach (var kvp in libros)
            {
                Console.WriteLine($"ISBN: {kvp.Key} | " +
                                  $"Título: {kvp.Value.Titulo} | " +
                                  $"Autor: {kvp.Value.Autor} | " +
                                  $"Año: {kvp.Value.Anio}");
            }
        }

        //Método para listar todas las categorías
        static void ListarCategorias()
        {
            Console.Clear();
            Console.WriteLine("LISTA DE CATEGORÍAS");

            if (categorias.Count == 0)
            {
                Console.WriteLine("No hay categorías registradas.");
                return;
            }

            foreach (var categoria in categorias)
            {
                Console.WriteLine($"- {categoria}");
            }
        }
    }
}
