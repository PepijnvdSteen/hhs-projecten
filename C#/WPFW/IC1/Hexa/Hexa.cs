using System.Diagnostics.CodeAnalysis;

namespace Hexa;

public class Hexa
{
    private string _hex = "";
    public Hexa(int value)
    {
        if (value >= 65536)
        {
            throw new OverflowException("The value is bigger than 65535");
        }
        for (int i = 0; i < 4; i++)
        {
            int quotient = value / 16;
            int remainder = value % 16;
    
            _hex = DecToHex(remainder) + _hex;
            value = quotient;
        }
    }

    public static Hexa operator +(Hexa a, Hexa b)
    {
        int temp1 = int.Parse(a._hex);
        int temp2 = int.Parse(b._hex);
        return new Hexa(temp1 + temp2);
    }

    private static char DecToHex(int dec)
    {
        switch (dec)
        {
            case 0:
                return '0';
            case 1:
                return '1';
            case 2:
                return '2';
            case 3:
                return '3';
            case 4:
                return '4';
            case 5:
                return '5';
            case 6:
                return '6';
            case 7:
                return '7';
            case 8:
                return '8';
            case 9:
                return '9';
            case 10:
                return 'A';
            case 11:
                return 'B';
            case 12:
                return 'C';
            case 13:
                return 'D';
            case 14:
                return 'E';
            case 15:
                return 'F';
            default:
                return 'X';
        }
    }
    
    private static int HexToDec(string hex)
    {
        switch (hex)
        {
            case "0":
                return 0;
            case "1":
                return 1;
            case "2":
                return 2;
            case "3":
                return 3;
            case "4":
                return 4;
            case "5":
                return 5;
            case "6":
                return 6;
            case "7":
                return 7;
            case "8":
                return 8;
            case "9":
                return 9;
            case "A":
                return 10;
            case "B":
                return 11;
            case "C":
                return 12;
            case "D":
                return 13;
            case "E":
                return 14;
            case "F":
                return 15;
            default:
                return -1;
        }
    }

    public override string ToString()
    {
        return _hex; 
    }
}