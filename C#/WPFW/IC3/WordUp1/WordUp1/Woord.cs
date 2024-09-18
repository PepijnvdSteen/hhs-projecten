namespace WordUp1;

public class Woord   // KlinktBeter
{
    public string Tekst { get; private set; }
    private static readonly char[] Klinkers = { 'a', 'e', 'i', 'o', 'u' };  // in feite een CONST (maar kan niet met array)

    public Woord(string tekst)
    {
        // Filter de tekst om alleen letters over te houden en converteer naar kleine letters
        Tekst = new string(tekst.Where(char.IsLetter).ToArray()).ToLower();
    }

    // Methode om het aantal klinkers in het woord te tellen
    public int AantalKlinkers()
    {
        int aantalKlinkers = 0;

        foreach (char c in Tekst)
        {
            foreach (char klinker in Klinkers)   // Controleer of het karakter een klinker is
            {
                if (c == klinker)
                {
                    aantalKlinkers++;
                    break;  // Stop de lus zodra een klinker is gevonden
                }
            }
        }

        return aantalKlinkers;
    }

    // Methode om het aantal medeklinkers in het woord te tellen
    public int AantalMedeklinkers()
    {
        return Tekst.Count(c => char.IsLetter(c) && !Klinkers.Contains(c));
    }

    // Override van ToString om het woord en de informatie af te drukken
    public override string ToString()
    {
        return $"{Tekst} (Klinkers: {AantalKlinkers()}, Medeklinkers: {AantalMedeklinkers()})";
    }
}

// Afgeleide klasse voor woorden met een even aantal letters
public class WoordEven : Woord
{
    public WoordEven(string tekst) : base(tekst)
    {
    }

    // Override van ToString om aan te geven dat het een woord met een even aantal letters is
    public override string ToString()
    {
        return $"{base.ToString()} - Even aantal letters";
    }
}

// Afgeleide klasse voor woorden met een oneven aantal letters
public class WoordOneven : Woord
{
    public WoordOneven(string tekst) : base(tekst)
    {
    }

    // Override van ToString om aan te geven dat het een woord met een oneven aantal letters is
    public override string ToString()
    {
        return $"{base.ToString()} - Oneven aantal letters";
    }
}

// Factory class om Woord-objecten te maken
public static class WoordFactory
{
    public static Woord MaakWoord(string tekst)
    {
        // Filter de tekst om alleen letters over te houden
        int aantalLetters = tekst.Count(char.IsLetter);

        if (aantalLetters % 2 == 0)
        {
            return new WoordEven(tekst);  // Maak een WoordEven object
        }
        return new WoordOneven(tekst);  // Maak een WoordOneven object
        
    }
}