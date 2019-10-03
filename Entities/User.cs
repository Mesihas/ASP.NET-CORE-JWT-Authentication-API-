using System.Collections.Generic;

namespace WebApi.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    /// new  properties
    public string DisplayName { get; set; }
    public string PhotoURL { get; set; }
    public string Email { get; set; }
    public string[] Shortcuts { get; set; }

  }

}
