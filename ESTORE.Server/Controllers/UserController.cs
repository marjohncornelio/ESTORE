using ESTORE.Server.Models;
using ESTORE.Server.Services.UserServices;
using ESTORE.Shared.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ESTORE.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDetailsDTO>> GetAuthenticatedUserDetails()
        {
            var response = await userService.GetAuthenticatedUserDetails();

            switch (response.ResponseCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response.Data);
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
