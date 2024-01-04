using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(BookKeepingContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<ApplicationUser> CreateUserAsync(CreateUserDTO newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException(nameof(newUser));

            var user = new ApplicationUser
            {
                UserName = newUser.Email, 
                Email = newUser.Email,
                DateOfBirth = newUser.DateOfBirth,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                // Additional properties
            };

            var result = await _userManager.CreateAsync(user, newUser.Password);
            if (!result.Succeeded)
            {
                // Handle the case where user creation fails
                throw new InvalidOperationException("User creation failed.");
            }

            return user;
        }
    }
}
