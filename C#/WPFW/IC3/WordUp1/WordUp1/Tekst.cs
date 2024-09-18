namespace WordUp1;

public struct Gegevens
{
    public String Path { get; set; }
    public String FileName { get; set; }

    public Gegevens(String path, String fileName)
    {
        Path = path;
        FileName = fileName;
    }

    public override string ToString()
    {
        return $"{Path}/{FileName}";
    }
}

public class Tekst
{
    public List<String> AlleWoorden { get; private set; }
    public List<String> Omgedraaid { get; private set; }
    public Gegevens Gegevens { get; set; }

    public List<String> GetWoorden(String bestandPad)
    {
        string? pad = Path.GetDirectoryName(bestandPad);
        var bestandsnaam = Path.GetFileName(bestandPad);
        // string f = "";
        
        Gegevens bestand = new Gegevens(pad, bestandsnaam);

        
        
        AlleWoorden = File.ReadAllLines(bestand.ToString()).ToList();

        return AlleWoorden;
        
        // try
        // {
        //     foreach (var woord in AlleWoorden)
        //     {
        //         f = woord + " ";
        //     }
        //     return f;
        // }
        // catch (Exception e)
        // {
        //     return $"Error message: {e}";
        // }
    }

    public List<String> DraaiOm()
    {
        int aantalWoorden = AlleWoorden.Count;

        for (int i = aantalWoorden; i > 0; i--)
        {
            Omgedraaid.Add(AlleWoorden[i]); 
        }
        
        return Omgedraaid;
    }
    
}