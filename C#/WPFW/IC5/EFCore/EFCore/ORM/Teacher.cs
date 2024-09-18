using System.ComponentModel.DataAnnotations;

namespace EFCore.ORM;

public class Teacher : User
{
  [Key] public int TeacherNr { get; set; }
  public String TeachingCourse { get; private set; }
  public String Email { get; private set; }

  public Teacher(String teachingCourse, String email) : base(email)
  {
    TeachingCourse = teachingCourse;
    Email = email;
  }
  
}