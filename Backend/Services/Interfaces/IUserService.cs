using SteenBookKeepingSystem.DTO;
using SteenBookKeepingSystem.Models;

namespace SteenBookKeepingSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> CreateUserAsync(CreateUserDTO newUser);
        Task<UserDTO> GetUserByIdAsync(string id);
    }
}
