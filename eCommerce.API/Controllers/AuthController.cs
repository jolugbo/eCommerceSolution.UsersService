using eCommerce.Core.Dto;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;
    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    [HttpPost("register")]//POST api/auth/register
    public async Task<IActionResult> Register(RegisterRequest registerRequest) { 
        if(registerRequest ==null)
        {
            return BadRequest("Invalid registration data");
        }
        AuthenticationResponse? response = await _usersService.Registration(registerRequest);
        if(response == null|| response.Success == false)
        {
            return BadRequest("Registration failed");
        }
        return Ok(response);
    }
    [HttpPost("login")]//POST api/auth/login
    public async Task<IActionResult> Login(LoginRequest loginReq)
    {
        if (loginReq == null)
        {
            return BadRequest("Invalid Login data");
        }
        AuthenticationResponse? response = await _usersService.Login(loginReq);
        if (response == null || response.Success == false)
        {
            return Unauthorized(response);
        }
        return Ok(response);
    }
}
