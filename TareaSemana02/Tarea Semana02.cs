// Importamos el espacio de nombres 'System' que contiene clases fundamentales como Console
using System;

// Declaramos la clase 'Circulo' para representar un círculo geométrico
class Circulo
{
    // Declaramos una variable privada de tipo double para almacenar el radio del círculo
    private double radio;

    // Constructor de la clase Circulo
    // Se ejecuta automáticamente cuando se crea un nuevo objeto de tipo Circulo
    public Circulo(double radio)
    {
        // Usamos 'this.radio' para referirnos al atributo de la clase
        // y lo igualamos al valor recibido como parámetro
        this.radio = radio;
    }

    // Método público que calcula el área del círculo
    // Fórmula: PI * radio^2
    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    // Método público que calcula el perímetro (circunferencia) del círculo
    // Fórmula: 2 * PI * radio
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }
}

// Declaramos otra clase: Rectangulo, para representar rectángulos
class Rectangulo
{
    // Atributos privados para la base y la altura del rectángulo
    private double baseRect;
    private double altura;

    // Constructor de la clase Rectangulo, recibe los valores de base y altura
    public Rectangulo(double baseRect, double altura)
    {
        this.baseRect = baseRect;
        this.altura = altura;
    }

    // Método público que calcula el área del rectángulo
    // Fórmula: base * altura
    public double CalcularArea()
    {
        return baseRect * altura;
    }

    // Método público que calcula el perímetro del rectángulo
    // Fórmula: 2 * (base + altura)
    public double CalcularPerimetro()
    {
        return 2 * (baseRect + altura);
    }
}

// Clase principal del programa. Aquí es donde comienza la ejecución
class Program
{
    // Método Main: punto de entrada de toda aplicación en C#
    static void Main(string[] args)
    {
        // Creamos un objeto de la clase Circulo, y le damos un radio de 5
        Circulo miCirculo = new Circulo(5);

        // Mostramos en consola los resultados del área y perímetro del círculo
        Console.WriteLine("Círculo:");
        Console.WriteLine("Área: " + miCirculo.CalcularArea());
        Console.WriteLine("Perímetro: " + miCirculo.CalcularPerimetro());

        // Creamos un objeto de la clase Rectangulo con base = 4 y altura = 6
        Rectangulo miRectangulo = new Rectangulo(4, 6);

        // Mostramos en consola los resultados del área y perímetro del rectángulo
        Console.WriteLine("\nRectángulo:");
        Console.WriteLine("Área: " + miRectangulo.CalcularArea());
        Console.WriteLine("Perímetro: " + miRectangulo.CalcularPerimetro());
    }
}

// Este código define dos clases para representar figuras geométricas: Círculo y Rectángulo.
    // Cada clase tiene métodos para calcular el área y el perímetro de la figura.  