// Ejercicio 4 – Eliminar asignaturas aprobadas

using System;
using System.Collections.Generic;

// Clase que representa una asignatura con su nota
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
        Console.Write($"Ingrese la nota de {Nombre}: ");
        Nota = Convert.ToDouble(Console.ReadLine());
    }

    public bool EstaReprobada()
    {
        return Nota < 7.0;
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

        // Pedir notas
        foreach (var asignatura in asignaturas)
        {
            asignatura.PedirNota();
        }

        // Filtrar asignaturas reprobadas
        List<Asignatura> reprobadas = asignaturas.FindAll(a => a.EstaReprobada());

        Console.WriteLine("\nDebes repetir las siguientes asignaturas:");
        foreach (var a in reprobadas)
        {
            Console.WriteLine($"- {a.Nombre}");
        }
    }
}
// Este programa permite ingresar las notas de varias asignaturas y filtra aquellas que están reprobadas (nota menor a 7.0).
// Las asignaturas aprobadas no se muestran en la salida final.     