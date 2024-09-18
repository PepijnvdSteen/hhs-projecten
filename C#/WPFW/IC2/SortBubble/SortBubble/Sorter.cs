namespace SortBubble;

public class Sorter
{
    int[] Array;
    public Sorter(int[] array)
    {
        Array = array;
        for (int p = 0; p < Array.Length - 2; p++)
        {
            for (int i = 0, j = 1; i < Array.Length - 1; i++, j++)
            {
                if (Array[i] > Array[j])
                {
                    (Array[i], Array[j]) = (Array[j], Array[i]);
                }
            }
        }
    }

    public override string ToString()
    {
        return $"Your sorted array is: {string.Join(", ", Array)}";
    }
}