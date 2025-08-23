//APE2
//APE2.cs - Asignación de asientos en una atracción
//Este programa permite registrar los nombres de las personas en una cola y asigna asientos

using System; //Librería básica para entrada y salida
using System.Collections.Generic; //Permite el uso de la estructura de datos Queue

class Program
{
    static void Main()
    {
        //Se crea una cola para almacenar los nombres de las personas
        Queue<string> colaEspera = new Queue<string>();
        
        //Se define el número total de asientos disponibles
        int capacidad = 30;

        Console.WriteLine("Asignación de asientos en orden de llegada");

        //Bucle que se repite hasta registrar a las 30 personas
        for (int i = 1; i <= capacidad; i++)
        {
            Console.Write($"Ingrese el nombre de la persona {i}: ");
            
            //Se lee el nombre ingresado por el usuario
            string? entrada = Console.ReadLine();

            //Validar que el nombre no esté vacío ni sea solo espacios
            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("Nombre no válido. Intente nuevamente.");
                i--; //Se repite la misma posición si el nombre es inválido
                continue; //Salta al siguiente ciclo sin encolar
            }

            //Se agrega el nombre válido a la cola
            colaEspera.Enqueue(entrada);
        }

        Console.WriteLine("\nSubida a la atracción en orden:");

        //Se define un contador para numerar los asientos
        int asiento = 1;

        //Se recorre la cola para mostrar el orden de subida
        foreach (string persona in colaEspera)
        {
            Console.WriteLine($"Asiento {asiento}: {persona}");
            asiento++; //Se incrementa el número de asiento
        }
    }
}
