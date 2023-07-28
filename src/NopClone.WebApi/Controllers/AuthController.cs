using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopClone.WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [Authorize]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult LogIn(string username, string password)
        {
            return Ok();
        }

        [HttpPost("signup")]
        public IActionResult SignUp(string userName, string password)
        {
            return Ok();
        }
    }
}
