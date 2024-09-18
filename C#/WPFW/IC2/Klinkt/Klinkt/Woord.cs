namespace Klinkt;

using System.IO;

public class Woord
{
    private String[] _word;
    private int klinker = 0;
    private int medeklinker = 0;
    List<Char> klinkers = ['a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y'];
    List<Char> medeklinkers = [
        'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z',
        'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z'
    ];
    
    public Woord(String w)
    {
        string[] words = w.Split(' ');
        foreach (var word in words)
        {
            for (int i = 0; i < word.Length; i++)
            {
                aantalKlinkers(word[i]);
                aantalMedeklinkers(word[i]);
            }
        }
    }

    public void aantalKlinkers(char letter)
    {
        foreach (var a in klinkers)
        {
            if (a.Equals(letter))
            {
                klinker++;
            }
        }
    }

    public void aantalMedeklinkers(char letter)
    {
        foreach (var b in medeklinkers)
        {
            if (b.Equals(letter))
            {
                medeklinker++;
            }
        }
    }

    public override string ToString()
    {
        return $"Aantal klinkers: {klinker}\nAantal medeklinkers: {medeklinker}";
    }
}