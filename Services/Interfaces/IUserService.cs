using SteenBookKeepingSystem.DTO;
using SteenBookKeepingSystem.Models;

namespace SteenBookKeepingSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> CreateUserAsync(CreateUserDTO newUser);
    }
}
