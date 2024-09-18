namespace EFCore.ORM;

public class Grade
{
  public int grades { get; private set; }
  
  public Grade (int grade)
  {
    grades = grade;
  }
}