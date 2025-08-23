using System;

namespace RegistroEstudiantes
{
    // Definición de la clase Estudiante
    class Estudiante
    {
        // Propiedades del estudiante
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; }  // Array para los 3 teléfonos

        // Constructor
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        // Método para mostrar los datos del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nombre Completo: " + Nombres + " " + Apellidos);
            Console.WriteLine("Dirección: " + Direccion);
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Datos de ejemplo
            string[] telefonos = new string[3] { "0967844568", "0991122334", "0981112233" };
            
            // Crear un objeto Estudiante
            Estudiante estudiante1 = new Estudiante(
                1,
                "Steven",
                "Shiguango",
                "Av. 15 de Noviembre y Calle 10",
                telefonos
            );

            // Mostrar la información
            estudiante1.MostrarInformacion();
        }
    }
}

// Este código define una clase Estudiante con propiedades para ID, nombres, apellidos, dirección y un array de teléfonos.
// Luego, crea un objeto de esta clase con datos de ejemplo y muestra su información en la consola.
// Puedes ejecutar este código en un entorno de C# para ver cómo funciona.  