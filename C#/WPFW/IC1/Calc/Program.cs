namespace applicatie;

public class Program
{
    public static void Main(string[] args)
    {
        
        Console.Write("Voer het eerste getal in: "); 
        int getal1 = int.Parse(Console.ReadLine());
        Console.Write("Voer het tweede getal in: ");
        int getal2 = int.Parse(Console.ReadLine());
        
        Console.Write("Voer het derde getal in: "); 
        int getal3 = int.Parse(Console.ReadLine());
        Console.Write("Voer het vierde getal in: ");
        int getal4 = int.Parse(Console.ReadLine());

        SomInt resultaat1 = new SomInt(getal1, getal2);
        SomInt resultaat2 = new SomInt(getal3, getal4);

        ToegevoegdeWaarde waarde = new ToegevoegdeWaarde(resultaat1.Waarde, resultaat2.Waarde); 
        
        Console.WriteLine($"De som van {getal1} en {getal2} is: {resultaat1.Waarde}");
        Console.WriteLine($"De som van {getal2} en {getal3} is: {resultaat2.Waarde}");
        Console.WriteLine($"De som van {resultaat1.Waarde} en {resultaat2.Waarde} is {waarde.Waarde}");
        
        
        Console.Write("Voer het gewenste getal in: ");
        try
        {
            int vierKeer = int.Parse(Console.ReadLine());
            
            KeerVier input1 = new KeerVier(vierKeer);
            Console.WriteLine($"Als we het getal {vierKeer} geven, krijgen we als antwoord {input1.Waarde}");
        }
        catch (Exception e)
        {
            Console.Write($"Error occured \n {e.Message}");
        }
    }
}
