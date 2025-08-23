//Resolución del problema de las Torres de Hanoi
using System;
using System.Collections.Generic;
using System.Linq;

class Torre
{
    public Stack<int> Discos { get; private set; }
    public string Nombre { get; private set; }

    public Torre(string nombre)
    {
        Nombre = nombre;
        Discos = new Stack<int>();
    }

    public void MoverDiscoA(Torre destino)
    {
        int disco = Discos.Pop();
        destino.Discos.Push(disco);
        Console.WriteLine($"\nMover disco {disco} desde {Nombre} hasta {destino.Nombre}");
    }

    // Método para mostrar el contenido de la torre
    public void MostrarEstado()
    {
        Console.Write($"{Nombre}: ");
        foreach (var disco in Discos.Reverse()) // Se invierte para mostrar de abajo hacia arriba
        {
            Console.Write($"{disco} ");
        }
        Console.WriteLine();
    }
}

class TorresDeHanoi
{
    static void ResolverHanoi(int n, Torre origen, Torre auxiliar, Torre destino)
    {
        if (n > 0)
        {
            ResolverHanoi(n - 1, origen, destino, auxiliar);

            origen.MoverDiscoA(destino);
            MostrarTorres(origen, auxiliar, destino);

            ResolverHanoi(n - 1, auxiliar, origen, destino);
        }
    }

    static void MostrarTorres(Torre origen, Torre auxiliar, Torre destino)
    {
        origen.MostrarEstado();
        auxiliar.MostrarEstado();
        destino.MostrarEstado();
        Console.WriteLine(new string(' ', 30));
    }

    static void Main()
    {
        int cantidadDiscos = 3; // Puedes cambiar este número

        Torre origen = new Torre("Origen");
        Torre auxiliar = new Torre("Auxiliar");
        Torre destino = new Torre("Destino");

        for (int i = cantidadDiscos; i >= 1; i--)
        {
            origen.Discos.Push(i);
        }

        Console.WriteLine("Estado inicial de las torres:");
        MostrarTorres(origen, auxiliar, destino);

        ResolverHanoi(cantidadDiscos, origen, auxiliar, destino);
    }
}
