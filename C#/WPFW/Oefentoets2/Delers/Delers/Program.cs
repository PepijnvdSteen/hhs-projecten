namespace Delers;

class Program
{
  static void Main(string[] args)
  {
    try
    {
      Delen delen = new Delen(3, 1000, 2, 6);
      delen.CheckDelers();
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }
  }
}