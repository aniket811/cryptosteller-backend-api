using JwtAuthsApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace JwtAuthsApi.Services
{
    public interface IUserAuthentication
    {
        public IActionResult Register(UserRegister user);
        public IActionResult  Login(Login loginUser);

    }
}
