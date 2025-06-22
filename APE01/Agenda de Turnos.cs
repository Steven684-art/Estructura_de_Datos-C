using System;
using System.Collections.Generic;

namespace ClinicaTurnos
{
    // Estructura para almacenar los datos del paciente
    struct Paciente
    {
        public string Cedula;
        public string Nombre;
        public int Edad;

        public Paciente(string cedula, string nombre, int edad)
        {
            Cedula = cedula;
            Nombre = nombre;
            Edad = edad;
        }
    }

    // Clase Turno que almacena un turno agendado para un paciente
    class Turno
    {
        public Paciente Paciente;
        public string Dia;
        public string Hora;
        public string Especialidad;

        public Turno(Paciente paciente, string dia, string hora, string especialidad)
        {
            Paciente = paciente;
            Dia = dia;
            Hora = hora;
            Especialidad = especialidad;
        }

        public override string ToString()
        {
            return $"Día: {Dia}, Hora: {Hora}, Especialidad: {Especialidad}, Paciente: {Paciente.Nombre}, Cédula: {Paciente.Cedula}";
        }
    }

    // Clase principal para gestionar la agenda
    class AgendaClinica
    {
        // Lista (vector dinámico) de turnos registrados
        private List<Turno> turnos;

        public AgendaClinica()
        {
            turnos = new List<Turno>();
        }

        // Método para registrar un nuevo turno
        public void RegistrarTurno(Paciente paciente, string dia, string hora, string especialidad)
        {
            // Verificar si ya hay un turno en la misma fecha y hora
            foreach (var t in turnos)
            {
                if (t.Dia == dia && t.Hora == hora)
                {
                    Console.WriteLine("❌ Ese turno ya está reservado.");
                    return;
                }
            }

            Turno nuevoTurno = new Turno(paciente, dia, hora, especialidad);
            turnos.Add(nuevoTurno);
            Console.WriteLine("✅ Turno registrado con éxito.");
        }

        // Método para mostrar todos los turnos
        public void VerAgenda()
        {
            if (turnos.Count == 0)
            {
                Console.WriteLine("📋 No hay turnos registrados.");
                return;
            }

            Console.WriteLine("📅 Turnos registrados:");
            foreach (var turno in turnos)
            {
                Console.WriteLine(turno);
            }
        }

        // Método para buscar turnos por cédula del paciente
        public void BuscarTurnosPorPaciente(string cedula)
        {
            bool encontrado = false;
            foreach (var turno in turnos)
            {
                if (turno.Paciente.Cedula == cedula)
                {
                    Console.WriteLine(turno);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("🔍 No se encontraron turnos para ese paciente.");
            }
        }

        // Método para cancelar un turno
        public void CancelarTurno(string cedula, string dia, string hora)
        {
            for (int i = 0; i < turnos.Count; i++)
            {
                if (turnos[i].Paciente.Cedula == cedula && turnos[i].Dia == dia && turnos[i].Hora == hora)
                {
                    turnos.RemoveAt(i);
                    Console.WriteLine("🗑️ Turno cancelado correctamente.");
                    return;
                }
            }

            Console.WriteLine("❌ No se encontró el turno para cancelar.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AgendaClinica agenda = new AgendaClinica();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n AGENDA DE TURNOS");
                Console.WriteLine("1. Registrar turno");
                Console.WriteLine("2. Ver agenda");
                Console.WriteLine("3. Buscar turnos por paciente");
                Console.WriteLine("4. Cancelar turno");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Cédula: ");
                        string cedula = Console.ReadLine();
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Edad: ");
                        int edad = int.Parse(Console.ReadLine());
                        Console.Write("Día del turno: ");
                        string dia = Console.ReadLine();
                        Console.Write("Hora del turno: ");
                        string hora = Console.ReadLine();
                        Console.Write("Especialidad: ");
                        string especialidad = Console.ReadLine();

                        Paciente nuevoPaciente = new Paciente(cedula, nombre, edad);
                        agenda.RegistrarTurno(nuevoPaciente, dia, hora, especialidad);
                        break;

                    case "2":
                        agenda.VerAgenda();
                        break;

                    case "3":
                        Console.Write("Ingrese la cédula del paciente: ");
                        string cedulaBusqueda = Console.ReadLine();
                        agenda.BuscarTurnosPorPaciente(cedulaBusqueda);
                        break;

                    case "4":
                        Console.Write("Cédula: ");
                        string cedulaCancel = Console.ReadLine();
                        Console.Write("Día del turno: ");
                        string diaCancel = Console.ReadLine();
                        Console.Write("Hora del turno: ");
                        string horaCancel = Console.ReadLine();
                        agenda.CancelarTurno(cedulaCancel, diaCancel, horaCancel);
                        break;

                    case "5":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("❗ Opción no válida. Intente de nuevo.");
                        break;
                }
            }

            Console.WriteLine("👋 Programa finalizado.");
        }
    }
}
