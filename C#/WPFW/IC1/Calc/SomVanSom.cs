namespace applicatie;

public class ToegevoegdeWaarde
{
    public int Waarde { get; private set; } 
    public ToegevoegdeWaarde(int waarde)              
    {
        Waarde = waarde;               
    }

    public ToegevoegdeWaarde(int getal1, int getal2)   
    {
        Waarde = getal1 + getal2; 
    }
}