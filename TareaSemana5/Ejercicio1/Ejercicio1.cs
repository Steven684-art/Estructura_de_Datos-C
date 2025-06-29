//Ejercicio 1 – Mostrar asignaturas

using System;
using System.Collections.Generic;

// Clase que representa una asignatura
class Asignatura
{
    public string Nombre { get; set; }

    public Asignatura(string nombre)
    {
        Nombre = nombre;
    }

    public void Mostrar()
    {
        Console.WriteLine($"Yo estudio {Nombre} en la UEA");
    }
}

class Program
{
    static void Main()
    {
        // Lista de asignaturas
        List<Asignatura> asignaturas = new List<Asignatura>
        {
            new Asignatura("Metodología de la Investigación"),
            new Asignatura("Instalaciones Eléctricas y Cableado Estructurado"),
            new Asignatura("Estructura de Datos"),
            new Asignatura("Fundamentos de Sistemas Digitales"),
            new Asignatura("Administración de Sistemas Operativos")
        };

        // Mostrar cada asignatura
        foreach (var asignatura in asignaturas)
        {
            asignatura.Mostrar();
        }
    }
}
