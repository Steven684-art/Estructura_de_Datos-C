////Programa para crear una lista enlazada y eliminar nodos fuera de un rango

using System;
using System.Collections.Generic;

// Clase Nodo que representa un elemento de la lista enlazada
class Nodo
{
    public int Valor; // Valor del nodo
    public Nodo? Siguiente; // Puntero al siguiente nodo

    // Constructor que inicializa el nodo con un valor
    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null; // Inicialmente, el siguiente nodo es nulo
    }
}

// Clase ListaEnlazada que maneja la lista de nodos
class ListaEnlazada
{
    public Nodo? Cabeza; // Puntero al primer nodo de la lista

    // Método para agregar un nuevo nodo a la lista
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor); // Crear un nuevo nodo
        if (Cabeza == null) // Si la lista está vacía
        {
            Cabeza = nuevoNodo; // El nuevo nodo se convierte en la cabeza
        }
        else
        {
            Nodo actual = Cabeza; // Comenzar desde la cabeza
            // Recorrer hasta el final de la lista
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente; // Moverse al siguiente nodo
            }
            actual.Siguiente = nuevoNodo; // Agregar el nuevo nodo al final
        }
    }

    // Método para eliminar nodos que están fuera de un rango dado
    public void EliminarFueraDeRango(int min, int max)
    {
        Nodo? actual = Cabeza; // Comenzar desde la cabeza
        Nodo? anterior = null; // Puntero al nodo anterior

        // Recorrer la lista
        while (actual != null)
        {
            // Verificar si el valor está fuera del rango
            if (actual.Valor < min || actual.Valor > max)
            {
                if (anterior == null) // Si se elimina la cabeza
                {
                    Cabeza = actual.Siguiente; // Actualizar la cabeza
                }
                else
                {
                    anterior.Siguiente = actual.Siguiente; // Eliminar el nodo
                }
            }
            else
            {
                anterior = actual; // Mover el puntero anterior
            }
            actual = actual.Siguiente; // Mover al siguiente nodo
        }

        // Llamar al método de ordenamiento después de eliminar nodos
        Ordenar();
    }

    // Método para ordenar la lista enlazada
    public void Ordenar()
    {
        if (Cabeza == null || Cabeza.Siguiente == null) return; // Si la lista está vacía o tiene un solo nodo

        // Usar un algoritmo de ordenamiento (por ejemplo, burbuja)
        bool swapped;
        do
        {
            swapped = false;
            Nodo? actual = Cabeza;
            while (actual?.Siguiente != null)
            {
                if (actual.Valor > actual.Siguiente.Valor) // Comparar valores
                {
                    // Intercambiar valores
                    int temp = actual.Valor;
                    actual.Valor = actual.Siguiente.Valor;
                    actual.Siguiente.Valor = temp;
                    swapped = true; // Se realizó un intercambio
                }
                actual = actual.Siguiente; // Mover al siguiente nodo
            }
        } while (swapped); // Repetir hasta que no haya más intercambios
    }

    // Método para mostrar los valores de la lista
    public void Mostrar()
    {
        Nodo? actual = Cabeza; // Comenzar desde la cabeza
        // Recorrer la lista y mostrar los valores
        while (actual != null)
        {
            Console.Write(actual.Valor + " "); // Mostrar el valor del nodo
            actual = actual.Siguiente; // Mover al siguiente nodo
        }
        Console.WriteLine(); // Nueva línea al final
    }
}

class Program
{
    static void Main()
    {
        Random random = new Random(); // Generador de números aleatorios
        ListaEnlazada lista = new ListaEnlazada(); // Crear una nueva lista enlazada

        // Crear lista con 50 números aleatorios
        for (int i = 0; i < 50; i++)
        {
            lista.Agregar(random.Next(1, 1000)); // Agregar un número aleatorio entre 1 y 999
        }

        Console.WriteLine("Lista original:");
        lista.Mostrar(); // Mostrar la lista original

        // Leer rango de valores desde el teclado
        Console.Write("Ingrese el valor mínimo: ");
        string? minInput = Console.ReadLine(); // Leer el valor mínimo como string
        int min = int.Parse(minInput ?? "0"); // Convertir a entero, usando 0 si es nulo
        Console.Write("Ingrese el valor máximo: ");
        string? maxInput = Console.ReadLine(); // Leer el valor máximo como string
        int max = int.Parse(maxInput ?? "999"); // Convertir a entero, usando 999 si es nulo

        // Eliminar nodos fuera del rango
        lista.EliminarFueraDeRango(min, max);

        Console.WriteLine("Lista después de eliminar nodos fuera del rango:");
        lista.Mostrar(); // Mostrar la lista después de la eliminación
    }
}
// Fin del programa
