//Tarea Semana 10

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace VacunacionCovid
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // 1. CREACIÓN DE LOS CIUDADANOS
            
            var todosCiudadanos = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
            {
                todosCiudadanos.Add($"Ciudadano {i}");
            }

           
            // 2. VACUNADOS CON PFIZER Y ASTRAZENECA
           
            var vacunadosPfizer = new HashSet<string>();
            for (int i = 1; i <= 75; i++)
            {
                vacunadosPfizer.Add($"Ciudadano {i}");
            }

            var vacunadosAstraZeneca = new HashSet<string>();
            for (int i = 76; i <= 150; i++)
            {
                vacunadosAstraZeneca.Add($"Ciudadano {i}");
            }

            
            // 3. OPERACIONES DE TEORÍA DE CONJUNTOS
            
            var vacunados = new HashSet<string>(vacunadosPfizer);
            vacunados.UnionWith(vacunadosAstraZeneca);

            var noVacunados = new HashSet<string>(todosCiudadanos);
            noVacunados.ExceptWith(vacunados);

            var ambasDosis = new HashSet<string>(vacunadosPfizer);
            ambasDosis.IntersectWith(vacunadosAstraZeneca);

            var soloPfizer = new HashSet<string>(vacunadosPfizer);
            soloPfizer.ExceptWith(vacunadosAstraZeneca);

            var soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
            soloAstraZeneca.ExceptWith(vacunadosPfizer);

            
            // 4. MOSTRAR RESULTADOS EN CONSOLA
           
            Console.WriteLine(" RESULTADOS CAMPAÑA DE VACUNACIÓN COVID-19\n");

            Console.WriteLine($"Total ciudadanos: {todosCiudadanos.Count}");
            Console.WriteLine($"Vacunados Pfizer: {vacunadosPfizer.Count}");
            Console.WriteLine($"Vacunados AstraZeneca: {vacunadosAstraZeneca.Count}");
            Console.WriteLine($"No vacunados: {noVacunados.Count}");
            Console.WriteLine($"Ambas dosis: {ambasDosis.Count}");
            Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
            Console.WriteLine($"Solo AstraZeneca: {soloAstraZeneca.Count}\n");

            
            // 5. GENERAR REPORTE PDF
            
            string rutaArchivo = "ReporteVacunacion.pdf";
            GenerarReportePDF(rutaArchivo, todosCiudadanos.Count,
                vacunadosPfizer.Count, vacunadosAstraZeneca.Count,
                noVacunados, ambasDosis, soloPfizer, soloAstraZeneca);

            Console.WriteLine($"\nReporte PDF generado en: {Path.GetFullPath(rutaArchivo)}");
            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }

        // Método para generar el PDF usando iTextSharp
        static void GenerarReportePDF(string rutaArchivo, int total, int pfizer, int astra,
            HashSet<string> noVacunados, HashSet<string> ambasDosis,
            HashSet<string> soloPfizer, HashSet<string> soloAstraZeneca)
        {
            Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
            doc.Open();

            // Título
            var titulo = new Paragraph("Reporte de Vacunación COVID-19\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);

            // Resumen general
            doc.Add(new Paragraph($"Total de ciudadanos: {total}"));
            doc.Add(new Paragraph($"Vacunados Pfizer: {pfizer}"));
            doc.Add(new Paragraph($"Vacunados AstraZeneca: {astra}"));
            doc.Add(new Paragraph($"No vacunados: {noVacunados.Count}"));
            doc.Add(new Paragraph($"Ambas dosis: {ambasDosis.Count}"));
            doc.Add(new Paragraph($"Solo Pfizer: {soloPfizer.Count}"));
            doc.Add(new Paragraph($"Solo AstraZeneca: {soloAstraZeneca.Count}\n\n"));

            // Listados detallados
            AgregarLista(doc, "Ciudadanos NO vacunados", noVacunados);
            AgregarLista(doc, "Ciudadanos con ambas dosis", ambasDosis);
            AgregarLista(doc, "Ciudadanos solo Pfizer", soloPfizer);
            AgregarLista(doc, "Ciudadanos solo AstraZeneca", soloAstraZeneca);

            doc.Close();
        }

        // Método auxiliar para agregar listas al PDF
        static void AgregarLista(Document doc, string titulo, HashSet<string> ciudadanos)
        {
            doc.Add(new Paragraph($"\n--- {titulo} (Total: {ciudadanos.Count}) ---"));
            List lista = new List(List.UNORDERED);

            // Mostrar solo los primeros 20 para no saturar el PDF
            foreach (var c in ciudadanos.Take(20))
            {
                lista.Add(new ListItem(c));
            }

            if (ciudadanos.Count > 20)
                lista.Add(new ListItem("... (lista truncada)"));

            doc.Add(lista);
        }
    }
}
