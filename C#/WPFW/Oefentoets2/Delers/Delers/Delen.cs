namespace Delers;

public class Delen
{
  public List<int> Deelbaar;
  public int Bovengrens { get; private set; } = 0;
  public int Ondergrens { get; private set; } = 0;
  public int DeelbaarDoor { get; private set; }
  public int DeelbaarDoor2 { get; private set; }

  public Delen(int bovengrens, int ondergrens, int deelbaarDoor, int deelbaarDoor2)
  {
    Bovengrens = bovengrens;
    Ondergrens = ondergrens;
    DeelbaarDoor = deelbaarDoor;
    DeelbaarDoor2 = deelbaarDoor2;
  }

  public void CheckDelers()
  {
    try
    {
      for (int i = Ondergrens; i <= Bovengrens; i++)
      {
        if (i % DeelbaarDoor == 0 || i % DeelbaarDoor == 0)
        {
          Deelbaar.Add(i);
        }
      }
      
      foreach (int deel in Deelbaar)
      {
        Console.WriteLine($"{deel}\n");
      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
    }
  }
}
