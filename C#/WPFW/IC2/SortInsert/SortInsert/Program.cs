namespace SortInsert;

class Program
{
    static void Main(string[] args)
    {
        string[] array = ["david", "leandro", "alexis", "fernando", "debora"];
        Sorter strings = new Sorter(array);
        
        Console.WriteLine(strings);
    }
}