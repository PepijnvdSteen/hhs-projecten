namespace SortBubble;

class Program
{
    static void Main(string[] args)
    {
        int[] array = [3, 5, 7, 8, 5, 3, 1, 3, 6, 12, 3, 5, 3426, 345, 7123, 2];
        Sorter arrayToSort = new Sorter(array);

        Console.WriteLine(arrayToSort);
    }
}