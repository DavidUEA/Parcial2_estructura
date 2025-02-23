using System;
using System.Collections.Generic;
using System.Linq;

public class VacunacionCOVID
{
    public static void Main(string[] args)
    {
        // Generación de datos ficticios
        HashSet<string> ciudadanos = GenerarCiudadanos(500);
        HashSet<string> pfizerVacunados = GenerarCiudadanos(75);
        HashSet<string> astraZenecaVacunados = GenerarCiudadanos(75);

        // Simulamos que algunos ciudadanos han recibido ambas vacunas
        Random random = new Random();
        HashSet<string> dobleVacunados = new HashSet<string>(ciudadanos
            .Intersect(pfizerVacunados.Union(astraZenecaVacunados))
            .OrderBy(x => random.Next())
            .Take(100));

        // Calculamos los conjuntos necesarios
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos.Except(pfizerVacunados).Except(astraZenecaVacunados));
        HashSet<string> soloPfizer = new HashSet<string>(pfizerVacunados.Except(astraZenecaVacunados).Except(dobleVacunados));
        HashSet<string> soloAstraZeneca = new HashSet<string>(astraZenecaVacunados.Except(pfizerVacunados).Except(dobleVacunados));
        HashSet<string> dobleVacunadosFinal = new HashSet<string>(dobleVacunados.Intersect(pfizerVacunados).Intersect(astraZenecaVacunados));

        // Mostramos los resultados
        Console.WriteLine("No vacunados: " + noVacunados.Count);
        Console.WriteLine("Doble vacunados: " + dobleVacunadosFinal.Count);
        Console.WriteLine("Solo Pfizer: " + soloPfizer.Count);
        Console.WriteLine("Solo AstraZeneca: " + soloAstraZeneca.Count);
    }

    public static HashSet<string> GenerarCiudadanos(int n)
    {
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= n; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }
        return ciudadanos;
    }
}