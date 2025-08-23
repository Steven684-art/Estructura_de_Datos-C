// Ejercicio 2: Cargar datos en una lista, calcular el promedio y separar en dos listas
// - Cargar una cantidad de datos en una lista.
using System;
using System.Collections.Generic;

List<double> listaPrincipal = new List<double>(); // Lista para almacenar los datos principales
List<double> menoresIguales = new List<double>(); // Lista para datos menores o iguales al promedio
List<double> mayores = new List<double>(); // Lista para datos mayores al promedio

// Leer la cantidad de datos a cargar
Console.Write("Ingrese la cantidad de datos a cargar: ");
int n = int.Parse(Console.ReadLine()); // Leer la cantidad de datos

// Cargar datos en la lista principal
for (int i = 0; i < n; i++)
{
    Console.Write($"Ingrese el dato {i + 1}: ");
    double dato = double.Parse(Console.ReadLine()); // Leer cada dato
    listaPrincipal.Add(dato); // Agregar el dato a la lista principal
}

// Calcular el promedio de los datos
double promedio = 0;
foreach (var dato in listaPrincipal)
{
    promedio += dato; // Sumar todos los datos
}
promedio /= n; // Calcular el promedio

// Cargar datos en listas menores o iguales y mayores
foreach (var dato in listaPrincipal)
{
    if (dato <= promedio) // Si el dato es menor o igual al promedio
    {
        menoresIguales.Add(dato); // Agregar a la lista de menores o iguales
    }
    else // Si el dato es mayor al promedio
    {
        mayores.Add(dato); // Agregar a la lista de mayores
    }
}

// Mostrar resultados
Console.WriteLine("Datos cargados en la lista principal:");
Console.WriteLine(string.Join(", ", listaPrincipal)); // Mostrar la lista principal
Console.WriteLine($"Promedio: {promedio}"); // Mostrar el promedio
Console.WriteLine("Datos menores o iguales al promedio:");
Console.WriteLine(string.Join(", ", menoresIguales)); // Mostrar datos menores o iguales
Console.WriteLine("Datos mayores al promedio:");
Console.WriteLine(string.Join(", ", mayores)); // Mostrar datos mayores
