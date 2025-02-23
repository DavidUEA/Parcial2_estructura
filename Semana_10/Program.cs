using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main()
    {
        // Crear conjuntos de ciudadanos (simulados)
        var ciudadanos = new HashSet<int>(Enumerable.Range(1, 500));  // 500 ciudadanos
        var vacunadosConPfizer = new HashSet<int>(Enumerable.Range(1, 75));  // 75 vacunados con Pfizer
        var vacunadosConAstrazeneca = new HashSet<int>(Enumerable.Range(1, 75));  // 75 vacunados con Astrazeneca

        // Operaciones de conjuntos para obtener los distintos grupos de ciudadanos
        var noVacunados = ciudadanos.Except(vacunadosConPfizer).Except(vacunadosConAstrazeneca).ToList();
        var vacunadosAmbas = vacunadosConPfizer.Intersect(vacunadosConAstrazeneca).ToList();
        var soloPfizer = ciudadanos.Intersect(vacunadosConAstrazeneca).ToList();
        var soloAstrazeneca = ciudadanos.Intersect(vacunadosConPfizer).ToList();

        // Mostrar resultados por consola
        Console.WriteLine($"Ciudadanos no vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ciudadanos con ambas vacunas: {vacunadosAmbas.Count}");
        Console.WriteLine($"Ciudadanos solo con Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Ciudadanos solo con Astrazeneca: {soloAstrazeneca.Count}");

     }
}