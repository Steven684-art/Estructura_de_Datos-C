//Verificación de paréntesis balanceados en una expresión matemática

using System;
using System.Collections.Generic;

class VerificaParentesis
{
    static void Main()
    {        //Mensaje inicial al usuario
        Console.WriteLine("Verificación de paréntesis balanceados en una expresión matemática");
        Console.WriteLine("Ingrese una expresión matemática:");

        //Manejo de posible valor nulo con operador ??
        string expresion = Console.ReadLine() ?? "";

        if (EsBalanceada(expresion))
        {
            Console.WriteLine("Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Fórmula no balanceada.");
        }

        //Pausa final para que la consola no se cierre
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }

    static bool EsBalanceada(string expresion)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in expresion)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (pila.Count == 0) return false;

                char tope = pila.Pop();

                if (!EsParCorrespondiente(tope, c))
                {
                    return false;
                }
            }
        }

        return pila.Count == 0;
    }

    static bool EsParCorrespondiente(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '[' && cierre == ']') ||
               (apertura == '{' && cierre == '}');
    }
}
