//Ejercicio 5 – Contar vocales en una palabra

using System;
using System.Collections.Generic;

// Clase que maneja el conteo de vocales
class ContadorVocales
{
    private string? palabra;
    private Dictionary<char, int> conteoVocales = new Dictionary<char, int>()
    {
        {'a', 0}, {'e', 0}, {'i', 0}, {'o', 0}, {'u', 0}
    };

    public void PedirPalabra()
    {
        Console.Write("Ingrese una palabra: ");
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
        palabra = Console.ReadLine().ToLower();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
    }

    public void ContarVocales()
    {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
        foreach (char c in palabra)
        {
            if (conteoVocales.ContainsKey(c))
            {
                conteoVocales[c]++;
            }
        }
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
    }

    public void MostrarConteo()
    {
        Console.WriteLine("\nNúmero de veces que aparece cada vocal:");
        foreach (var kvp in conteoVocales)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}

class Program
{
    static void Main()
    {
        ContadorVocales contador = new ContadorVocales();
        contador.PedirPalabra();
        contador.ContarVocales();
        contador.MostrarConteo();
    }
}
