using System.Web.Http;
using JwtAuthsApi.Models;
using JwtAuthsApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthsApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _loggger;
        private readonly IUserAuthentication _service;
        public AccountController( ILogger<AccountController> logger,IUserAuthentication service)
        {
            
            _loggger=logger;
            _service = service;
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Register(UserRegister register)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                _service.Register(register);
                return Ok(register);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Login(Login loginUser)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                return  _service.Login(loginUser);
        }

    }
}
