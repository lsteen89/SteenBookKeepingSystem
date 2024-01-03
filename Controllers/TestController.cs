using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteenBookKeepingSystem.Database.Context;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly BookKeepingContext _context; 

    public TestController(BookKeepingContext context)
    {
        _context = context;
    }

    [HttpGet("TestDatabaseConnection")]
    public async Task<IActionResult> TestDatabaseConnection()
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync();
            return Ok(new { message = "Connection successful", user });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
