using SteenBookKeepingSystem.Database.Context;
using SteenBookKeepingSystem.DTO;
using SteenBookKeepingSystem.Models;
using SteenBookKeepingSystem.Services.Interfaces;

namespace SteenBookKeepingSystem.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly BookKeepingContext _context;

        public UserService(BookKeepingContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(CreateUserDTO newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException(nameof(newUser));

            // Data manipulation and hashing password
            var user = new User
            {
                Username = newUser.Username,
                Email = newUser.Email,
                Password = HashPassword(newUser.Password),
                // Set other fields
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private string HashPassword(string password)
        {
            // Implement password hashing here
            return password; // Replace with actual hashed password
        }
    }

}
