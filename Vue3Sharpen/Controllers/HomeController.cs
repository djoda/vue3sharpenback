using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Vue3Sharpen.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {

        }   

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult secret()
        {
            return new JsonResult("secret");
        }
    }
}
