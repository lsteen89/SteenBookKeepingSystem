using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
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

            string username = await CreateUsername(newUser.FirstName, newUser.LastName);
            var user = new User
            {
                Username = username,
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
        private async Task<string> CreateUsername(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Förnamn och/eller efternamn kan inte vara blankt.");
            }

            if (firstName.Length < 2 || lastName.Length < 2)
            {
                throw new ArgumentException("Förnamn och/eller efternamn måste vara minst två tecken långa.");
            }
            else
            {
                string baseUsername = (firstName.Substring(0, 2) + firstName.Substring(0, 2)).ToLower().Trim();
                string username = baseUsername;
                int counter = 1;

                while (await _context.Users.AnyAsync(u => u.Username == username))
                {
                    // If the username exists, append a number and check again
                    username = baseUsername + counter.ToString();
                    counter++;
                }
                return username;
            }
        }

    }

}
