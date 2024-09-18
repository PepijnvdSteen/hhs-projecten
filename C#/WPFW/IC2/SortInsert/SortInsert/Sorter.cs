namespace SortInsert;

public class Sorter
{
    private string[] _strings;

    public Sorter(string[] a)
    {
        _strings = a;
        for (int i = 0; i < _strings.Length -1; i++)
        {
            for (int j = i + 1; j > 0 && string.Compare(_strings[j], _strings[i], StringComparison.Ordinal) < 0; j--)
            {
                (_strings[j], _strings[i]) = (_strings[i], _strings[j]);
            }
        }
    }

    public override string ToString()
    {
        return $"Your sorted string array is: {string.Join(", ", _strings)}";
    }

    
}