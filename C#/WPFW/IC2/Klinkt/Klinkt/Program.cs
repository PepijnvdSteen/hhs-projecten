namespace Klinkt;

class Program
{
    static void Main(string[] args)
    {
        string path = "/Users/pep/development/hhs-projecten/C#/WPFW/IC2/Klinkt/Klinkt/Klinkt.txt";
        
        String[] fs = File.ReadAllLines(path);
        String v = "";

        foreach (String f in fs)
        {
            v = f + " ";
        }
        
        // String phrase = "Het schrijven van code is zowel een kunst als een wetenschap. Programmeurs gebruiken verschillende talen en methoden om complexe problemen op te lossen. Elk project vereist nauwkeurige planning, creativiteit en technische vaardigheden. Hoewel het proces soms uitdagend kan zijn, biedt het voldoening wanneer een oplossing werkt zoals verwacht.";
        Woord test = new Woord(v);
        
        Console.WriteLine(v);
        Console.WriteLine(test);
    }
}