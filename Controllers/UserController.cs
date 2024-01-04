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
        public async Task<ActionResult<ApplicationUser>> CreateUser([FromBody] CreateUserDTO newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                try
            {
                var user = await _userService.CreateUserAsync(newUser);

                /*
                return CreatedAtRoute(
                    routeName: "GetUserById", // The route name of the action to get the user by Id
                    routeValues: new { id = user.Id }, // The route value, typically the new user's Id
                    value: user); // The created user object
                */
                return Ok(user);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("User data is required");
            }
            // Catch other types of exceptions as needed
        }
    }
}
