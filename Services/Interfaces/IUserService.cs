using SteenBookKeepingSystem.DTO;
using SteenBookKeepingSystem.Models;

namespace SteenBookKeepingSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(CreateUserDTO newUser);
    }
}
