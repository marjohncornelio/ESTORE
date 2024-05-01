using ESTORE.Server.Services.AuthServices;
using ESTORE.Shared.DTO.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ESTORE.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> CreateAccountController(RegisterDTO user)
        {
            var response = await _authService.CreateAccount(user);

            switch (response.ResponseCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response.Token);
                case HttpStatusCode.BadRequest:
                    return BadRequest(response.Message);
                case HttpStatusCode.NotFound:
                    return NotFound(response.Message);
                default:
                    return BadRequest("Error Occured, Try Again Later");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginController(LoginDTO user)
        {
            var response = await _authService.LoginAccount(user);

            switch (response.ResponseCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response.Token);
                case HttpStatusCode.BadRequest:
                    return BadRequest(response.Message);
                case HttpStatusCode.NotFound:
                    return NotFound(response.Message);
                default:
                    return BadRequest("Error Occured, Try Again Later");
            }
        }
    }
}
