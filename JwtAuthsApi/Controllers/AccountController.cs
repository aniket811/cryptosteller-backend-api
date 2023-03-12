using System.Web.Http;
using JwtAuthsApi.Models;
using JwtAuthsApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthsApi.Controllers
{
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
        public IActionResult Register([Microsoft.AspNetCore.Mvc.FromBody]UserRegister register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _service.Register(register);
                return Ok(register);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Login([Microsoft.AspNetCore.Mvc.FromBody] Login loginUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _service.Login(loginUser);
                return Ok(loginUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
