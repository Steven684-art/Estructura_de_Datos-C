//Ejercicio 3 – Números del 1 al 10 en reversa

using System;
using System.Collections.Generic;

// Clase para gestionar la lista de números
class NumerosInversos
{
    private List<int> numeros = new List<int>();

    public void CargarNumeros()
    {
        for (int i = 1; i <= 10; i++)
        {
            numeros.Add(i);
        }
    }

    public void MostrarInverso()
    {
        numeros.Reverse();
        Console.WriteLine(string.Join(", ", numeros));
    }
}

class Program
{
    static void Main()
    {
        NumerosInversos lista = new NumerosInversos();
        lista.CargarNumeros();
        Console.WriteLine("Números del 1 al 10 en orden inverso:");
        lista.MostrarInverso();
    }
}
