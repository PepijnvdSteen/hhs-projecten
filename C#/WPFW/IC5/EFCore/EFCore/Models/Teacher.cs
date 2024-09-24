using System.ComponentModel.DataAnnotations;

namespace EFCore.Models;

public class Teacher : User
{
  [Key] public int TeacherNr { get; set; }
  public String TeachingCourse { get; private set; }
  public String Email { get; private set; }
  public List<Student> students { get; private set; }

  public Teacher(String teachingCourse, String email) : base(email)
  {
    TeachingCourse = teachingCourse;
    Email = email;
  }
  
}