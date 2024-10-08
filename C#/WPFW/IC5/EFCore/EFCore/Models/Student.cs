using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models;

public class Student : User
{
  [Key] public int StudentNr { get; set; }
  public String Name {get; private set;}
  [Column("Grades")] public List<Grade> Grades { get; set; } = new List<Grade>();
  public String Email {get; private set;}

  public List<Teacher> teachers { get; set; }

  public Student(String name, String email) : base(email)
  {
    Name = name;
    Email = email;
  }
}