using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    // Add additional properties that are in your User class
    public DateTime DateOfBirth { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    // Other properties...
}