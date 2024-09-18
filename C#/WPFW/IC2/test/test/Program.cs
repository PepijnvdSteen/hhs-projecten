namespace test;

class Program
{
    static void Main(string[] args)
    {
        List<int> getallen = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var evenGetallen = getallen.FindAll(x => x % 2 == 0);

        List<String> woorden = new List<String> { "a", "b", "c", "d", "e", "f", "q", "l" };
        woorden.Sort((x, y) => x.Length.CompareTo(y.Length));
    }
}