using System.ComponentModel.DataAnnotations;

namespace SteenBookKeepingSystem.Models
{
    public class Company
    {
        [Key]
        [StringLength(100)]//Enskild firma = personnummer
        public string CompanyId { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyType { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
