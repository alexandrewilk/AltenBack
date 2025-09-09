using Back.Models.Entities;
using Back.Services;
using Back.Services.IServices;
using Microsoft.AspNetCore.Mvc;
namespace Back.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("account")]
        public IActionResult Register([FromBody]User user)
        {

            if (!_authService.Register(user, out var error))
                return BadRequest(error);

            return Ok("Successfully created account");
        }

        [HttpPost("token")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _authService.Authenticate(request.Email, request.Password);
            if (token == null)
                return Unauthorized("Invalid Credentials");

            return Ok(token);

        }
    }
}
