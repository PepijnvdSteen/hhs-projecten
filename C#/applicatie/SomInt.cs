namespace applicatie;

public class SomInt
{
    public int Waarde { get; private set; } 
    public SomInt(int waarde)              
    {
        Waarde = waarde;               
    }

    public SomInt(int getal1, int getal2)   
    {
        Waarde = getal1 + getal2; 
    }
}
