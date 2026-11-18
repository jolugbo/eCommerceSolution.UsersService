using eCommerce.Core.Dto;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private IUsersService _usersService;
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    [HttpGet("{userID}")]
    public async Task<IActionResult> GetUserByUserID(Guid? userID)
    {
        await Task.Delay(100);
        throw new NotImplementedException();
        if (userID == null || userID == Guid.Empty)
        {
            return BadRequest("Invalid userID");
        }
        UserDTO? user = await _usersService.GetUserByUserID(userID);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}
