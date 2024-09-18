namespace File;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string[] namen1 = ["Kees", "bas", "gert", "hans", "klaas"];
        /*
         foreach (string namen in namen1)
        {
           Console.WriteLine(namen);     
        }
        */
        File.WriteAllLines("output.txt", namen1); 
        
        
        var text = File.ReadLines("output.txt");
        
        text.ToList().ForEach(Console.WriteLine);
    }
}