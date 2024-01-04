using Microsoft.EntityFrameworkCore;
using SteenBookKeepingSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SteenBookKeepingSystem.Database.Context
{
    public class BookKeepingContext : IdentityDbContext<ApplicationUser>
    {
        public BookKeepingContext(DbContextOptions<BookKeepingContext> options)
            : base(options)
        {
        }

        //public DbSet<User> Users { get; set; }
        
    }
}