using System.Threading.Tasks;
using BLB.Api.Net.Interfaces;
using BLB.Api.Net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BLB.Api.Net.Controllers.v1
{
    [Route("api/v1/[controller]")]
    public class UsersController : Controller
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = await userService.AuthenticateAsync(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("test-authentication")]
        public IActionResult TestAuthentication()
        {
            return Ok("You are authenticated");
        }
    }
}
