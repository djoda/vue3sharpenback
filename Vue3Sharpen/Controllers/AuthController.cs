using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vue3Sharpen.Model;
using Vue3Sharpen.Services;

namespace Vue3Sharpen.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private Dictionary<String, String> users = new Dictionary<string, string>();

        private TokenService tokenService;
        public AuthController()
        {
            this.tokenService = new TokenService();
            users.Add("user", "123");
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginInput input)
        {
            if (users.ContainsKey(input.username))
            {
                if(users[input.username] == input.password)
                {
                    return new JsonResult(tokenService.Generate(input.username));
                }
            }
            return Unauthorized();
        }
    }
}
