using Microsoft.EntityFrameworkCore;
using SteenBookKeepingSystem.Models;

namespace SteenBookKeepingSystem.Database.Context
{
    public class BookKeepingContext : DbContext
    {
        public BookKeepingContext(DbContextOptions<BookKeepingContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
    }
}