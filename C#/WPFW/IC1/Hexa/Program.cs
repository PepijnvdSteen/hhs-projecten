namespace Hexa;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Write the int that you want to convert to hexadecimal");
        var value = int.Parse(Console.ReadLine());

        Hexa toConvert = new Hexa(value);

        Hexa overload = toConvert + toConvert;

        Console.WriteLine($"The hexadecimal value for {value} is: {toConvert}\nThe overload is: {overload}");
    }
}