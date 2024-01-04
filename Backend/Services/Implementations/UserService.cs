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
        public async Task<UserDTO> CreateUserAsync(CreateUserDTO newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException(nameof(newUser));

            var user = new ApplicationUser
            {
                UserName = newUser.Email,
                Email = newUser.Email,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
            };

            var result = await _userManager.CreateAsync(user, newUser.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"User creation failed: {errors}");
            }

            // Convert ApplicationUser to UserDTO for the response
            var userDto = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
            };

            return userDto;
        }


        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            return new UserDTO
            {
                Id = id,
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }


    }
}
