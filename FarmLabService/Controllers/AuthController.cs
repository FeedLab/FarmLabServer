using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmLabService.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        //[Route("secret")]
        //public IActionResult Secret()
        //{
        //    return View(new User(this.User));
        //}

        [Authorize]
        [Route("home")]
        public bool Home()
        {
            return User.Identities.Any(v => v.IsAuthenticated);
        }
    }
}
