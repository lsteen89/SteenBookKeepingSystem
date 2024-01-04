using System.ComponentModel.DataAnnotations;

namespace SteenBookKeepingSystem.DTO
{
    public class CreateUserDTO
    {   
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]*$", ErrorMessage = "Endast bokstäver är tillåtna i namn.")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]*$", ErrorMessage = "Endast bokstäver är tillåtna i namn.")]
        public string LastName { get; set; }
    }
}
