namespace applicatie;

public class KeerVier
{
    public int? Waarde { get; private set; } 
    public KeerVier(int? waarde)              
    {
        waarde *= 4;

        if (waarde >= 2147483647 || waarde <= -1)
        {
            throw new ArgumentException("Sum of the value is bigger than (or equal to) 2147483647 and will not work");
        }

        Waarde = waarde;
    }
}