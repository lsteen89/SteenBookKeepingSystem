using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteenBookKeepingSystem.Database.Context;
using SteenBookKeepingSystem.DTO;
using SteenBookKeepingSystem.Models;
using SteenBookKeepingSystem.Services.Implementations;
using SteenBookKeepingSystem.Services.Interfaces;

namespace SteenBookKeepingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BookKeepingContext _context;
        private readonly IUserService _userService;

        public UserController(BookKeepingContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }


        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDTO newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                try
            {
                var user = await _userService.CreateUserAsync(newUser);
                return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("User data is required");
            }
            // Catch other types of exceptions as needed
        }

        // Method for getting a user by ID (for the CreatedAtAction)
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}
