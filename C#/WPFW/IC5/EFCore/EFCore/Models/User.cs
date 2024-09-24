namespace EFCore.Models;

public class User
{
  private String _email { get; set; }

  public User(String email)
  {
    _email = email;
  }
}