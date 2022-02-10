using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Hafta2.Odev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IJWTAutheticationManager _jWTAutheticationManager;
        public LoginController(IJWTAutheticationManager jWTAutheticationManager)
        {
            _jWTAutheticationManager = jWTAutheticationManager;
        }
        
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User user)
        {
            var token = _jWTAutheticationManager.Autheticate(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
