// Ejercicio 2 – Mostrar notas por asignatura

using System;
using System.Collections.Generic;

// Clase para manejar asignaturas con notas
class Asignatura
{
    public string Nombre { get; set; }
    public double Nota { get; set; }

    public Asignatura(string nombre)
    {
        Nombre = nombre;
    }

    public void PedirNota()
    {
        Console.Write($"Ingresa la nota de {Nombre}: ");
        Nota = Convert.ToDouble(Console.ReadLine());
    }

    public void MostrarNota()
    {
        Console.WriteLine($"En {Nombre} has sacado {Nota}");
    }
}

class Program
{
    static void Main()
    {
        List<Asignatura> asignaturas = new List<Asignatura>
        {
            new Asignatura("Metodología de la Investigación"),
            new Asignatura("Instalaciones Eléctricas y Cableado Estructurado"),
            new Asignatura("Estructura de Datos"),
            new Asignatura("Fundamentos de Sistemas Digitales"),
            new Asignatura("Administración de Sistemas Operativos")
        };

        // Solicitar y mostrar notas
        foreach (var asignatura in asignaturas)
        {
            asignatura.PedirNota();
        }

        Console.WriteLine("\nResumen de Notas:");
        foreach (var asignatura in asignaturas)
        {
            asignatura.MostrarNota();
        }
    }
}
