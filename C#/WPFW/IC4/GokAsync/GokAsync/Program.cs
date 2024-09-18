namespace GokAsync;

class Program
{
    private static bool breakLoop;
    private static bool notNegative = true;
    
    static async Task Main(string[] args)
    {
        string bestandPad = @"/Users/pep/development/hhs-projecten/C#/WPFW/IC4/GokAsync/GokAsync/groot.txt";  // Pad naar het bestand dat moet worden verwerkt
        
        await VerwerkBestand(bestandPad);  
        
        Console.WriteLine("Einde programma!");        
    }

    static async Task VerwerkBestand(string pad)
    {
        Dictionary<string, int> woordTelling = new Dictionary<string, int>();  // Dictionary om de telling van woorden bij te houden
        int regelTeller = 0;  // Houdt bij hoeveel regels er zijn verwerkt

        using (StreamReader reader = new StreamReader(pad))  // Lees het bestand regel voor regel
        {
            string? regel;
            while ((regel = reader.ReadLine()) != null && !breakLoop)
            {
                regelTeller++;  // Verhoog de regel teller

                // Splits de regel in woorden en verwerk elk woord
                string[] woorden = regel.Split(new[] { ' ', '\t', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var woord in woorden)
                {
                    string lowerWoord = woord.ToLower();  // Converteer het woord naar kleine letters voor case-insensitieve telling

                    if (woordTelling.ContainsKey(lowerWoord))  // Als het woord al in de dictionary staat, verhoog de telling
                    {
                        woordTelling[lowerWoord]++;
                    }
                    else  // Anders, voeg het woord toe met een waarde van 1
                    {
                        woordTelling[lowerWoord] = 1;
                    }
                }

                // Na elke 100e regel, geef het meest voorkomende woord tot nu toe weer
                if (regelTeller % 100 == 0)
                {
                    var meestVoorkomend = woordTelling.OrderByDescending(w => w.Value).First();  // Vind het woord met de hoogste telling
                    
                    if (notNegative)
                    {
                        await gokKans(meestVoorkomend.Value, meestVoorkomend.Key, regelTeller);
                    }
                    else if (!notNegative)
                    {
                        Console.WriteLine($"Na {regelTeller} regels is het meest voorkomende woord '{meestVoorkomend.Key}' met {meestVoorkomend.Value} voorkomens.");
                        Thread.Sleep(50);
                    }
                }
            }
        }

        // Nadat alle regels zijn verwerkt, druk het eindresultaat af
        if (woordTelling.Any())
        {
            var meestVoorkomend = woordTelling.OrderByDescending(w => w.Value).First();  // Vind het woord met de hoogste telling
            Console.WriteLine($"Verwerking voltooid. Het meest voorkomende woord is '{meestVoorkomend.Key}' met {meestVoorkomend.Value} voorkomens.\n");
        }
        else
        {
            Console.WriteLine("Geen woorden gevonden in het bestand.");
        }
    }

    static async Task gokKans(int a, string b, int regelTeller)
    {
        Console.WriteLine($"Hoe vaak komt het meest voorkomende woord voor?");
        int? gok = int.Parse(Console.ReadLine());
        if (gok < 0)
        {
            notNegative = false;
        }

        else if (gok == a)
        {
            Console.WriteLine("Goedzo!\n");
            breakLoop = true;
        }
        
        else
        {
            Console.WriteLine($"Verkeerd!");
            Console.WriteLine($"Na {regelTeller} regels is het meest voorkomende woord '{b}' met {a} keer.\n");
        }
        
    }
}